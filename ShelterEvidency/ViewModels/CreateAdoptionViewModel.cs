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

        public CreateAdoptionViewModel()
        {
            Animal = new AnimalModel();
            Owner = new PersonModel();
            Adoption = new AdoptionModel();
            SelectedAnimal = new AnimalInfo();
            SelectedOwner = new PersonInfo();
        }

        #region List setting
        public List<AnimalInfo> Animals
        {
            get
            {
                    return AnimalModel.ReturnAnimals();
            }
        }
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
                NotifyOfPropertyChange(() => SelectedAnimal);
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
                if (SelectedAnimal == null)
                   return Animal.ID;
                else
                    return SelectedAnimal.ID;
            }
            set
            {
                SelectedAnimal.ID = value;
                NotifyOfPropertyChange(() => ID);
            }
        }
        
        public string AnimalName
        {
            get
            {
                if (SelectedAnimal == null)
                    return Animal.Name;
                else
                    return SelectedAnimal.Name;
            }
            set
            {
                SelectedAnimal.Name = value;
                NotifyOfPropertyChange(() => AnimalName);
            }
        }
        public string ChipNumber
        {
            get
            {
                if (SelectedAnimal == null)
                    return Animal.ChipNumber;
                else
                    return SelectedAnimal.ChipNumber;
            }
            set
            {
                SelectedAnimal.ChipNumber = value;
                NotifyOfPropertyChange(() => ChipNumber);
            }
        }
        public string Sex
        {
            get
            {
                if (SelectedAnimal == null)
                    return Animal.SexID.ToString();
                else
                    return SelectedAnimal.Sex;
            }
            set
            {
                SelectedAnimal.Sex = value;
                NotifyOfPropertyChange(() => Sex);
            }
        }
        public string Species
        {
            get
            {
                if (SelectedAnimal == null)
                    return Animal.SpeciesID.ToString();
                else
                    return SelectedAnimal.Species;
            }
            set
            {
                SelectedAnimal.Species = value;
                NotifyOfPropertyChange(() => Species);
            }
        }
        public string Breed
        {
            get
            {
                if (SelectedAnimal == null)
                    return Animal.BreedID.ToString();
                else
                    return SelectedAnimal.Breed;
            }
            set
            {
                SelectedAnimal.Breed = value;
                NotifyOfPropertyChange(() => Breed);
            }
        }

        public DateTime? BirthDate
        {
            get
            {
                if (SelectedAnimal == null)
                    return Animal.BirthDate;
                else
                    return SelectedAnimal.BirthDate;
            }
            set
            {
                SelectedAnimal.BirthDate = value;
                NotifyOfPropertyChange(() => BirthDate);
            }
        }
        public string CoatType
        {
            get
            {
                if (SelectedAnimal == null)
                    return Animal.CoatTypeID.ToString();
                else
                    return SelectedAnimal.CoatType;
            }
            set
            {
                SelectedAnimal.CoatType = value;
                NotifyOfPropertyChange(() => CoatType);
            }
        }
        public string FurColor
        {
            get
            {
                if (SelectedAnimal == null)
                    return Animal.FurColorID.ToString();
                else
                    return SelectedAnimal.FurColor;
            }
            set
            {
                SelectedAnimal.FurColor = value;
                NotifyOfPropertyChange(() => FurColor);
            }
        }

        #endregion

        #region Binded Owner Properties

        public string FullName
        {
            get
            {
                if (SelectedOwner == null)
                    return Owner.FirstName;
                else
                    return SelectedOwner.TitledFullName;
            }
            set
            {
                SelectedOwner.TitledFullName = value;
                NotifyOfPropertyChange(() => FullName);
            }
        }
        public string Phone
        {
            get
            {
                if (SelectedOwner == null)
                    return Owner.Phone;
                else
                    return SelectedOwner.Phone;
            }
            set
            {
                SelectedOwner.Phone = value;
                NotifyOfPropertyChange(() => Phone);
            }
        }

        public string Mail
        {
            get
            {
                if (SelectedOwner == null)
                    return Owner.Mail;
                else
                    return SelectedOwner.Mail;
            }
            set
            {
                SelectedOwner.Mail = value;
                NotifyOfPropertyChange(() => Mail);
            }
        }

        public string City
        {
            get
            {
                if (SelectedOwner == null)
                    return Owner.AdressCity;
                else
                    return SelectedOwner.AdressCity;
            }
            set
            {
                SelectedOwner.AdressCity = value;
                NotifyOfPropertyChange(() => City);
            }
        }

        public string Street
        {
            get
            {
                if (SelectedOwner == null)
                    return Owner.AdressStreet;
                else
                    return SelectedOwner.AdressStreet;
            }
            set
            {
                SelectedOwner.AdressStreet = value;
                NotifyOfPropertyChange(() => Street);
            }
        }
        public string Zip
        {
            get
            {
                if (SelectedOwner == null)
                    return Owner.AdressZip;
                else
                    return SelectedOwner.AdressZip;
            }
            set
            {
                SelectedOwner.AdressZip = value;
                NotifyOfPropertyChange(() => Zip);
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
                Adoption.SaveAdoption();
                DocumentManager.CreateAdoptionList(Animal, Owner, Adoption);
                TryClose();
            }
            else
                MessageBox.Show("vyplňte datum adopce");
        }
    }
}
