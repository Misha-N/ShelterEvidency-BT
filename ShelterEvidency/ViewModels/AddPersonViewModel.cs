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
    public class AddPersonViewModel: Conductor<object>
    {
        public List<string> RoleList { get; private set; }

        public AddPersonViewModel()
        {
            SetRoleList();
            Person = new PersonModel();
        }

        private void SetRoleList()
        {
            RoleModel roleList = new RoleModel();
            RoleList = roleList.ReturnRoleList();
        }

        public void Cancel()
        {
            TryClose();
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

        public string Role
        {
            get
            {
                return Person.Role.RoleName;
            }
            set
            {
                Person.Role.RoleName = value;
                NotifyOfPropertyChange(() => Role);
            }
        }



        public string Adress
        {
            get
            {
                return Person.Adress;
            }
            set
            {
                Person.Adress = value;
                NotifyOfPropertyChange(() => Adress);
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

        private PersonModel _person;

        public PersonModel Person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
                NotifyOfPropertyChange(() => Person);

            }
        }



        public void SaveToDatabase()
        {
            Person.SavePerson();
            MessageBox.Show(Person.FirstName + " " + Person.LastName + " přidán do evidence.");
            TryClose();
        }







    }
}
