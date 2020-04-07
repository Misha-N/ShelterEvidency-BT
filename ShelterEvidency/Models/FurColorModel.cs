using Caliburn.Micro;
using ShelterEvidency.Database;
using System;
using System.Linq;
using System.Windows;

namespace ShelterEvidency.Models
{
    public class FurColorModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string FurColorName { get; set; }
        #endregion
        public static BindableCollection<FurColors> ReturnFurColors()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    return new BindableCollection<FurColors>(db.FurColors.Where(x => x.IsDeleted.Equals(null)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<FurColors>();
            }
        }
        public void SaveFurColor()
        {
            try
            {
                if (FurColorName != null)
                {

                    using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                    {
                        FurColors furColor = new FurColors
                        {
                            FurColorName = FurColorName,
                            IsDeleted = null
                        };
                        db.FurColors.InsertOnSubmit(furColor);
                        db.SubmitChanges();

                        ID = furColor.Id;
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
                    var furColor = db.FurColors.Single(x => x.Id == id);
                    furColor.IsDeleted = DateTime.Now;
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
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var records = (from record in db.FurColors
                               where record.IsDeleted >= since && record.IsDeleted <= to
                               select record).ToList();

                foreach (var record in records)
                {
                    record.IsDeleted = null;
                }


                db.SubmitChanges();
            }
        }
    }
}
