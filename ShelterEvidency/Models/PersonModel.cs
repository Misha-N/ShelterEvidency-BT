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
        #region Properties/Atributes
        public int ID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleID { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Note { get; set; }
        #endregion

        public void SavePerson()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();

            People person = new People
            {
                Title = Title,
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                Mail = Mail,
                Note = Note,
                RoleID = RoleID
            };
            db.People.InsertOnSubmit(person);
            db.SubmitChanges();

            ID = person.Id;

        }

    }
}
