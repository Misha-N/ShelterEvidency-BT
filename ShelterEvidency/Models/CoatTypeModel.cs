using Caliburn.Micro;
using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    return new BindableCollection<CoatTypes>(db.CoatTypes.Where(x => x.IsDeleted.Equals(false)));
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
                        IsDeleted = false
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
                coatType.IsDeleted = true;
                db.SubmitChanges();
            }
        }
    }
}
