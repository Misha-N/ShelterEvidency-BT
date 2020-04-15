using Caliburn.Micro;
using ShelterEvidency.Database;
using System;
using System.Linq;
using System.Windows;

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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public static BindableCollection<PersonInfo> ReturnPeople()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var results = (from person in db.People
                                   where person.IsDeleted.Equals(null)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<PersonInfo>();
            }
        }


        public static BindableCollection<PersonInfo> ReturnSpecificPeople(string searchValue)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var results = (from person in db.People
                                   where person.IsDeleted.Equals(null) && (person.LastName.Contains(searchValue) ||
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<PersonInfo>();
            }
        }

        public void GetPerson(int personID)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var person = db.People.FirstOrDefault(i => i.Id == personID && i.IsDeleted.Equals(null));
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static PersonInfo GetPersonInfo(int? personID)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new PersonInfo();
            }
        }

        public void UpdatePerson()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static BindableCollection<PersonInfo> ReturnVets()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var results = (from person in db.People
                                   where ((person.IsVet.Equals(true)) && person.IsDeleted.Equals(null))
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<PersonInfo>();
            }
        }

        public static BindableCollection<PersonInfo> ReturnDonators()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var results = (from person in db.People
                                   where ((person.IsSponsor.Equals(true)) && person.IsDeleted.Equals(null))
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<PersonInfo>();
            }
        }

        public static BindableCollection<PersonInfo> ReturnWalkers()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var results = (from person in db.People
                                   where ((person.IsWalker.Equals(true)) && person.IsDeleted.Equals(null))
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<PersonInfo>();
            }
        }

        public static BindableCollection<PersonInfo> ReturnOwners()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var results = (from person in db.People
                                   where ((person.IsOwner.Equals(true)) && person.IsDeleted.Equals(null))
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<PersonInfo>();
            }
        }

        public static void MarkAsDeleted(int id)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var person = db.People.Single(x => x.Id == id);
                    person.IsDeleted = DateTime.Now;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool ValidValues()
        {
            if (!String.IsNullOrEmpty(FirstName) && !String.IsNullOrEmpty(LastName))
                return true;
            else
                return false;
        }

        public static void RestoreDeleted(DateTime since, DateTime to)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var records = (from record in db.People
                               where record.IsDeleted >= since && record.IsDeleted <= to
                               select record).ToList();

                foreach (var record in records)
                {
                    record.IsDeleted = null;
                }


                db.SubmitChanges();
            }
        }
    }
}
