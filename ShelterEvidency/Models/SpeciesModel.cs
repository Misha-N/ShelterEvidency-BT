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

        public static List<Species> ReturnSpecies()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                return db.Species.ToList();
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
                        SpeciesName = SpeciesName
                    };
                    db.Species.InsertOnSubmit(species);
                    db.SubmitChanges();

                    ID = species.Id;
                }
            }

        }
    }
}
