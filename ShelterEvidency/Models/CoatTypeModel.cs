using Caliburn.Micro;
using ShelterEvidency.Database;
using System;
using System.Linq;
using System.Windows;

namespace ShelterEvidency.Models
{
    public class CoatTypeModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string CoatTypeName { get; set; }
        #endregion


        public static BindableCollection<CoatTypes> ReturnCoatTypes()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    return new BindableCollection<CoatTypes>(db.CoatTypes.Where(x => x.IsDeleted.Equals(null)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<CoatTypes>();
            }
        }

        public void SaveCoatType()
        {
            if (CoatTypeName != null)
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    CoatTypes coatType = new CoatTypes
                    {
                        CoatTypeName = CoatTypeName,
                        IsDeleted = null
                    };
                    db.CoatTypes.InsertOnSubmit(coatType);
                    db.SubmitChanges();

                    ID = coatType.Id;
                }
            }

        }

        public static void MarkAsDeleted(int id)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var coatType = db.CoatTypes.Single(x => x.Id == id);
                coatType.IsDeleted = DateTime.Now;
                db.SubmitChanges();
            }
        }

        public static void RestoreDeleted(DateTime since, DateTime to)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var records = (from record in db.CoatTypes
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
