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
        #region Initialization

        public AnimalModel Animal { get; set; }
        public PersonModel Owner { get; set; }
        public AdoptionModel Adoption { get; set; }

        private readonly AdoptionsViewModel prnt;
        public CreateAdoptionViewModel(AdoptionsViewModel parent)
        {
            prnt = parent;
            Animal = new AnimalModel();
            Owner = new PersonModel();
            Adoption = new AdoptionModel();
        }


        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            Task.Run(() => LoadData());
        }


        private async Task LoadData()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                Animals = AnimalModel.ReturnAnimalsInShelter();
                Owners = PersonModel.ReturnOwners();
                SelectedAnimal = Animals.FirstOrDefault();
                SelectedOwner = Owners.FirstOrDefault();
            });
            IsWorking = false;
        }

        private volatile bool _isWorking;
        public bool IsWorking
        {
            get
            {
                return _isWorking;
            }
            set
            {
                _isWorking = value;
                NotifyOfPropertyChange(() => IsWorking);
            }
        }

        #endregion

        #region List setting

        private BindableCollection<AnimalInfo> _animals;

        public BindableCollection<AnimalInfo> Animals
        {
            get
            {
                return _animals;
            }
            set
            {
                _animals = value;
                NotifyOfPropertyChange(() => Animals);
            }
        }

        private BindableCollection<PersonInfo> _owners;

        public BindableCollection<PersonInfo> Owners
        {
            get
            {
                return _owners;
            }
            set
            {
                _owners = value;
                NotifyOfPropertyChange(() => Owners);
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
                NotifyOfPropertyChange(() => SelectedAnimal);
                AnimalSelection();
            }
        }


        private void OwnerSelection()
        {
            if(SelectedOwner != null)
            {
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => Phone);
                NotifyOfPropertyChange(() => Mail);
                NotifyOfPropertyChange(() => City);
                NotifyOfPropertyChange(() => Street);
                NotifyOfPropertyChange(() => Zip);
            }
        }
        
        private void AnimalSelection()
        {
            if (SelectedAnimal != null)
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
        }

        #region Binded Animal Properties

        public int? ID
        {
            get
            {
                if (SelectedAnimal != null)
                    return SelectedAnimal.ID;
                else
                    return null;
            }

        }

        public string AnimalName
        {
            get
            {
                if (SelectedAnimal != null)
                    return SelectedAnimal.Name;
                else
                    return null;
            }

        }
        public string ChipNumber
        {
            get
            {
                if (SelectedAnimal != null)
                    return SelectedAnimal.ChipNumber;
                else
                    return null;
            }
        }
        public string Sex
        {
            get
            {
                if (SelectedAnimal != null)
                    return SelectedAnimal.Sex;
                else
                    return null;
            }
        }
        public string Species
        {
            get
            {
                if (SelectedAnimal != null)
                    return SelectedAnimal.Species;
                else
                    return null;
            }
        }
        public string Breed
        {
            get
            {
                if (SelectedAnimal != null)
                    return SelectedAnimal.Breed;
                else
                    return null;
            }
        }

        public DateTime? BirthDate
        {
            get
            {
                if (SelectedAnimal != null)
                    return SelectedAnimal.BirthDate;
                else
                    return null;
            }
        }
        public string CoatType
        {
            get
            {
                if (SelectedAnimal != null)
                    return SelectedAnimal.CoatType;
                else
                    return null;
            }
        }
        public string FurColor
        {
            get
            {
                if (SelectedAnimal != null)
                    return SelectedAnimal.FurColor;
                else
                    return null;
            }
        }

        #endregion

        #region Binded Owner Properties

        public string FullName
        {
            get
            {
                if (SelectedOwner != null)
                    return SelectedOwner.TitledFullName;
                else
                    return null;
            }
        }
        public string Phone
        {
            get
            {
                if (SelectedOwner != null)
                    return SelectedOwner.Phone;
                else
                    return null;
            }
        }

        public string Mail
        {
            get
            {
                if (SelectedOwner != null)
                    return SelectedOwner.Mail;
                else
                    return null;
            }
        }

        public string City
        {
            get
            {
                if (SelectedOwner != null)
                    return SelectedOwner.AdressCity;
                else
                    return null;
            }
        }

        public string Street
        {
            get
            {
                if (SelectedOwner != null)
                    return SelectedOwner.AdressStreet;
                else
                    return null;
            }

        }
        public string Zip
        {
            get
            {
                if (SelectedOwner != null)
                    return SelectedOwner.AdressZip;
                else
                    return null;
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
                NotifyOfPropertyChange(() => AdoptionDate);
            }
        }

        public bool CanCreate()
        {
            if (AdoptionDate != null)
                return true;
            else
                return false;
        }

        public void CreateNewAdoption()
        {
            if (AdoptionDate != null)
            {
                IsWorking = true;

                Owner.GetPerson(SelectedOwner.ID);
                Adoption.PersonID = SelectedOwner.ID;

                Animal.GetAnimal((int)SelectedAnimal.ID);
                Adoption.AnimalID = SelectedAnimal.ID;

                Animal.Adopt(SelectedOwner.ID);
                Adoption.SaveAdoption();

                DocumentManager.CreateAdoptionList(Animal, Owner, Adoption);
                prnt.UpdateAdoptions();

                IsWorking = false;
                TryClose();
            }
            else
                MessageBox.Show("Vyplňte prosím datum adopce.");
        }

        public void Cancel()
        {
            TryClose();
        }

    }
}
