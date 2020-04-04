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
    class WalkModel
    {
        #region Properties/Atributes
        public int? ID { get; set; }
        public DateTime? Date { get; set; }
        public string Note { get; set; }
        public int? AnimalID { get; set; }
        public int? PersonID { get; set; }
        #endregion

        public void SaveWalk()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                db.DeferredLoadingEnabled = false;

                Walks walk = new Walks
                {
                    AnimalID = AnimalID,
                    Date = Date,
                    PersonID = PersonID,
                    Note = Note
                };
                db.Walks.InsertOnSubmit(walk);
                db.SubmitChanges();
                
                ID = walk.ID;
                
            }
        }


        public static BindableCollection<WalkInfo> GetAnimalWalks(int animalID)
        {

            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from walk in db.Walks
                               where (walk.AnimalID.Equals(animalID)) && (walk.IsDeleted.Equals(false))
                               select new WalkInfo
                               {
                                   ID = walk.ID,
                                   Date = walk.Date,
                                   Note = walk.Note,
                                   AnimalID = walk.AnimalID,
                                   AnimalName = walk.Animals.Name,
                                   PersonID = walk.PersonID,
                                   PersonName = walk.People.FirstName + " " + walk.People.LastName,
                               });
                return new BindableCollection<WalkInfo>(results);

            }
        }

        public static BindableCollection<WalkInfo> GetDatedWalks(DateTime? since, DateTime? to)
        {

            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from walk in db.Walks
                               where (walk.Date >= since && walk.Date <= to) && (walk.IsDeleted.Equals(false))
                               select new WalkInfo
                               {
                                   ID = walk.ID,
                                   Date = walk.Date,
                                   Note = walk.Note,
                                   AnimalID = walk.AnimalID,
                                   AnimalName = walk.Animals.Name,
                                   PersonID = walk.PersonID,
                                   PersonName = walk.People.FirstName + " " + walk.People.LastName,
                               });
                return new BindableCollection<WalkInfo>(results);

            }
        }

        public static BindableCollection<WalkInfo> GetAnimalDatedWalks(int animalID, DateTime? since, DateTime? to)
        {

            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from walk in db.Walks
                               where (walk.AnimalID.Equals(animalID) && (walk.Date >= since && walk.Date <= to))
                                && (walk.IsDeleted.Equals(false))
                               select new WalkInfo
                               {
                                   ID = walk.ID,
                                   Date = walk.Date,
                                   Note = walk.Note,
                                   AnimalID = walk.AnimalID,
                                   AnimalName = walk.Animals.Name,
                                   PersonID = walk.PersonID,
                                   PersonName = walk.People.FirstName + " " + walk.People.LastName,
                               });
                return new BindableCollection<WalkInfo>(results);

            }
        }

        public void GetWalk(int? walkID)
        {
            ID = walkID;
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var walk = db.Walks.FirstOrDefault(i => i.ID == walkID);
                if (walk != null)
                    SetInformations(walk);
            }
        }

        public void SetInformations(Walks walk)
        {
            Note = walk.Note;
            AnimalID = walk.AnimalID;
            Date = walk.Date;
            PersonID = walk.PersonID;
        }

        public void UpdateWalk()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                Walks walk = db.Walks.FirstOrDefault(i => i.ID == ID);

                walk.AnimalID = AnimalID;
                walk.PersonID = PersonID;
                walk.Note = Note;
                walk.Date = Date;

                db.SubmitChanges();
            }
        }

        public static BindableCollection<WalkInfo> ReturnPersonWalks(int personID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from walk in db.Walks
                               where (walk.PersonID.Equals(personID)) && (walk.IsDeleted.Equals(false))
                               select new WalkInfo
                               {
                                   ID = walk.ID,
                                   Date = walk.Date,
                                   PersonName = walk.People.FirstName + " " + walk.People.LastName,
                                   AnimalID = walk.AnimalID,
                                   AnimalName = walk.Animals.Name,
                                   Note = walk.Note,
                               });
                return new BindableCollection<WalkInfo>(results);
            }
        }

        public static void MarkAsDeleted(int id)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var walk = db.Walks.Single(x => x.ID == id);
                walk.IsDeleted = true;
                db.SubmitChanges();
            }
        }

        public bool ValidValues()
        {
            if (Date != null && Date != DateTime.MinValue && Date != DateTime.MaxValue)
                return true;
            else
                return false;
        }
    }
}
