using ShelterEvidency.Database;
using System;
using System.Linq;
using System.Windows;

namespace ShelterEvidency.Models
{
    class StatisticModel
    {
        public static int? AnimalsInShelterSum()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from animal in db.Animals
                         where (animal.InShelter == true) && animal.IsDeleted.Equals(null)
                         select animal)
                        .Count();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? SuccessfullyAdoptedAnimals()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from adoption in db.Adoptions
                         where (adoption.Returned == false) && adoption.IsDeleted.Equals(null)
                         select adoption)
                        .Count();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? TotalCosts()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from cost in db.Costs
                         where cost.IsDeleted.Equals(null)
                         select cost.Price)
                        .Sum();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? TotalAnimalCosts(int animalID)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from cost in db.Costs
                         where cost.AnimalID.Equals(animalID) && cost.IsDeleted.Equals(null)
                         select cost.Price)
                        .Sum();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? TotalAnimalDays(int animalID)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from stay in db.Stays
                         where stay.AnimalID.Equals(animalID) && stay.IsDeleted.Equals(null) && !stay.FinishDate.Equals(null)
                         select (int?)((DateTime)stay.FinishDate - (DateTime)stay.StartDate).TotalDays)
                        .Sum();

                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static DateTime NullDateToNow(DateTime? finishDate)
        {
            if (finishDate == null)
                return DateTime.Now;
            else
                return (DateTime)finishDate;
        }

        public static int? TotalAnimalStays(int animalID)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from stay in db.Stays
                         where stay.AnimalID.Equals(animalID) && stay.IsDeleted.Equals(null)
                         select stay)
                        .Count();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }

        }

        public static bool? AnimalAdopted(int animalID)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    bool? result =
                        (from adoption in db.Adoptions
                         where adoption.AnimalID.Equals(animalID) && adoption.IsDeleted.Equals(null)
                         select adoption.Returned)
                        .Contains(false);
                    if (result != null)
                        return result;
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static int? TotalAnimalIncidents(int animalID)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from incident in db.Incidents
                         where incident.AnimalID.Equals(animalID) && incident.IsDeleted.Equals(null)
                         select incident)
                        .Count();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? TotalAnimalMedicalRecords(int animalID)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from record in db.MedicalRecords
                         where record.AnimalID.Equals(animalID) && record.IsDeleted.Equals(null)
                         select record)
                        .Count();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? TotalAnimalEscapes(int animalID)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from escape in db.Escapes
                         where escape.AnimalID.Equals(animalID) && escape.IsDeleted.Equals(null)
                         select escape)
                        .Count();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? TotalAnimalWalks(int animalID)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from walk in db.Walks
                         where walk.AnimalID.Equals(animalID) && walk.IsDeleted.Equals(null)
                         select walk)
                        .Count();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? DatedCosts(DateTime since, DateTime to)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from cost in db.Costs
                         where (cost.Date >= since) && (cost.Date <= to) && cost.IsDeleted.Equals(null)
                         select cost.Price)
                        .Sum();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? TotalDonations()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from donation in db.Donations
                         where donation.IsDeleted.Equals(null)
                         select donation.Amount)
                        .Sum();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? DatedDonations(DateTime since, DateTime to)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from donation in db.Donations
                         where (donation.Date >= since) && (donation.Date <= to) && donation.IsDeleted.Equals(null)
                         select donation.Amount)
                        .Sum();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? DatedEscapes(DateTime since, DateTime to)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from escape in db.Escapes
                         where (escape.Date >= since) && (escape.Date <= to) && escape.IsDeleted.Equals(null)
                         select escape)
                        .Count();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? DatedWalks(DateTime since, DateTime to)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from walk in db.Walks
                         where (walk.Date >= since) && (walk.Date <= to) && walk.IsDeleted.Equals(null)
                         select walk)
                        .Count();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? DatedIntakes(DateTime since, DateTime to)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from stay in db.Stays
                         where (stay.StartDate >= since) && (stay.StartDate <= to) && stay.IsDeleted.Equals(null)
                         select stay)
                        .Count();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? DatedIncidents(DateTime since, DateTime to)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from incident in db.Incidents
                         where (incident.IncidentDate >= since) && (incident.IncidentDate <= to) && incident.IsDeleted.Equals(null)
                         select incident)
                        .Count();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? DatedMedicalRecords(DateTime since, DateTime to)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from record in db.MedicalRecords
                         where (record.Date >= since) && (record.Date <= to) && record.IsDeleted.Equals(null)
                         select record)
                        .Count();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? DatedDeaths(DateTime since, DateTime to)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from stay in db.Stays
                         where (stay.FinishDate >= since) && (stay.FinishDate <= to) && stay.IsDeleted.Equals(null) && stay.Died.Equals(true)
                         select stay)
                        .Count();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? DatedAdoptions(DateTime since, DateTime to)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from adoption in db.Adoptions
                         where (adoption.Date >= since) && (adoption.Date <= to) && adoption.IsDeleted.Equals(null)
                         select adoption)
                        .Count();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? DatedNotReturned(DateTime since, DateTime to)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from adoption in db.Adoptions
                         where (adoption.Date >= since) && (adoption.Date <= to) && adoption.IsDeleted.Equals(null) && adoption.Returned.Equals(false)
                         select adoption)
                        .Count();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public static int? DatedReturned(DateTime since, DateTime to)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    int? total =
                        (from adoption in db.Adoptions
                         where (adoption.ReturnDate >= since) && (adoption.ReturnDate <= to) && adoption.IsDeleted.Equals(null)
                         select adoption)
                        .Count();
                    if (total != null)
                        return total;
                    else
                        return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
    }
}
