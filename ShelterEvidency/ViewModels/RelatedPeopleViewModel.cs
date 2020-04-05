using Caliburn.Micro;
using ShelterEvidency.Models;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    public class RelatedPeopleViewModel: Screen
    {
        #region Initialize
        public AnimalModel Animal { get; set; }
        public PersonInfo Vet { get; set; }
        public PersonInfo Owner { get; set; }
        public PersonInfo NewOwner { get; set; }
        public RelatedPeopleViewModel(int animalID)
        {
            Animal = new AnimalModel();
            Animal.GetAnimal(animalID);

            Vet = new PersonInfo();
            Owner = new PersonInfo();
            NewOwner = new PersonInfo();

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
                Vet = PersonModel.GetPersonInfo(Animal.VetID);
                Owner = PersonModel.GetPersonInfo(Animal.OwnerID);
                NewOwner = PersonModel.GetPersonInfo(Animal.NewOwnerID);
                SetPeople();
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

        public void SetPeople()
        {
            SetVet();
            SetOwner();
            SetNewOwner();
        }

        public void SetVet()
        {
            VetTitle = Vet.Title;
            VetFirstName = Vet.FirstName;
            VetLastName = Vet.LastName;
            VetPhone = Vet.Phone;
            VetMail = Vet.Mail;
            VetCity = Vet.AdressCity;
            VetStreet = Vet.AdressStreet;
            VetZip = Vet.AdressZip;
        }

        public void SetOwner()
        {
            ExTitle = Owner.Title;
            ExFirstName = Owner.FirstName;
            ExLastName = Owner.LastName;
            ExPhone = Owner.Phone;
            ExMail = Owner.Mail;
            ExCity = Owner.AdressCity;
            ExStreet = Owner.AdressStreet;
            ExZip = Owner.AdressZip;
        }

        public void SetNewOwner()
        {
            Title = NewOwner.Title;
            FirstName = NewOwner.FirstName;
            LastName = NewOwner.LastName;
            Phone = NewOwner.Phone;
            Mail = NewOwner.Mail;
            City = NewOwner.AdressCity;
            Street = NewOwner.AdressStreet;
            Zip = NewOwner.AdressZip;
        }

        #endregion


        #region Binded Vet Properties

        private string _vettitle;
        public string VetTitle
        {
            get
            {
                return _vettitle;
            }
            set
            {
                _vettitle = value;
                NotifyOfPropertyChange(() => VetTitle);
            }
        }

        private string _vetfirstName;
        public string VetFirstName
        {
            get
            {
                return _vetfirstName;
            }
            set
            {
                _vetfirstName = value;
                NotifyOfPropertyChange(() => VetFirstName);
            }
        }

        private string _vetlastName;
        public string VetLastName
        {
            get
            {
                return _vetlastName;
            }
            set
            {
                _vetlastName = value;
                NotifyOfPropertyChange(() => VetLastName);
            }
        }

        private string _vetphone;
        public string VetPhone
        {
            get
            {
                return _vetphone;
            }
            set
            {
                _vetphone = value;
                NotifyOfPropertyChange(() => VetPhone);
            }
        }

        private string _vetmail;
        public string VetMail
        {
            get
            {
                return _vetmail;
            }
            set
            {
                _vetmail = value;
                NotifyOfPropertyChange(() => VetMail);
            }
        }

        private string _vetcity;
        public string VetCity
        {
            get
            {
                return _vetcity;
            }
            set
            {
                _vetcity = value;
                NotifyOfPropertyChange(() => VetCity);
            }
        }

        private string _vetstreet;
        public string VetStreet
        {
            get
            {
                return _vetstreet;
            }
            set
            {
                _vetstreet = value;
                NotifyOfPropertyChange(() => VetStreet);
            }
        }

        private string _vetzip;
        public string VetZip
        {
            get
            {
                return _vetzip;
            }
            set
            {
                _vetzip = value;
                NotifyOfPropertyChange(() => VetZip);
            }
        }


        #endregion

        #region Binded ExOwner Properties

        private string _extitle;
        public string ExTitle
        {
            get
            {
                return _extitle;
            }
            set
            {
                _extitle = value;
                NotifyOfPropertyChange(() => ExTitle);
            }
        }

        private string _exfirstName;
        public string ExFirstName
        {
            get
            {
                return _exfirstName;
            }
            set
            {
                _exfirstName = value;
                NotifyOfPropertyChange(() => ExFirstName);
            }
        }

        private string _exlastName;
        public string ExLastName
        {
            get
            {
                return _exlastName;
            }
            set
            {
                _exlastName = value;
                NotifyOfPropertyChange(() => ExLastName);
            }
        }

        private string _exphone;
        public string ExPhone
        {
            get
            {
                return _exphone;
            }
            set
            {
                _exphone = value;
                NotifyOfPropertyChange(() => ExPhone);
            }
        }

        private string _exmail;
        public string ExMail
        {
            get
            {
                return _exmail;
            }
            set
            {
                _exmail = value;
                NotifyOfPropertyChange(() => ExMail);
            }
        }

        private string _excity;
        public string ExCity
        {
            get
            {
                return _excity;
            }
            set
            {
                _excity = value;
                NotifyOfPropertyChange(() => ExCity);
            }
        }

        private string _exstreet;
        public string ExStreet
        {
            get
            {
                return _exstreet;
            }
            set
            {
                _exstreet = value;
                NotifyOfPropertyChange(() => ExStreet);
            }
        }

        private string _exzip;
        public string ExZip
        {
            get
            {
                return _exzip;
            }
            set
            {
                _exzip = value;
                NotifyOfPropertyChange(() => ExZip);
            }
        }

        #endregion

        #region Binded NewOwner Properties

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
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
    }
}
