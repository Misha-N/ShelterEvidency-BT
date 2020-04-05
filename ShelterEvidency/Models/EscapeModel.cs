using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.WrappingClasses;
using System;
using System.Linq;
using System.Windows;

namespace ShelterEvidency.Models
{
    public class EscapeModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int AnimalID { get; set; }

        #endregion

        public void CreateEscape()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    Escapes escape = new Escapes
                    {
                        AnimalID = AnimalID,
                        Date = Date,
                        Description = Description,
                    };
                    db.Escapes.InsertOnSubmit(escape);
                    db.SubmitChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static BindableCollection<EscapeInfo> GetDatedEscapes(DateTime? since, DateTime? to)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {

                    var results = (from escape in db.Escapes
                                   where (escape.Date >= since && escape.Date <= to) && (escape.IsDeleted.Equals(false))
                                   select new EscapeInfo
                                   {
                                       ID = escape.Id,
                                       Date = escape.Date,
                                       AnimalID = escape.AnimalID,
                                       AnimalName = escape.Animals.Name,
                                       Description = escape.Description,
                                   });
                    return new BindableCollection<EscapeInfo>(results);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<EscapeInfo>();
            }
        }


        public static void MarkAsDeleted(int id)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var escape = db.Escapes.Single(x => x.Id == id);
                    escape.IsDeleted = true;
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
    }
}
