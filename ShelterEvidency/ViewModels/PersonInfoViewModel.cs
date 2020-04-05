using Caliburn.Micro;
using ShelterEvidency.Models;
using ShelterEvidency.WrappingClasses;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    public class PersonInfoViewModel: Screen
    {
        #region Initialization
        public PersonModel Person { get; set; }
        public SearchPersonViewModel Prnt { get; set; }
        public PersonInfoViewModel(int personID, SearchPersonViewModel vm)
        {
            Prnt = vm;
            Person = new PersonModel();
            Person.GetPerson(personID);

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
                AdoptionList = AdoptionModel.ReturnPersonAdoptions(Person.ID);
                WalkList = WalkModel.ReturnPersonWalks(Person.ID);
                DonationList = DonationModel.ReturnPersonDonations(Person.ID);
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

        #region Bindings in DB

        private BindableCollection<AdoptionInfo> _adoptionlist;
        public BindableCollection<AdoptionInfo> AdoptionList
        {
            get
            {
                return _adoptionlist;
            }
            set
            {
                _adoptionlist = value;
                NotifyOfPropertyChange(() => AdoptionList);
            }
        }


        private BindableCollection<DonationInfo> _donationlist;
        public BindableCollection<DonationInfo> DonationList
        {
            get
            {
                return _donationlist;
            }
            set
            {
                _donationlist = value;
                NotifyOfPropertyChange(() => DonationList);
            }
        }

        private BindableCollection<WalkInfo> _walklist;
        public BindableCollection<WalkInfo> WalkList
        {
            get
            {
                return _walklist;
            }
            set
            {
                _walklist = value;
                NotifyOfPropertyChange(() => WalkList);
            }
        }

        #endregion


        public void UpdatePerson()
        {
            if (Person.ValidValues())
            {
                Person.UpdatePerson();
                MessageBox.Show("Aktualizováno.");
                Prnt.UpdatePeople();
            }
            else
                MessageBox.Show("Vyplňte prosím jméno a příjmení.");
        }

        public void Cancel()
        {
            TryClose();
        }

    }
}

