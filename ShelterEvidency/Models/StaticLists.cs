using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    class StaticLists
    {
        public List<string> Sex()
        {
            return new List<string>() { "samec", "samice", "neznámé"};
        }

        public List<string> Breed()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.Breeds.Select(x => x.Breed).ToList();
        }

        public List<string> Species()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.Species.Select(x => x.Name).ToList();
        }

        public List<string> CoatType()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.CoatTypes.Select(x => x.CoatType).ToList();
        }

        public List<string> FurColor()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.FurColors.Select(x => x.FurColor).ToList();
        }

    }
}
