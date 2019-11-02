using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    class CoatTypeModel
    {
        public string CoatTypeName { get; set; }
        public List<string> ReturnCoatTypeList()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.CoatTypes.Select(x => x.CoatType).ToList();
        }

        public List<CoatTypes> ReturnCoatTypes()
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
                    CoatType = CoatTypeName
                };
                db.CoatTypes.InsertOnSubmit(coatType);
                db.SubmitChanges();
            }

        }
    }
}
