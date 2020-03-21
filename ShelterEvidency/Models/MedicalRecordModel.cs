using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.WrappingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class MedicalRecordModel
    {
        #region Properties/Atributes
        public int? ID { get; set; }
        public string RecordName { get; set; }
        public string Description { get; set; }
        public int? CostID { get; set; }
        public int? AnimalID { get; set; }
        public DateTime? Date { get; set; }
        public int? VetID { get; set; }
        #endregion

        public void SaveMedicalRecord()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                MedicalRecords medicalRecord = new MedicalRecords
                {
                    AnimalID = AnimalID,
                    RecordName = RecordName,
                    Description = Description,
                    CostID = CostID,
                    Date = Date,
                    VetID = VetID
                };
                db.MedicalRecords.InsertOnSubmit(medicalRecord);
                db.SubmitChanges();

                ID = medicalRecord.Id;
            }
        }

        public static BindableCollection<MedicalRecordInfo> GetAnimalMedicalRecords(int animalID)
        {

            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from record in db.MedicalRecords
                               where (record.AnimalID.Equals(animalID))
                               select new MedicalRecordInfo
                               {
                                   ID = record.Id,
                                   Date = record.Date,
                                   RecordName = record.RecordName,
                                   AnimalID = record.AnimalID,
                                   AnimalName = record.Animals.Name,
                                   Description = record.Description,
                                   VetID = record.VetID,
                                   VetName = record.People.FirstName + " " + record.People.LastName,
                                   CostID = record.CostID,
                               });
                return new BindableCollection<MedicalRecordInfo>(results);

            }
        }

        public static BindableCollection<MedicalRecordInfo> GetDatedMedicalRecords(int animalID, DateTime? since, DateTime? to)
        {

            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from record in db.MedicalRecords
                               where (record.AnimalID.Equals(animalID) && (record.Date >= since && record.Date <= to))
                               select new MedicalRecordInfo
                               {
                                   ID = record.Id,
                                   Date = record.Date,
                                   RecordName = record.RecordName,
                                   AnimalID = record.AnimalID,
                                   AnimalName = record.Animals.Name,
                                   Description = record.Description,
                                   VetID = record.VetID,
                                   VetName = record.People.FirstName + " " + record.People.LastName,
                                   CostID = record.CostID,
                               });
                return new BindableCollection<MedicalRecordInfo>(results);

            }
        }

        public void GetMedicalRecord(int? medicalRecordID)
        {
            ID = medicalRecordID;
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var medicalRecord = db.MedicalRecords.FirstOrDefault(i => i.Id == medicalRecordID);
                if (medicalRecord != null)
                    SetInformations(medicalRecord);
            }
        }
        public void SetInformations(MedicalRecords medicalRecord)
        {
            RecordName = medicalRecord.RecordName;
            Description = medicalRecord.Description;
            CostID = medicalRecord.CostID;
            AnimalID = medicalRecord.AnimalID;
            Date = medicalRecord.Date;
            VetID = medicalRecord.VetID;
        }

        public void UpdateMedicalRecord()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                MedicalRecords medicalRecord = db.MedicalRecords.FirstOrDefault(i => i.Id == ID);

                medicalRecord.RecordName = RecordName;
                medicalRecord.VetID = VetID;
                medicalRecord.Description = Description;
                medicalRecord.Date = Date;

                db.SubmitChanges();
            }
        }
    }
}
