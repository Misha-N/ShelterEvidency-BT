using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    class StatisticModel
    {
        public static int AnimalsInShelterSum()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int total =
                    (from animal in db.Animals
                     where (animal.InShelter == true)
                     select animal)
                    .Count();

                return total;
            }
        }
    }
}
