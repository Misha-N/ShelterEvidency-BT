using ShelterEvidency.Database;
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
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();

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

        public static List<MedicalRecords> GetAnimalMedicalRecords(int animalID)
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.MedicalRecords.Where(x => x.AnimalID.Equals(animalID)).ToList();
        }

        public void GetMedicalRecord(int? medicalRecordID)
        {
            ID = medicalRecordID;
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            var medicalRecord = db.MedicalRecords.FirstOrDefault(i => i.Id == medicalRecordID);
            if (medicalRecord != null)
                SetInformations(medicalRecord);
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
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            MedicalRecords medicalRecord = db.MedicalRecords.FirstOrDefault(i => i.Id == ID);

            medicalRecord.RecordName = RecordName;
            medicalRecord.VetID = VetID;
            medicalRecord.Description = Description;
            medicalRecord.Date = Date;

            db.SubmitChanges();
        }
    }
}
