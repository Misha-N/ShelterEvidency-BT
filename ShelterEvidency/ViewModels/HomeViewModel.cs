using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.Models;
using ShelterEvidency.WrappingClasses;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    public class HomeViewModel: Conductor<object>
    {
        #region Initialize
        public DiaryModel DiaryModel { get; set; }
        public ShelterModel ShelterModel { get; set; }
        public HomeViewModel()
        {
            DiaryModel = new DiaryModel();
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
                LoadDatabase();
                RecordList = DiaryModel.GetDiaryRecords(SelectedDate);
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

        #endregion

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

        #region Diary

        private BindableCollection<DiaryRecordInfo> _recordList;
        public BindableCollection<DiaryRecordInfo> RecordList
        {
            get
            {
                return _recordList;
            }
            set
            {
                _recordList = value;
                NotifyOfPropertyChange(() => RecordList);
            }
        }

        private async Task LoadDiaryData()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                RecordList = DiaryModel.GetDiaryRecords(SelectedDate);
            });
            IsWorking = false;
        }
        public DateTime SelectedDate
        {
            get
            {
                return DiaryModel.Date;
            }
            set
            {
                DiaryModel.Date = value;
                NotifyOfPropertyChange(() => SelectedDate);
                Task.Run(() => LoadDiaryData());
            }
        }
        public string DiaryRecord
        {
            get
            {
                return DiaryModel.Record;
            }
            set
            {
                DiaryModel.Record = value;
                NotifyOfPropertyChange(() => DiaryRecord);
            }
        }

        private DiaryRecordInfo _selectedRecord;

        public DiaryRecordInfo SelectedRecord
        {
            get
            {
                return _selectedRecord;
            }
            set
            {
                _selectedRecord = value;
                NotifyOfPropertyChange(() => SelectedRecord);
                NotifyOfPropertyChange(() => IsSelected);
            }
        }


        public bool IsSelected
        {
            get
            {
                if (SelectedRecord != null)
                    return true;
                else
                    return false;
            }

        }

        public void DeleteRecord()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete vymazat zvolený záznam?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DiaryModel.MarkAsDeleted((int)SelectedRecord.ID);

                SelectedRecord = null;

                Task.Run(() => LoadDiaryData());
            }
        }

        #endregion

        #region Methods

        public void Exit()
        {
            MessageBoxResult result = MessageBox.Show("Chcete aplikaci ukončit?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        public void CreateDiaryRecord()
        {
            if (DiaryRecord != null)
            {
                DateTime recordDate = DiaryModel.Date;
                DiaryModel.SaveDiaryRecord();

                DiaryModel = new DiaryModel
                {
                    Date = recordDate
                };

                NotifyOfPropertyChange(() => DiaryRecord);
                Task.Run(() => LoadDiaryData());
            }
            else
                MessageBox.Show("Vyplňte prosím test záznamu.");

        }


        private void LoadDatabase()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    db.Animals.FirstOrDefault();
                    db.People.FirstOrDefault();
                    db.Breeds.FirstOrDefault();
                    db.CoatTypes.FirstOrDefault();
                    db.FurColors.FirstOrDefault();
                    db.Sexes.FirstOrDefault();
                    db.Species.FirstOrDefault();
                    db.DiaryRecords.FirstOrDefault();
                    db.Adoptions.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // první query bývá pomalá, načítají se metadata a query plány
        }

        #endregion

        #region Page Loading functions
        public void LoadAddAnimalPage()
        {
            ActivateItem(new AddAnimalViewModel());
        }

        public void LoadSearchAnimalPage()
        {
            ActivateItem(new SearchAnimalViewModel());
        }

        public void LoadPersonPage()
        {
            ActivateItem(new SearchPersonViewModel());
        }

        public void LoadSettingsPage()
        {
            ActivateItem(new SettingsViewModel());
        }

        public void LoadAdoptionsPage()
        {
            ActivateItem(new AdoptionsViewModel());
        }

        public void LoadStatisticsPage()
        {
            ActivateItem(new StatisticsViewModel());
        }

        public void LoadEconomyPage()
        {
            ActivateItem(new EconomyViewModel());
        }

        public void LoadGeneralStaysPage()
        {
            ActivateItem(new GeneralStaysViewModel());
        }

        public void LoadStayEndPage()
        {
            ActivateItem(new StayEndViewModel());
        }

        public void Home()
        {
            ActivateItem(null);
            CardSetting();
        }

        #endregion
    }
}
