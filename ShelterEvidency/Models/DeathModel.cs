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
    class DeathModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int AnimalID { get; set; }
        public bool Euthanasia { get; set; }
        public bool Natural { get; set; }
        public bool Other { get; set; }

        #endregion

        public void CreateDeath()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                Deaths death = new Deaths
                {
                    AnimalID = AnimalID,
                    Date = Date,
                    Description = Description,
                    Euthanasia = Euthanasia,
                    Natural = Natural,
                    Other = Other
                };
                db.Deaths.InsertOnSubmit(death);
                db.SubmitChanges();

            }
        }

        public static BindableCollection<DeathInfo> GetDatedDeaths(DateTime? since, DateTime? to)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {

                var results = (from death in db.Deaths
                               where (death.Date >= since && death.Date <= to) && (death.IsDeleted.Equals(false))
                               select new DeathInfo
                               {
                                   ID = death.Id,
                                   Date = death.Date,
                                   AnimalID = death.AnimalID,
                                   AnimalName = death.Animals.Name,
                                   Description = death.Description,
                                   Euthanasia = death.Euthanasia,
                                   Natural = death.Natural,
                                   Other = death.Other,
                               });
                return new BindableCollection<DeathInfo>(results);
            }
        }


        public static void MarkAsDeleted(int id)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var death = db.Deaths.Single(x => x.Id == id);
                death.IsDeleted = true;
                db.SubmitChanges();
            }
        }

        public bool ValidValues()
        {
            if (AnimalModel.GetAnimalInfo(AnimalID) != null)
                return true;
            else
                return false;
        }
    }
}
