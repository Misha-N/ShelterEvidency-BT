using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class CoatTypeModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string CoatTypeName { get; set; }
        #endregion


        public static List<CoatTypes> ReturnCoatTypes()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.CoatTypes.ToList();
        }

        public void SaveCoatType()
        {
            if (CoatTypeName != null)
            {
                ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
                CoatTypes coatType = new CoatTypes
                {
                    CoatTypeName = CoatTypeName
                };
                db.CoatTypes.InsertOnSubmit(coatType);
                db.SubmitChanges();

                ID = coatType.Id;
            }

        }
    }
}
