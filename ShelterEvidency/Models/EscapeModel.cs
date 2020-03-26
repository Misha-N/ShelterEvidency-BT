using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.WrappingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class EscapeModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int AnimalID { get; set; }

        #endregion

        public static void CreateEscape(int animalID, DateTime date, string description)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                Escapes escape = new Escapes
                {
                    AnimalID = animalID,
                    Date = date,
                    Description = description,
                };
                db.Escapes.InsertOnSubmit(escape);
                db.SubmitChanges();

            }
        }

        public static BindableCollection<EscapeInfo> GetDatedEscapes(DateTime? since, DateTime? to)
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


        public static void MarkAsDeleted(int id)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var escape = db.Escapes.Single(x => x.Id == id);
                escape.IsDeleted = true;
                db.SubmitChanges();
            }
        }
    }
}
