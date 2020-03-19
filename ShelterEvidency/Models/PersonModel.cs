using Caliburn.Micro;
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
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Note { get; set; }
        public string AdressCity { get; set; }
        public string AdressStreet { get; set; }
        public string AdressZip { get; set; }
        public bool? IsOwner { get; set; }
        public bool? IsVet { get; set; }
        public bool? IsWalker { get; set; }
        public bool? IsSponsor { get; set; }
        public bool? IsVolunteer { get; set; }
        #endregion

        public PersonModel()
        {
            Title = null;
            FirstName = null;
            LastName = null;
            Phone = null;
            Mail = null;
            Note = null;
            AdressCity = null;
            AdressStreet = null;
            AdressZip = null;
            Title = null;
            IsOwner = false;
            IsSponsor = false;
            IsVet = false;
            IsWalker = false;
            IsVolunteer = false;
        }

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
                    AdressCity = AdressCity,
                    AdressStreet = AdressStreet,
                    AdressZip = AdressZip,
                    IsOwner = IsOwner,
                    IsVet = IsVet,
                    IsWalker = IsWalker,
                    IsSponsor = IsSponsor,
                    IsVolunteer = IsVolunteer

                };
                db.People.InsertOnSubmit(person);
                db.SubmitChanges();

                ID = person.Id;
            }

        }

        public static BindableCollection<PersonInfo> ReturnPeople()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from person in db.People
                               select new PersonInfo
                               {
                                   ID = person.Id,
                                   Title = person.Title,
                                   FirstName = person.FirstName,
                                   LastName = person.LastName,
                                   Phone = person.Phone,
                                   Mail = person.Mail,
                                   Note = person.Note,
                                   AdressCity = person.AdressCity,
                                   AdressStreet = person.AdressStreet,
                                   AdressZip = person.AdressZip,
                                   IsOwner = person.IsOwner,
                                   IsVet = person.IsVet,
                                   IsWalker = person.IsWalker,
                                   IsSponsor = person.IsSponsor,
                                   IsVolunteer = person.IsVolunteer

                               });

                return new BindableCollection<PersonInfo>(results);
            }
        }


        public static BindableCollection<PersonInfo> ReturnSpecificPeople(string searchValue)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from person in db.People
                               where ((person.LastName.Contains(searchValue)) ||
                                      (person.Id.ToString().Equals(searchValue)))
                               select new PersonInfo
                               {
                                   ID = person.Id,
                                   Title = person.Title,
                                   FirstName = person.FirstName,
                                   LastName = person.LastName,
                                   Phone = person.Phone,
                                   Mail = person.Mail,
                                   Note = person.Note,
                                   AdressCity = person.AdressCity,
                                   AdressStreet = person.AdressStreet,
                                   AdressZip = person.AdressZip,
                                   IsOwner = person.IsOwner,
                                   IsVet = person.IsVet,
                                   IsWalker = person.IsWalker,
                                   IsSponsor = person.IsSponsor,
                                   IsVolunteer = person.IsVolunteer
                               });

                return new BindableCollection<PersonInfo>(results);
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
                    Phone = person.Phone;
                    Mail = person.Mail;
                    Note = person.Note;
                    AdressCity = person.AdressCity;
                    AdressStreet = person.AdressStreet;
                    AdressZip = person.AdressZip;
                    IsOwner = person.IsOwner;
                    IsVet = person.IsVet;
                    IsWalker = person.IsWalker;
                    IsSponsor = person.IsSponsor;
                    IsVolunteer = person.IsVolunteer;
                }
            }
        }

        public static PersonInfo GetPersonInfo(int? personID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var person = db.People.FirstOrDefault(i => i.Id == personID);
                if (person != null)
                {
                    PersonInfo info = new PersonInfo
                    {
                        ID = person.Id,
                        Title = person.Title,
                        FirstName = person.FirstName,
                        LastName = person.LastName,
                        Phone = person.Phone,
                        Mail = person.Mail,
                        Note = person.Note,
                        AdressCity = person.AdressCity,
                        AdressStreet = person.AdressStreet,
                        AdressZip = person.AdressZip,
                        IsOwner = person.IsOwner,
                        IsVet = person.IsVet,
                        IsWalker = person.IsWalker,
                        IsSponsor = person.IsSponsor,
                        IsVolunteer = person.IsVolunteer
                    };
                    return info;
                }
                else
                    return new PersonInfo();
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
                person.Phone = Phone;
                person.Mail = Mail;
                person.Note = Note;
                person.AdressCity = AdressCity;
                person.AdressStreet = AdressStreet;
                person.AdressZip = AdressZip;
                person.IsOwner = IsOwner;
                person.IsSponsor = IsSponsor;
                person.IsVet = IsVet;
                person.IsWalker = IsWalker;
                person.IsVolunteer = IsVolunteer;

                db.SubmitChanges();
            }
        }

        public static BindableCollection<PersonInfo> ReturnVets()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from person in db.People
                               where ((person.IsVet.Equals(true)))
                               select new PersonInfo
                               {
                                   ID = person.Id,
                                   Title = person.Title,
                                   FirstName = person.FirstName,
                                   LastName = person.LastName,
                                   Phone = person.Phone,
                                   Mail = person.Mail,
                                   Note = person.Note,
                                   AdressCity = person.AdressCity,
                                   AdressStreet = person.AdressStreet,
                                   AdressZip = person.AdressZip,
                                   IsOwner = person.IsOwner,
                                   IsVet = person.IsVet,
                                   IsWalker = person.IsWalker,
                                   IsSponsor = person.IsSponsor,
                                   IsVolunteer = person.IsVolunteer
                               }).ToList();
                return new BindableCollection<PersonInfo>(results);
            }
        }

        public static List<PersonInfo> ReturnDonators()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from person in db.People
                               where ((person.IsSponsor.Equals(true)))
                               select new PersonInfo
                               {
                                   ID = person.Id,
                                   Title = person.Title,
                                   FirstName = person.FirstName,
                                   LastName = person.LastName,
                                   Phone = person.Phone,
                                   Mail = person.Mail,
                                   Note = person.Note,
                                   AdressCity = person.AdressCity,
                                   AdressStreet = person.AdressStreet,
                                   AdressZip = person.AdressZip,
                                   IsOwner = person.IsOwner,
                                   IsVet = person.IsVet,
                                   IsWalker = person.IsWalker,
                                   IsSponsor = person.IsSponsor,
                                   IsVolunteer = person.IsVolunteer
                               }).ToList();
                return results;
            }
        }

        public static List<PersonInfo> ReturnWalkers()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from person in db.People
                               where ((person.IsWalker.Equals(true)))
                               select new PersonInfo
                               {
                                   ID = person.Id,
                                   Title = person.Title,
                                   FirstName = person.FirstName,
                                   LastName = person.LastName,
                                   Phone = person.Phone,
                                   Mail = person.Mail,
                                   Note = person.Note,
                                   AdressCity = person.AdressCity,
                                   AdressStreet = person.AdressStreet,
                                   AdressZip = person.AdressZip,
                                   IsOwner = person.IsOwner,
                                   IsVet = person.IsVet,
                                   IsWalker = person.IsWalker,
                                   IsSponsor = person.IsSponsor,
                                   IsVolunteer = person.IsVolunteer
                               }).ToList();
                return results;
            }
        }

        public static BindableCollection<PersonInfo> ReturnOwners()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from person in db.People
                               where ((person.IsOwner.Equals(true)))
                               select new PersonInfo
                               {
                                   ID = person.Id,
                                   Title = person.Title,
                                   FirstName = person.FirstName,
                                   LastName = person.LastName,
                                   Phone = person.Phone,
                                   Mail = person.Mail,
                                   Note = person.Note,
                                   AdressCity = person.AdressCity,
                                   AdressStreet = person.AdressStreet,
                                   AdressZip = person.AdressZip,
                                   IsOwner = person.IsOwner,
                                   IsVet = person.IsVet,
                                   IsWalker = person.IsWalker,
                                   IsSponsor = person.IsSponsor,
                                   IsVolunteer = person.IsVolunteer
                               });
                return new BindableCollection<PersonInfo>(results);
            }
        }
    }
}
