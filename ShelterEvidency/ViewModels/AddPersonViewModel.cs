using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    public class AddPersonViewModel: Conductor<object>
    {
        public PersonModel Person { get; set; }
        public AdressModel Adress { get; set; }
        public AddPersonViewModel()
        {
            SetRoleList();
            Adress = new AdressModel();
            Person = new PersonModel();
        }

        #region List Setting
        public List<Roles> RoleList { get; private set; }
        private void SetRoleList()
        {
            RoleList = RoleModel.ReturnRoles();
        }
        #endregion

        #region Person Binded Atributes
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
        public int Role
        {
            get
            {
                return Person.RoleID;
            }
            set
            {
                Person.RoleID = value;
                NotifyOfPropertyChange(() => Role);
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

        public int Zip
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
        public void SaveToDatabase()
        {
            Person.SavePerson();
            Adress.PersonID = Person.ID;
            Adress.SaveAdress();
            MessageBox.Show(Person.FirstName + " " + Person.LastName + " přidán do evidence.");
            TryClose();
        }

        public void Cancel()
        {
            TryClose();
        }

    }
}
