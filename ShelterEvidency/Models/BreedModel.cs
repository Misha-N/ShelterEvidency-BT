using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class BreedModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string BreedName { get; set; }
        public int? SpeciesID { get; set; }
        #endregion
        public static List<Breeds> ReturnBreeds(int? speciesID)
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            if (speciesID is null)
                return db.Breeds.ToList();
            else
                return db.Breeds.Where(x => x.SpeciesID.Equals(speciesID)).ToList();
        }
        public void SaveBreed()
        {
            if (BreedName != null)
            {
                ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
                Breeds breed = new Breeds
                {
                    BreedName = BreedName, 
                    SpeciesID = SpeciesID
                };
                db.Breeds.InsertOnSubmit(breed);
                db.SubmitChanges();

                ID = breed.Id;
            }
        }


        
    }
}
