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
                    return new BindableCollection<FurColors>(db.FurColors.Where(x => x.IsDeleted.Equals(false)));
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
                            IsDeleted = false
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
                    furColor.IsDeleted = true;
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
