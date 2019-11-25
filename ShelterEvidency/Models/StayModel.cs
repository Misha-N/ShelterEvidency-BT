using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class StayModel
    {
        #region Properties/Atributes
        public int? ID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int? AnimalID { get; set; }
        public string Note { get; set; }
        public bool? Adopted { get; set; }
        public bool? Escaped { get; set; }
        public bool? Died { get; set; }
        #endregion

        public StayModel()
        {
            Adopted = false;
            Escaped = false;
            Died = false;
        }

        public void SaveStay()
            {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                Stays stay = new Stays
                {
                    AnimalID = AnimalID,
                    StartDate = StartDate,
                    FinishDate = FinishDate,
                    Note = Note,
                    Adopted = Adopted,
                    Escaped = Escaped,
                    Died = Died
                };
                db.Stays.InsertOnSubmit(stay);
                db.SubmitChanges();
            }

        }

        public void GetStay(int? stayID)
        {
            ID = stayID;
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var stay = db.Stays.FirstOrDefault(i => i.Id == stayID);
                if (stay != null)
                    SetInformations(stay);
            }
        }

        public static List<Stays> GetAnimalStays(int animalID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                return db.Stays.Where(x => x.AnimalID.Equals(animalID)).ToList();
            }
        }

        public void SetInformations(Stays stay)
        {
            StartDate = stay.StartDate;
            FinishDate = stay.FinishDate;
            AnimalID = stay.AnimalID;
            Note = stay.Note;
            Adopted = stay.Adopted;
            Escaped = stay.Escaped;
            Died = stay.Died;
        }

        public void UpdateStay()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                Stays stay = db.Stays.FirstOrDefault(i => i.Id == ID);

                stay.StartDate = StartDate;
                stay.FinishDate = FinishDate;
                stay.Note = Note;
                stay.Adopted = Adopted;
                stay.Escaped = Escaped;
                stay.Died = Died;

                db.SubmitChanges();
            }
        }

    }
}
