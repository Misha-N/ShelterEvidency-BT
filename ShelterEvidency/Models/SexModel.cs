using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    class SexModel
    {
        public List<string> ReturnSexList()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.Sexes.Select(x => x.Sex).ToList();
        }
    }
}
