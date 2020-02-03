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

        public static int SuccessfullyAdoptedAnimals()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int total =
                    (from adoption in db.Adoptions
                     where (adoption.Returned == false)
                     select adoption)
                    .Count();

                return total;
            }
        }

        public static int? TotalCosts()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from cost in db.Costs
                     select cost.Price)
                    .Sum();

                return total;
            }
        }

        public static int? DatedCosts(DateTime since, DateTime to)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from cost in db.Costs
                     where (cost.Date >= since) && (cost.Date <= to)
                     select cost.Price)
                    .Sum();

                return total;
            }
        }

        public static int? TotalDonations()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from donation in db.Donations
                     select donation.Amount)
                    .Sum();

                return total;
            }
        }

        public static int? DatedDonations(DateTime since, DateTime to)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from donation in db.Donations
                     where (donation.Date >= since) && (donation.Date <= to)
                     select donation.Amount)
                    .Sum();

                return total;
            }
        }
    }
}
