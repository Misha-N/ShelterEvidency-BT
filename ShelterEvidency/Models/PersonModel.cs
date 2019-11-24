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
        public int? RoleID { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Note { get; set; }
        #endregion

        public void SavePerson()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
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

        public static List<PersonInfo> ReturnPeople()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from person in db.People
                               select new PersonInfo
                               {
                                   ID = person.Id,
                                   TitledFullName = person.Title.Trim() + " " + person.FirstName + " " + person.LastName,
                                   /*
                                   Title = person.Title,
                                   FirstName = person.FirstName,
                                   LastName = person.LastName,
                                   */
                                   Role = person.Roles.RoleName,
                                   Phone = person.Phone,
                                   Mail = person.Mail,
                                   Note = person.Note,

                               }).ToList();
                return results;
            }
        }


        public static List<PersonInfo> ReturnSpecificPeople(string searchValue)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from person in db.People
                               where ((person.LastName.Contains(searchValue)) ||
                                      (person.Id.ToString().Equals(searchValue)) ||
                                      (person.Roles.RoleName.Contains(searchValue)))
                               select new PersonInfo
                               {
                                   ID = person.Id,
                                   TitledFullName = person.Title.Trim() + " " + person.FirstName + " " + person.LastName,
                                   /*
                                   Title = person.Title,
                                   FirstName = person.FirstName,
                                   LastName = person.LastName,
                                   */
                                   Phone = person.Phone,
                                   Mail = person.Mail,
                                   Note = person.Note,
                               }).ToList();
                return results;
            }
        }

        public void GetPerson(int personID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var person = db.People.FirstOrDefault(i => i.Id == personID);
                if (person != null)
                {
                    ID = person.Id;
                    Title = person.Title;
                    FirstName = person.FirstName;
                    LastName = person.LastName;
                    RoleID = person.RoleID;
                    Phone = person.Phone;
                    Mail = person.Mail;
                    Note = person.Note;
                }
            }
        }

        public void UpdatePerson()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                People person = db.People.FirstOrDefault(i => i.Id == ID);

                person.Title = Title;
                person.FirstName = FirstName;
                person.LastName = LastName;
                person.RoleID = RoleID;
                person.Phone = Phone;
                person.Mail = Mail;
                person.Note = Note;

                db.SubmitChanges();
            }
        }

        public static List<PersonInfo> ReturnVets()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from person in db.People
                               where ((person.RoleID.Equals(2)))
                               select new PersonInfo
                               {
                                   ID = person.Id,
                                   TitledFullName = person.Title.Trim() + " " + person.FirstName + " " + person.LastName,
                                   /*
                                   Title = person.Title,
                                   FirstName = person.FirstName,
                                   LastName = person.LastName,
                                   */
                                   Phone = person.Phone,
                                   Mail = person.Mail,
                                   Note = person.Note,
                               }).ToList();
                return results;
            }
        }

        public static List<PersonInfo> ReturnWalkers()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from person in db.People
                               where ((person.RoleID.Equals(5)))
                               select new PersonInfo
                               {
                                   ID = person.Id,
                                   TitledFullName = person.Title.Trim() + " " + person.FirstName + " " + person.LastName,
                                   /*
                                   Title = person.Title,
                                   FirstName = person.FirstName,
                                   LastName = person.LastName,
                                   */
                                   Phone = person.Phone,
                                   Mail = person.Mail,
                                   Note = person.Note,
                               }).ToList();
                return results;
            }
        }

        public static List<PersonInfo> ReturnOwners()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from person in db.People
                               where ((person.RoleID.Equals(1)))
                               select new PersonInfo
                               {
                                   ID = person.Id,
                                   TitledFullName = person.Title.Trim() + " " + person.FirstName + " " + person.LastName,
                                   /*
                                   Title = person.Title,
                                   FirstName = person.FirstName,
                                   LastName = person.LastName,
                                   */
                                   Phone = person.Phone,
                                   Mail = person.Mail,
                                   Note = person.Note,
                               }).ToList();
                return results;
            }
        }
    }
}
