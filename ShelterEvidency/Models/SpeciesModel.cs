using Caliburn.Micro;
using ShelterEvidency.Database;
using System;
using System.Linq;
using System.Windows;

namespace ShelterEvidency.Models
{
    public class SpeciesModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string SpeciesName { get; set; }
        #endregion

        public static BindableCollection<Species> ReturnSpecies()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    return new BindableCollection<Species>(db.Species.Where(x => x.IsDeleted.Equals(null)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<Species>();
            }
        }


        public void SaveSpecies()
        {
            try 
            { 
                if (SpeciesName != null)
                {
                    using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                    {
                        Species species = new Species
                        {
                            SpeciesName = SpeciesName,
                            IsDeleted = null
                        };
                        db.Species.InsertOnSubmit(species);
                        db.SubmitChanges();

                        ID = species.Id;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static void MarkAsDeleted(int id)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var species = db.Species.Single(x => x.Id == id);
                    species.IsDeleted = DateTime.Now;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void RestoreDeleted(DateTime since, DateTime to)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var records = (from record in db.Species
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
