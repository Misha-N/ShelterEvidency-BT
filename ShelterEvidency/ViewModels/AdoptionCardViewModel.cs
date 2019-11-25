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
    public class AdoptionCardViewModel: Screen
    {
        public AdoptionModel Adoption { get; set; }
        public AnimalInfo Animal { get; set; }
        public PersonInfo Person { get; set; }

        public AdoptionCardViewModel(int adoptionID)
        {
            Adoption = new AdoptionModel();
            Adoption.GetAdoption(adoptionID);
            Animal = new AnimalInfo();
            Animal = AnimalModel.GetAnimalInfo(Adoption.AnimalID);
            Person = new PersonInfo();
            Person = PersonModel.GetPersonInfo(Adoption.PersonID);

        }

        #region Binded Animal Properties

        public int? ID
        {
            get
            {
                    return Animal.ID;
            }
        }

        public string AnimalName
        {
            get
            {
                    return Animal.Name;
            }

        }
        public string ChipNumber
        {
            get
            {
                    return Animal.ChipNumber;
            }

        }
        public string Sex
        {
            get
            {
                    return Animal.Sex;
            }

        }
        public string Species
        {
            get
            {
                    return Animal.Species;
            }
        }
        public string Breed
        {
            get
            {
                    return Animal.Breed;
            }

        }

        public DateTime? BirthDate
        {
            get
            {
                    return Animal.BirthDate;
            }

        }
        public string CoatType
        {
            get
            {
                    return Animal.CoatType;
            }

        }
        public string FurColor
        {
            get
            {
                    return Animal.FurColor;
            }

        }

        #endregion

        #region Binded Owner Properties

        public string FullName
        {
            get
            {
                    return Person.TitledFullName;
            }

        }
        public string Phone
        {
            get
            {
                    return Person.Phone;
            }

        }

        public string Mail
        {
            get
            {
                    return Person.Mail;
            }

        }

        public string City
        {
            get
            {
                    return Person.AdressCity;
            }
        }

        public string Street
        {
            get
            {
                    return Person.AdressStreet;
            }
        }
        public string Zip
        {
            get
            {
                    return Person.AdressZip;
            }
        }

        #endregion

        public bool? Returned
        {
            get
            {
                return Adoption.Returned;
            }
            set
            {
                Adoption.Returned = value;
                NotifyOfPropertyChange(() => Returned);
            }
        }

        public DateTime? ReturnDate
        {
            get
            {
                return Adoption.ReturnDate;
            }
            set
            {
                Adoption.ReturnDate = value;
                NotifyOfPropertyChange(() => Returned);
            }
        }

        public string ReturnReason
        {
            get
            {
                return Adoption.ReturnReason;
            }
            set
            {
                Adoption.ReturnReason = value;
                NotifyOfPropertyChange(() => Returned);
            }
        }

        public void SaveToDatabase()
        {
            Adoption.UpdateAdoption();
            MessageBox.Show("updated");
            TryClose();
        }
    }
}
