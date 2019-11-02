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
        public string RoleName { get; set; }

        public List<string> ReturnRoleList()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.Roles.Select(x => x.RoleName).ToList();
        }

        public List<Roles> ReturnRoles()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.Roles.ToList();
        }
        public int NameToID()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            var role = db.Roles.FirstOrDefault(i => i.RoleName == RoleName);
            return role.Id;
        }

        public string IDToName(int roleID)
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            var role = db.Roles.FirstOrDefault(i => i.Id == roleID);
            return role.RoleName;
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
            }

        }
    }
}
