using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
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
                FullName = SelectedOwner.TitledFullName;
                Phone = SelectedOwner.Phone;
                Mail = SelectedOwner.Mail;
                City = SelectedOwner.AdressCity;
                Street = SelectedOwner.AdressStreet;
                Zip = SelectedOwner.AdressZip;
            }
        }
        
        private void AnimalSelection()
        {
            if (SelectedAnimal != null)
            {
                ID = SelectedAnimal.ID;
                AnimalName = SelectedAnimal.Name;
                ChipNumber = SelectedAnimal.ChipNumber;
                Species = SelectedAnimal.Species;
                Sex = SelectedAnimal.Sex;
                Breed = SelectedAnimal.Breed;
                BirthDate = SelectedAnimal.BirthDate;
                CoatType = SelectedAnimal.CoatType;
                FurColor = SelectedAnimal.FurColor;

            }
        }

        #region Binded Animal Properties

        private int? _ID;
        public int? ID
        {
            get 
            { 
                return _ID; 
            }
            set 
            { 
                _ID = value;
                NotifyOfPropertyChange(() => ID);
            }
        }

        private string _animalName;
        public string AnimalName
        {
            get 
            { 
                return _animalName; 
            }
            set 
            { 
                _animalName = value;
                NotifyOfPropertyChange(() => AnimalName);
            }
        }

        private string _chipNumber;
        public string ChipNumber
        {
            get
            {
                return _chipNumber;
            }
            set
            {
                _chipNumber = value;
                NotifyOfPropertyChange(() => ChipNumber);
            }
        }

        private string _sex;
        public string Sex
        {
            get
            {
                return _sex;
            }
            set
            {
                _sex = value;
                NotifyOfPropertyChange(() => Sex);
            }
        }

        private string _species;
        public string Species
        {
            get
            {
                return _species;
            }
            set
            {
                _species = value;
                NotifyOfPropertyChange(() => Species);
            }
        }

        private string _breed;
        public string Breed
        {
            get
            {
                return _breed;
            }
            set
            {
                _breed = value;
                NotifyOfPropertyChange(() => Breed);
            }
        }

        private DateTime? _birthDate;
        public DateTime? BirthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                _birthDate = value;
                NotifyOfPropertyChange(() => BirthDate);
            }
        }

        private string _coatType;
        public string CoatType
        {
            get
            {
                return _coatType;
            }
            set
            {
                _coatType = value;
                NotifyOfPropertyChange(() => CoatType);
            }
        }

        private string _furColor;
        public string FurColor
        {
            get
            {
                return _furColor;
            }
            set
            {
                _furColor = value;
                NotifyOfPropertyChange(() => FurColor);
            }
        }


        #endregion

        #region Binded Owner Properties

        private string _fullName;
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                _fullName = value;
                NotifyOfPropertyChange(() => FullName);
            }
        }

        private string _phone;
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                NotifyOfPropertyChange(() => Phone);
            }
        }

        private string _mail;
        public string Mail
        {
            get
            {
                return _mail;
            }
            set
            {
                _mail = value;
                NotifyOfPropertyChange(() => Mail);
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                NotifyOfPropertyChange(() => City);
            }
        }

        private string _street;
        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                _street = value;
                NotifyOfPropertyChange(() => Street);
            }
        }

        private string _zip;
        public string Zip
        {
            get
            {
                return _zip;
            }
            set
            {
                _zip = value;
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
            if (Adoption.ValidValues())
            {
                IsWorking = true;

                Owner.GetPerson(SelectedOwner.ID);
                Adoption.PersonID = SelectedOwner.ID;

                Animal.GetAnimal(SelectedAnimal.ID);
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
