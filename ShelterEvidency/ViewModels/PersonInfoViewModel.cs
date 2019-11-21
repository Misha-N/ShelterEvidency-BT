using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    public class PersonInfoViewModel: Screen
    {
        public PersonModel Person { get; set; }
        public AdressModel Adress { get; set; }
        public PersonInfoViewModel(int personID)
        {
            Person = new PersonModel();
            Person.GetPerson(personID);
            Adress = new AdressModel();
            Adress.GetAdress(personID);

        }

        #region Binded Properties
       
        public int ID
        {
            get
            {
                return Person.ID;
            }
            set
            {
                Person.ID = value;
                NotifyOfPropertyChange(() => ID);
            }
        }
        public string FirstName
        {
            get
            {
                return Person.FirstName;
            }
            set
            {
                Person.FirstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }
        public string LastName
        {
            get
            {
                return Person.LastName;
            }
            set
            {
                Person.LastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }
        public int? RoleID
        {
            get
            {
                return Person.RoleID;
            }
            set
            {
                Person.RoleID = value;
                NotifyOfPropertyChange(() => RoleID);
            }
        }
        public string Title
        {
            get
            {
                return Person.Title;
            }
            set
            {
                Person.Title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }
        public string Phone
        {
            get
            {
                return Person.Phone;
            }
            set
            {
                Person.Phone = value;
                NotifyOfPropertyChange(() => Phone);
            }
        }

        public string Mail
        {
            get
            {
                return Person.Mail;
            }
            set
            {
                Person.Mail = value;
                NotifyOfPropertyChange(() => Mail);
            }
        }
        public string Note
        {
            get
            {
                return Person.Note;
            }
            set
            {
                Person.Note = value;
                NotifyOfPropertyChange(() => Note);
            }
        }
       
        #endregion

        #region List Setting
        public List<Database.Roles> RoleList
        {
            get
            {
                return RoleModel.ReturnRoles();
            }
        }

        #endregion

        #region Adress Binded Atributes  
        public string City
        {
            get
            {
                return Adress.City;
            }
            set
            {
                Adress.City = value;
                NotifyOfPropertyChange(() => City);
            }
        }

        public string Street
        {
            get
            {
                return Adress.Street;
            }
            set
            {
                Adress.Street = value;
                NotifyOfPropertyChange(() => Street);
            }
        }

        public int? Zip
        {
            get
            {
                return Adress.Zip;
            }
            set
            {
                Adress.Zip = value;
                NotifyOfPropertyChange(() => Zip);
            }
        }
        #endregion

        public void UpdatePerson()
        {
            Person.UpdatePerson();
            Adress.UpdateAdress();
            MessageBox.Show("ok");
        }

        public void Cancel()
        {
            TryClose();
        }

    }
}

