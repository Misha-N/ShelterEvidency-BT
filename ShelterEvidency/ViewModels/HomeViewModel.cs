using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            await Task.Run(() => LoadDatabase());
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

        public BindableCollection<DiaryRecords> RecordList
        {
            get
            {
                return DiaryModel.GetDiaryRecords(SelectedDate);
            }
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
                NotifyOfPropertyChange(() => RecordList);
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

        #endregion

        #region Methods

        public void CreateDiaryRecord()
        {
            DateTime recordDate = DiaryModel.Date;
            DiaryModel.SaveDiaryRecord();

            DiaryModel = new DiaryModel
            {
                Date = recordDate
            };

            NotifyOfPropertyChange(() => RecordList);
            NotifyOfPropertyChange(() => DiaryRecord);
        }

        private void LoadDatabase()
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
                db.Images.FirstOrDefault();
                db.Adoptions.FirstOrDefault();
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

        public void Home()
        {
            ActivateItem(null);
        }

        #endregion
    }
}
