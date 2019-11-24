using ShelterEvidency.Database;
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

        public static List<Walks> GetAnimalWalks(int animalID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                return db.Walks.Where(x => x.AnimalID.Equals(animalID)).ToList();
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
    }
}
