using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    public class AdoptionCardViewModel: Screen
    {
        #region Initialization
        public AdoptionModel Adoption { get; set; }
        public AnimalInfo Animal { get; set; }
        public PersonInfo Person { get; set; }
        public AdoptionsViewModel Prnt { get; set; }

        public AdoptionCardViewModel(int adoptionID, AdoptionsViewModel parent)
        {
            Prnt = parent;
            Prnt.IsWorking = true;
            Adoption = new AdoptionModel();
            Adoption.GetAdoption(adoptionID);
            Animal = new AnimalInfo();
            Person = new PersonInfo();
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
                Animal = AnimalModel.GetAnimalInfo(Adoption.AnimalID);
                Person = PersonModel.GetPersonInfo(Adoption.PersonID);
                SetAnimal();
                SetOwner();
            });
            IsWorking = false;
        }

        private bool _isWorking;

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

        private void SetOwner()
        {
                FullName = Person.TitledFullName;
                Phone = Person.Phone;
                Mail = Person.Mail;
                City = Person.AdressCity;
                Street = Person.AdressStreet;
                Zip = Person.AdressZip;
        }

        private void SetAnimal()
        {

                ID = Animal.ID;
                AnimalName = Animal.Name;
                ChipNumber = Animal.ChipNumber;
                Species = Animal.Species;
                Sex = Animal.Sex;
                Breed = Animal.Breed;
                BirthDate = Animal.BirthDate;
                CoatType = Animal.CoatType;
                FurColor = Animal.FurColor;


        }


        #endregion

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
                ClearReturnInput();
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
                NotifyOfPropertyChange(() => ReturnDate);
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
                NotifyOfPropertyChange(() => ReturnReason);
            }
        }

        public void ClearReturnInput()
        {
            ReturnDate = null;
            ReturnReason = null;
        }

        public void SaveToDatabase()
        {
            Adoption.UpdateAdoption();
            MessageBox.Show("Aktualizováno.");
            Prnt.UpdateAdoptions();
            Prnt.IsWorking = false;
            TryClose();
        }

        public void Cancel()
        {
            Prnt.IsWorking = false;
            TryClose();
        }
    }
}
