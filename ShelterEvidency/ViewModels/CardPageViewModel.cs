using Caliburn.Micro;
using ShelterEvidency.Models;
using ShelterEvidency.WrappingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    class CardPageViewModel: Screen
    {
        public ShelterModel ShelterModel { get; set; }

        public CardPageViewModel()
        {
            ShelterModel = new ShelterModel();
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
                CardSetting();
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

        #region HomePage cards

        public void CardSetting()
        {
            AnimalCount = StatisticModel.AnimalsInShelterSum();
            AdoptionCount = StatisticModel.SuccessfullyAdoptedAnimals();
            PlannedWalks = WalkModel.GetDatedWalks(DateTime.Today, DateTime.Today.AddYears(10));
            LastAnimals = AnimalModel.LastAnimals(5);
            SetShelterInfo();
            Filter();
        }

        private int? _animalCount;
        public int? AnimalCount
        {
            get
            {
                return _animalCount;
            }
            set
            {
                _animalCount = value;
                NotifyOfPropertyChange(() => AnimalCount);
            }
        }

        private int? _adoptionCount;
        public int? AdoptionCount
        {
            get
            {
                return _adoptionCount;
            }
            set
            {
                _adoptionCount = value;
                NotifyOfPropertyChange(() => AdoptionCount);
            }
        }

        public void SetFinances()
        {
            DatedCosts = StatisticModel.DatedCosts((DateTime)Since, (DateTime)To);
            DatedDonations = StatisticModel.DatedDonations((DateTime)Since, (DateTime)To);
        }

        public void Filter()
        {
            if (Since != null && To != null)
                Task.Run(() => SetFinances());

        }


        private DateTime? _since;
        public DateTime? Since
        {
            get
            {
                return _since;
            }
            set
            {
                _since = value;
                NotifyOfPropertyChange(() => Since);
            }

        }

        private DateTime? _to;
        public DateTime? To
        {
            get
            {
                return _to;
            }
            set
            {
                _to = value;
                NotifyOfPropertyChange(() => To);
            }

        }


        private int? _datedCosts;
        public int? DatedCosts
        {
            get
            {
                return _datedCosts;
            }
            set
            {
                _datedCosts = value;
                NotifyOfPropertyChange(() => DatedCosts);
            }
        }

        private int? _datedDonations;
        public int? DatedDonations
        {
            get
            {
                return _datedDonations;
            }
            set
            {
                _datedDonations = value;
                NotifyOfPropertyChange(() => DatedDonations);
            }
        }

        private BindableCollection<WalkInfo> _plannedWalks;
        public BindableCollection<WalkInfo> PlannedWalks
        {
            get
            {
                return _plannedWalks;
            }
            set
            {
                _plannedWalks = value;
                NotifyOfPropertyChange(() => PlannedWalks);
            }
        }

        private BindableCollection<AnimalInfo> _lastAnimals;
        public BindableCollection<AnimalInfo> LastAnimals
        {
            get
            {
                return _lastAnimals;
            }
            set
            {
                _lastAnimals = value;
                NotifyOfPropertyChange(() => LastAnimals);
            }
        }


        #endregion

        #region Shelter Info Bindings

        public void SetShelterInfo()
        {
            ShelterModel = new ShelterModel();
            ShelterName = ShelterModel.Name;
            ShelterPhone = ShelterModel.Phone;
            ShelterEmergencyPhone = ShelterModel.Phone2;
            ShelterMail = ShelterModel.Mail;
            ShelterAdress = ShelterModel.Adress;
            ShelterAccount = ShelterModel.Account;
            ShelterLogo = ShelterModel.LogoPath;
        }



        private string _shelterName;
        public string ShelterName
        {
            get
            {
                return _shelterName;
            }
            set
            {
                _shelterName = value;
                NotifyOfPropertyChange(() => ShelterName);
            }
        }

        private string _shelterLogoPath;
        public string ShelterLogo
        {
            get
            {
                return _shelterLogoPath;
            }
            set
            {
                _shelterLogoPath = value;
                NotifyOfPropertyChange(() => ShelterLogo);
            }
        }

        private string _shelterPhone;
        public string ShelterPhone
        {
            get
            {
                return _shelterPhone;
            }
            set
            {
                _shelterPhone = value;
                NotifyOfPropertyChange(() => ShelterPhone);
            }
        }

        private string _shelteremergencyphone;
        public string ShelterEmergencyPhone
        {
            get
            {
                return _shelteremergencyphone;
            }
            set
            {
                _shelteremergencyphone = value;
                NotifyOfPropertyChange(() => ShelterEmergencyPhone);
            }
        }

        private string _shelterMail;
        public string ShelterMail
        {
            get
            {
                return _shelterMail;
            }
            set
            {
                _shelterMail = value;
                NotifyOfPropertyChange(() => ShelterMail);
            }
        }

        private string _shelterAdress;
        public string ShelterAdress
        {
            get
            {
                return _shelterAdress;
            }
            set
            {
                _shelterAdress = value;
                NotifyOfPropertyChange(() => ShelterAdress);
            }
        }

        private string _shelterAccount;
        public string ShelterAccount
        {
            get
            {
                return _shelterAccount;
            }
            set
            {
                _shelterAccount = value;
                NotifyOfPropertyChange(() => ShelterAccount);
            }
        }


        #endregion

    }
}
