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
        public static int? AnimalsInShelterSum()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from animal in db.Animals
                     where (animal.InShelter == true) && animal.IsDeleted.Equals(false)
                     select animal)
                    .Count();
                if (total != null)
                    return total;
                else
                    return 0;
            }
        }

        public static int? SuccessfullyAdoptedAnimals()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from adoption in db.Adoptions
                     where (adoption.Returned == false) && adoption.IsDeleted.Equals(false)
                     select adoption)
                    .Count();
                if (total != null)
                    return total;
                else
                    return 0;
            }
        }

        public static int? TotalCosts()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from cost in db.Costs
                     where cost.IsDeleted.Equals(false)
                     select cost.Price)
                    .Sum();
                if (total != null)
                    return total;
                else
                    return 0;
            }
        }

        public static int? TotalAnimalCosts(int animalID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from cost in db.Costs
                     where cost.AnimalID.Equals(animalID) && cost.IsDeleted.Equals(false)
                     select cost.Price)
                    .Sum();
                if (total != null)
                    return total;
                else
                    return 0;
            }
        }

        public static int? TotalAnimalDays(int animalID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from stay in db.Stays
                     where stay.AnimalID.Equals(animalID) && stay.IsDeleted.Equals(false) && !stay.FinishDate.Equals(null)
                     select (int)((DateTime)stay.FinishDate - (DateTime)stay.StartDate).TotalDays)
                    .Sum();

                if (total != null)
                    return total;
                else
                    return 0;
            }
        }

        public static int? TotalAnimalStays(int animalID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from stay in db.Stays
                     where stay.AnimalID.Equals(animalID) && stay.IsDeleted.Equals(false)
                     select stay)
                    .Count();
                if (total != null)
                    return total;
                else
                    return 0;
            }
        }

        public static int? TotalAnimalIncidents(int animalID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from incident in db.Incidents
                     where incident.AnimalID.Equals(animalID) && incident.IsDeleted.Equals(false)
                     select incident)
                    .Count();
                if (total != null)
                    return total;
                else
                    return 0;
            }
        }

        public static int? TotalAnimalMedicalRecords(int animalID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from record in db.MedicalRecords
                     where record.AnimalID.Equals(animalID) && record.IsDeleted.Equals(false)
                     select record)
                    .Count();
                if (total != null)
                    return total;
                else
                    return 0;
            }
        }

        public static int? TotalAnimalEscapes(int animalID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from escape in db.Escapes
                     where escape.AnimalID.Equals(animalID) && escape.IsDeleted.Equals(false)
                     select escape)
                    .Count();
                if (total != null)
                    return total;
                else
                    return 0;
            }
        }

        public static int? TotalAnimalWalks(int animalID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from walk in db.Walks
                     where walk.AnimalID.Equals(animalID) && walk.IsDeleted.Equals(false)
                     select walk)
                    .Count();
                if (total != null)
                    return total;
                else
                    return 0;
            }
        }

        public static int? DatedCosts(DateTime since, DateTime to)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from cost in db.Costs
                     where (cost.Date >= since) && (cost.Date <= to) && cost.IsDeleted.Equals(false)
                     select cost.Price)
                    .Sum();
                if (total != null)
                    return total;
                else
                    return 0;
            }
        }

        public static int? TotalDonations()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from donation in db.Donations
                     where donation.IsDeleted.Equals(false)
                     select donation.Amount)
                    .Sum();
                if (total != null)
                    return total;
                else
                    return 0;
            }
        }

        public static int? DatedDonations(DateTime since, DateTime to)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                int? total =
                    (from donation in db.Donations
                     where (donation.Date >= since) && (donation.Date <= to) && donation.IsDeleted.Equals(false)
                     select donation.Amount)
                    .Sum();
                if (total != null)
                    return total;
                else
                    return 0;
            }
        }
    }
}
