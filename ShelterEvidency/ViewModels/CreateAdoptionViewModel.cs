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
    public class CreateAdoptionViewModel: Screen
    {
        public AnimalModel Animal { get; set; }
        public PersonModel Owner { get; set; }
        public AdoptionModel Adoption { get; set; }

        private readonly AdoptionsViewModel prnt;
        public CreateAdoptionViewModel(AdoptionsViewModel parent)
        {
            prnt = parent;
            //SelectedAnimal = Animals.FirstOrDefault();
            SelectedOwner = Owners.FirstOrDefault();
            Animal = new AnimalModel();
            Owner = new PersonModel();
            Adoption = new AdoptionModel();
        }

        #region List setting
        /*
        public Binda<AnimalInfo> Animals
        {
            get
            {
                    return AnimalModel.ReturnAnimals();
            }
        }
        */
        public List<PersonInfo> Owners
        {
            get
            {
                    return PersonModel.ReturnOwners();
            }
        }
        #endregion

        private PersonInfo _selectedOwner;

        public PersonInfo SelectedOwner
        {
            get
            {
                return _selectedOwner;
            }
            set
            {
                _selectedOwner = value;
                NotifyOfPropertyChange(() => SelectedOwner);
                OwnerSelection();
            }
        }

        private AnimalInfo _selectedAnimal;

        public AnimalInfo SelectedAnimal
        {
            get
            {
                 return _selectedAnimal;
            }
            set
            {
                _selectedAnimal = value;
                AnimalSelection();
            }
        }


        private void OwnerSelection()
        {
            NotifyOfPropertyChange(() => FullName);
            NotifyOfPropertyChange(() => Phone);
            NotifyOfPropertyChange(() => Mail);
            NotifyOfPropertyChange(() => City);
            NotifyOfPropertyChange(() => Street);
            NotifyOfPropertyChange(() => Zip);
        }
        
        private void AnimalSelection()
        {
            NotifyOfPropertyChange(() => ID);
            NotifyOfPropertyChange(() => AnimalName);
            NotifyOfPropertyChange(() => ChipNumber);
            NotifyOfPropertyChange(() => Species);
            NotifyOfPropertyChange(() => Sex);
            NotifyOfPropertyChange(() => Breed);
            NotifyOfPropertyChange(() => BirthDate);
            NotifyOfPropertyChange(() => CoatType);
            NotifyOfPropertyChange(() => FurColor);
        }

        #region Binded Animal Properties

        public int? ID
        {
            get
            {
                return SelectedAnimal.ID;
            }

        }

        public string AnimalName
        {
            get
            {
                 return SelectedAnimal.Name;
            }

        }
        public string ChipNumber
        {
            get
            {
                 return SelectedAnimal.ChipNumber;
            }
        }
        public string Sex
        {
            get
            {
                 return SelectedAnimal.Sex;
            }
        }
        public string Species
        {
            get
            {
                return SelectedAnimal.Species;
            }
        }
        public string Breed
        {
            get
            {
                 return SelectedAnimal.Breed;
            }
        }

        public DateTime? BirthDate
        {
            get
            {
                 return SelectedAnimal.BirthDate;
            }
        }
        public string CoatType
        {
            get
            {
                 return SelectedAnimal.CoatType;
            }
        }
        public string FurColor
        {
            get
            {
                 return SelectedAnimal.FurColor;
            }
        }

        #endregion

        #region Binded Owner Properties

        public string FullName
        {
            get
            {
                 return SelectedOwner.TitledFullName;
            }
        }
        public string Phone
        {
            get
            {
                return SelectedOwner.Phone;
            }
        }

        public string Mail
        {
            get
            {
                 return SelectedOwner.Mail;
            }
        }

        public string City
        {
            get
            {
                 return SelectedOwner.AdressCity;
            }
        }

        public string Street
        {
            get
            {
                 return SelectedOwner.AdressStreet;
            }

        }
        public string Zip
        {
            get
            {
                 return SelectedOwner.AdressZip;
            }
        }

        #endregion
        public DateTime? AdoptionDate
        {
            get
            {
                return Adoption.Date;
            }
            set
            {
                Adoption.Date = value;
                NotifyOfPropertyChange(() => Zip);
            }
        }

        public void CreateNewAdoption()
        {
            if (AdoptionDate != null)
            {
                Owner.GetPerson(SelectedOwner.ID);
                Adoption.PersonID = SelectedOwner.ID;

                Animal.GetAnimal((int)SelectedAnimal.ID);
                Adoption.AnimalID = SelectedAnimal.ID;

                Animal.Adopt(SelectedOwner.ID);
                Adoption.SaveAdoption();

                DocumentManager.CreateAdoptionList(Animal, Owner, Adoption);
                prnt.UpdateAdoptions();
                TryClose();
            }
            else
                MessageBox.Show("vyplňte datum adopce");
        }
    }
}
