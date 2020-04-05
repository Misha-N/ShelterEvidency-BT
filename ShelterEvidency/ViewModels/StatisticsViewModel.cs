using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    class StatisticsViewModel: Screen
    {
        #region Initialize
         
        public AnimalModel Animal { get; set; }
        public StatisticsViewModel()
        {
            Animal = new AnimalModel ();
        }

        
        private int _animalID;
        public int AnimalID
        {
            get 
            { 
                return _animalID; 
            }
            set 
            { 
                _animalID = value;
                NotifyOfPropertyChange(() => AnimalID);
            }
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


        private string _searchValue;

        public string SearchValue
        {
            get 
            { 
                return _searchValue; 
            }
            set 
            {
                _searchValue = value;
                NotifyOfPropertyChange(() => SearchValue);
                NotifyOfPropertyChange(() => ValidSearchValue);
            }
        }

        public async Task Search()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                Animal.GetAnimal(AnimalID);
                SetAnimalStatistics();

            });
            IsWorking = false;
        }

        private void SetAnimalStatistics()
        {
            if (Animal.ID == AnimalID)
            {
                AnimalName = Animal.Name;
                AnimalDead = BoolToString(Animal.IsDead);
                AnimalInShelter = BoolToString(Animal.InShelter);
                AnimalAdopted = BoolToString(StatisticModel.AnimalAdopted(Animal.ID));
                AnimalWalks = StatisticModel.TotalAnimalWalks(Animal.ID).ToString();
                AnimalEscapes = StatisticModel.TotalAnimalEscapes(Animal.ID).ToString();
                AnimalMedicalRecords = StatisticModel.TotalAnimalMedicalRecords(Animal.ID).ToString();
                AnimalIncidents = StatisticModel.TotalAnimalIncidents(Animal.ID).ToString();
                AnimalStays = StatisticModel.TotalAnimalStays(Animal.ID).ToString();
                AnimalFood = ((StatisticModel.TotalAnimalDays(Animal.ID) * Animal.FeedRation)/1000).ToString();
                AnimalDays = StatisticModel.TotalAnimalDays(Animal.ID).ToString();
                AnimalCosts = StatisticModel.TotalAnimalCosts(Animal.ID).ToString();
            }
            else
                MessageBox.Show("Zvíře nenalezeno.");
        }

        public string BoolToString(bool? boolean)
        {
            if (boolean == true)
                return "Ano";
            if (boolean == false)
                return "Ne";
            else
                return String.Empty;
        
        }

        #region Animal Statistic bindings

        private string animalName;

        public string AnimalName
        {
            get 
            { 
                return animalName; 
            }
            set 
            { 
                animalName = value;
                NotifyOfPropertyChange(() => AnimalName);
            }
        }

        private string animalAdopted;

        public string AnimalAdopted
        {
            get
            {
                return animalAdopted;
            }
            set
            {
                animalAdopted = value;
                NotifyOfPropertyChange(() => AnimalAdopted);
            }
        }

        private string animalDead;

        public string AnimalDead
        {
            get
            {
                return animalDead;
            }
            set
            {
                animalDead = value;
                NotifyOfPropertyChange(() => AnimalDead);
            }
        }

        private string animalInShelter;

        public string AnimalInShelter
        {
            get
            {
                return animalInShelter;
            }
            set
            {
                animalInShelter = value;
                NotifyOfPropertyChange(() => AnimalInShelter);
            }
        }

        private string _animalWalks;

        public string AnimalWalks
        {
            get
            {
                return _animalWalks;
            }
            set
            {
                _animalWalks = value;
                NotifyOfPropertyChange(() => AnimalWalks);
            }
        }

        private string _animalEscapes;

        public string AnimalEscapes
        {
            get
            {
                return _animalEscapes;
            }
            set
            {
                _animalEscapes = value;
                NotifyOfPropertyChange(() => AnimalEscapes);
            }
        }

        private string _animalMedicalRecords;

        public string AnimalMedicalRecords
        {
            get
            {
                return _animalMedicalRecords;
            }
            set
            {
                _animalMedicalRecords = value;
                NotifyOfPropertyChange(() => AnimalMedicalRecords);
            }
        }

        private string _animalIncidents;

        public string AnimalIncidents
        {
            get
            {
                return _animalIncidents;
            }
            set
            {
                _animalIncidents = value;
                NotifyOfPropertyChange(() => AnimalIncidents);
            }
        }

        private string _animalStays;

        public string AnimalStays
        {
            get
            {
                return _animalStays;
            }
            set
            {
                _animalStays = value;
                NotifyOfPropertyChange(() => AnimalStays);
            }
        }

        private string _animalfood;

        public string AnimalFood
        {
            get
            {
                return _animalfood;
            }
            set
            {
                _animalfood = value;
                NotifyOfPropertyChange(() => AnimalFood);
            }
        }

        private string _animalDays;

        public string AnimalDays
        {
            get
            {
                return _animalDays;
            }
            set
            {
                _animalDays = value;
                NotifyOfPropertyChange(() => AnimalDays);
            }
        }

        private string _animalCosts;

        public string AnimalCosts
        {
            get
            {
                return _animalCosts;
            }
            set
            {
                _animalCosts = value;
                NotifyOfPropertyChange(() => AnimalCosts);
            }
        }

        #endregion

        public async Task Filter()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                if (Since == null || To == null)
                    Task.Run(() => SetTotalStatistics(DateTime.Now.AddYears(-100), DateTime.Now.AddYears(100)));
                else
                    Task.Run(() => SetTotalStatistics((DateTime)Since, (DateTime)To));

            });
            IsWorking = false;
        }

        private void SetTotalStatistics(DateTime since, DateTime to)
        {
            StatAnimals = StatisticModel.DatedIntakes(since, to).ToString();
            StatIncidents = StatisticModel.DatedIncidents(since, to).ToString();
            StatMedicalRecords = StatisticModel.DatedMedicalRecords(since, to).ToString();
            StatDeaths = StatisticModel.DatedDeaths(since, to).ToString();
            StatAdopted = StatisticModel.DatedAdoptions(since, to).ToString();
            StatNotReturned = StatisticModel.DatedNotReturned(since, to).ToString();
            StatReturned = StatisticModel.DatedReturned(since, to).ToString();
            StatWalks = StatisticModel.DatedWalks(since, to).ToString();
            StatCosts = StatisticModel.DatedCosts(since, to).ToString();
            StatDonations = StatisticModel.DatedDonations(since, to).ToString();
            StatEscapes = StatisticModel.DatedEscapes(since, to).ToString();
        }

        #region Total Statistics Binding


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

        private string _statanimals;

        public string StatAnimals
        {
            get
            {
                return _statanimals;
            }
            set
            {
                _statanimals = value;
                NotifyOfPropertyChange(() => StatAnimals);
            }
        }

        private string _statincidents;

        public string StatIncidents
        {
            get
            {
                return _statincidents;
            }
            set
            {
                _statincidents = value;
                NotifyOfPropertyChange(() => StatIncidents);
            }
        }

        private string _statmedicalrecords;

        public string StatMedicalRecords
        {
            get
            {
                return _statmedicalrecords;
            }
            set
            {
                _statmedicalrecords = value;
                NotifyOfPropertyChange(() => StatMedicalRecords);
            }
        }

        private string _statdeaths;

        public string StatDeaths
        {
            get
            {
                return _statdeaths;
            }
            set
            {
                _statdeaths = value;
                NotifyOfPropertyChange(() => StatDeaths);
            }
        }

        private string _statadopted;

        public string StatAdopted
        {
            get
            {
                return _statadopted;
            }
            set
            {
                _statadopted = value;
                NotifyOfPropertyChange(() => StatAdopted);
            }
        }

        private string _statnotreturned;

        public string StatNotReturned
        {
            get
            {
                return _statnotreturned;
            }
            set
            {
                _statnotreturned = value;
                NotifyOfPropertyChange(() => StatNotReturned);
            }
        }

        private string _statreturned;

        public string StatReturned
        {
            get
            {
                return _statreturned;
            }
            set
            {
                _statreturned = value;
                NotifyOfPropertyChange(() => StatReturned);
            }
        }

        private string _statwalks;

        public string StatWalks
        {
            get
            {
                return _statwalks;
            }
            set
            {
                _statwalks = value;
                NotifyOfPropertyChange(() => StatWalks);
            }
        }

        private string _statcosts;

        public string StatCosts
        {
            get
            {
                return _statcosts;
            }
            set
            {
                _statcosts = value;
                NotifyOfPropertyChange(() => StatCosts);
            }
        }

        private string _statdonations;

        public string StatDonations
        {
            get
            {
                return _statdonations;
            }
            set
            {
                _statdonations = value;
                NotifyOfPropertyChange(() => StatDonations);
            }
        }

        private string _statescapes;

        public string StatEscapes
        {
            get
            {
                return _statescapes;
            }
            set
            {
                _statescapes = value;
                NotifyOfPropertyChange(() => StatEscapes);
            }
        }



        #endregion



        public bool ValidSearchValue
        {
            get
            {
                if (Int32.TryParse(SearchValue, out int animalID) && animalID > 0)
                {
                    AnimalID = animalID;
                    return true;
                }
                else
                    return false;
            }

        }



    }
}
