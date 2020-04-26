using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.Models;
using ShelterEvidency.WrappingClasses;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ShelterEvidency.ViewModels
{
    public class HomeViewModel: Conductor<object>
    {
        #region Initialize
        public DiaryModel DiaryModel { get; set; }
        public HomeViewModel()
        {
            DiaryModel = new DiaryModel();
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
                Home();
                LoadDatabase();
                RecordList = DiaryModel.GetDiaryRecords(SelectedDate);
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
            ActivateItem(new AddAnimalViewModel(this));
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
            ActivateItem(new CardPageViewModel());
        }

        #endregion
    }
}
