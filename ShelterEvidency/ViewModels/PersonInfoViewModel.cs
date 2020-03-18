﻿using Caliburn.Micro;
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
        public SearchPersonViewModel prnt { get; set; }
        public PersonInfoViewModel(int personID, SearchPersonViewModel vm)
        {
            prnt = vm;
            Person = new PersonModel();
            Person.GetPerson(personID);

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

        public string City
        {
            get
            {
                return Person.AdressCity;
            }
            set
            {
                Person.AdressCity = value;
                NotifyOfPropertyChange(() => City);
            }
        }

        public string Street
        {
            get
            {
                return Person.AdressStreet;
            }
            set
            {
                Person.AdressStreet = value;
                NotifyOfPropertyChange(() => Street);
            }
        }
        public string Zip
        {
            get
            {
                return Person.AdressZip;
            }
            set
            {
                Person.AdressZip = value;
                NotifyOfPropertyChange(() => Zip);
            }
        }

        public bool? IsOwner
        {
            get
            {
                return Person.IsOwner;
            }
            set
            {
                Person.IsOwner = value;
                NotifyOfPropertyChange(() => IsOwner);
            }
        }

        public bool? IsVet
        {
            get
            {
                return Person.IsVet;
            }
            set
            {
                Person.IsVet = value;
                NotifyOfPropertyChange(() => IsVet);
            }
        }

        public bool? IsWalker
        {
            get
            {
                return Person.IsWalker;
            }
            set
            {
                Person.IsWalker = value;
                NotifyOfPropertyChange(() => IsWalker);
            }
        }

        public bool? IsSponsor
        {
            get
            {
                return Person.IsSponsor;
            }
            set
            {
                Person.IsSponsor = value;
                NotifyOfPropertyChange(() => IsSponsor);
            }
        }

        public bool? IsVolunteer
        {
            get
            {
                return Person.IsVolunteer;
            }
            set
            {
                Person.IsVolunteer = value;
                NotifyOfPropertyChange(() => IsVolunteer);
            }
        }


        #endregion


        public void UpdatePerson()
        {
            Person.UpdatePerson();
            MessageBox.Show("ok");
        }

        public void Cancel()
        {
            TryClose();
        }

    }
}

