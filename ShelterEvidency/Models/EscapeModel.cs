using ShelterEvidency.Database;
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
    }
}
