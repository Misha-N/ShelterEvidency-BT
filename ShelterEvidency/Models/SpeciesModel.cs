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
        private string _speciesName;

        public string SpeciesName
        {
            get
            {
                return _speciesName;
            }
            set
            {
                _speciesName = value;
            }
        }

        public List<string> ReturnSpeciesList()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.Species.Select(x => x.Name).ToList();
        }

        public List<Species> ReturnSpecies()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.Species.ToList();
        }

        public int NameToID()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            var species = db.Species.FirstOrDefault(i => i.Name == SpeciesName);
            return species.Id;
        }

        public string IDToName(int speciesID)
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            var species = db.Species.FirstOrDefault(i => i.Id == speciesID);
            return species.Name;
        }

        public void SaveSpecies()
        {
            if (SpeciesName != null)
            {

                ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
                Species species = new Species
                {
                    Name = SpeciesName
                };
                db.Species.InsertOnSubmit(species);
                db.SubmitChanges();
            }

        }
    }
}
