using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.WrappingClasses;
using System;
using System.Linq;
using System.Windows;

namespace ShelterEvidency.Models
{
    class DeathModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int AnimalID { get; set; }
        public bool Euthanasia { get; set; }
        public bool Natural { get; set; }
        public bool Other { get; set; }

        #endregion

        public void CreateDeath()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    Deaths death = new Deaths
                    {
                        AnimalID = AnimalID,
                        Date = Date,
                        Description = Description,
                        Euthanasia = Euthanasia,
                        Natural = Natural,
                        Other = Other
                    };
                    db.Deaths.InsertOnSubmit(death);
                    db.SubmitChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static BindableCollection<DeathInfo> GetDatedDeaths(DateTime? since, DateTime? to)
        {
            try
            {

                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {

                    var results = (from death in db.Deaths
                                   where (death.Date >= since && death.Date <= to) && (death.IsDeleted.Equals(null))
                                   select new DeathInfo
                                   {
                                       ID = death.Id,
                                       Date = death.Date,
                                       AnimalID = death.AnimalID,
                                       AnimalName = death.Animals.Name,
                                       Description = death.Description,
                                       Euthanasia = death.Euthanasia,
                                       Natural = death.Natural,
                                       Other = death.Other,
                                   });
                    return new BindableCollection<DeathInfo>(results);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<DeathInfo>();
            }
        }


        public static void MarkAsDeleted(int id)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var death = db.Deaths.Single(x => x.Id == id);
                    death.IsDeleted = DateTime.Now;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool ValidValues()
        {
            if (AnimalModel.GetAnimalInfo(AnimalID) != null)
                return true;
            else
                return false;
        }

        public static void RestoreDeleted(DateTime since, DateTime to)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var records = (from record in db.Deaths
                                   where record.IsDeleted >= since && record.IsDeleted <= to
                                   select record).ToList();

                    foreach (var record in records)
                    {
                        record.IsDeleted = null;
                    }


                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
