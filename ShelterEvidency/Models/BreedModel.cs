using Caliburn.Micro;
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
        public static BindableCollection<Breeds> ReturnBreeds(int? speciesID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                if (speciesID is null)
                    return new BindableCollection<Breeds>(db.Breeds);
                else
                    return  new BindableCollection<Breeds>(db.Breeds.Where(x => x.SpeciesID.Equals(speciesID)));
            }
        }
        public void SaveBreed()
        {
            if (BreedName != null)
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
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
}
