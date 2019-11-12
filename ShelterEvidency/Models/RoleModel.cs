using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class RoleModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string RoleName { get; set; }
        #endregion
        public static List<Roles> ReturnRoles()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.Roles.ToList();
        }
        public void SaveRole()
        {
            if (RoleName != null)
            {
                ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
                Roles role = new Roles
                {
                    RoleName = RoleName
                };
                db.Roles.InsertOnSubmit(role);
                db.SubmitChanges();

                ID = role.Id;
            }

        }
    }
}
