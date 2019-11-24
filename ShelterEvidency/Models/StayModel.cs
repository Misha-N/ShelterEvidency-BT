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
        public int? EndTypeID { get; set; }
        #endregion

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
                    EndTypeID = EndTypeID
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
            EndTypeID = stay.EndTypeID;
            AnimalID = stay.AnimalID;
            Note = stay.Note;
        }

        public void UpdateStay()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                Stays stay = db.Stays.FirstOrDefault(i => i.Id == ID);

                stay.EndTypeID = EndTypeID;
                stay.StartDate = StartDate;
                stay.FinishDate = FinishDate;
                stay.Note = Note;

                db.SubmitChanges();
            }
        }

    }
}
