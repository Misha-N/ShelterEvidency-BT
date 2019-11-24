using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class EndTypeModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string EndTypeName { get; set; }
        #endregion

        public static  List<EndTypes> ReturnEndTypes()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                return db.EndTypes.ToList();
            }
        }


    }
}
