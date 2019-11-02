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
        private string _breedName;

        public string BreedName
        {
            get
            {
                return _breedName;
            }
            set
            {
                _breedName = value;
            }
        }

        private SpeciesModel _species;

        public SpeciesModel Species
        {
            get
            {
                return _species;
            }
            set
            {
                _species = value;
            }
        }

        public BreedModel()
        {
            Species = new SpeciesModel();
        }


        public List<string> ReturnBreedList()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.Breeds.Select(x => x.Breed).ToList();
        }
        public ObservableCollection<Breeds> ReturnBreeds()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return new ObservableCollection<Breeds>(db.Breeds);
        }

        public void SaveBreed()
        {
            if (BreedName != null & Species.SpeciesName != null)
            {

                ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
                Breeds breed = new Breeds
                {
                    Breed = BreedName, 
                    Species = Species.NameToID()
                };
                db.Breeds.InsertOnSubmit(breed);
                db.SubmitChanges();

            }


        }
    }
}
