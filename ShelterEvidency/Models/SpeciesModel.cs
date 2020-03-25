using Caliburn.Micro;
using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class SpeciesModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string SpeciesName { get; set; }
        #endregion

        public static BindableCollection<Species> ReturnSpecies()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                return new BindableCollection<Species>(db.Species.Where(x => x.IsDeleted.Equals(false)));
            }
        }


        public void SaveSpecies()
        {
            if (SpeciesName != null)
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    Species species = new Species
                    {
                        SpeciesName = SpeciesName,
                        IsDeleted = false
                    };
                    db.Species.InsertOnSubmit(species);
                    db.SubmitChanges();

                    ID = species.Id;
                }
            }

        }

        public static void MarkAsDeleted(int id)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var species = db.Species.Single(x => x.Id == id);
                species.IsDeleted = true;
                db.SubmitChanges();
            }
        }
    }
}
