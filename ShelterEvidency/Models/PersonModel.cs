using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class PersonModel
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RoleModel Role { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Note { get; set; }
        public string Adress { get; set; }

        public PersonModel()
        {
            Role = new RoleModel();
        }

        public void SavePerson()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();

            People person = new People
            {
                Title = Title,
                FirstName = FirstName,
                LastName = LastName,
                Adress = Adress,
                Phone = Phone,
                Mail = Mail,
                Note = Note,
                RoleID = Role.NameToID()
            };
            db.People.InsertOnSubmit(person);
            db.SubmitChanges();

        }

    }
}
