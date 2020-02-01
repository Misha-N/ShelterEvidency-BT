using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    public class HomeViewModel: Conductor<object>
    {
        #region Page Loading functions
        public void LoadAddAnimalPage()
        {
            ActivateItem(new AddAnimalViewModel());
        }

        public void LoadSearchAnimalPage()
        {
            ActivateItem(new SearchAnimalViewModel());
        }

        public void LoadSearchPersonPage()
        {
            ActivateItem(new SearchPersonViewModel());
        }

        public void LoadAddPersonPage()
        {
            ActivateItem(new AddPersonViewModel());
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

        public HomeViewModel()
        {
            DiaryModel = new DiaryModel();
        }
        public DiaryModel DiaryModel { get; set; }

        #region Properties/Attributes

        public DateTime? SelectedDate
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
        public List<DiaryRecords> RecordList
        {
            get
            {
                return DiaryModel.GetDiaryRecords(SelectedDate);
            }
        }

        #endregion

        public void CreateDiaryRecord()
        {
            DateTime? recordDate = DiaryModel.Date;
            DiaryModel.SaveDiaryRecord();
            DiaryModel = new DiaryModel();
            DiaryModel.Date = recordDate;
            NotifyOfPropertyChange(() => RecordList);
            NotifyOfPropertyChange(() => DiaryRecord);
        }
    }
}
