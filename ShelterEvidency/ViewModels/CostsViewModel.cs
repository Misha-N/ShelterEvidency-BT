using Caliburn.Micro;
using ShelterEvidency.Models;
using ShelterEvidency.WrappingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    public class CostsViewModel: Screen
    {
        #region Initialization 

        private int? _animalID;
        public int? AnimalID
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

        public CostModel Cost { get; set; }
        public CostModel NewCost { get; set; }
        public CostsViewModel(int? animalID)
        {
            AnimalID = animalID;
            Cost = new CostModel();
            NewCost = new CostModel();
        }

        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            Task.Run(() => LoadData());
        }

        public virtual async Task LoadData()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                AnimalCosts = CostModel.GetAnimalCosts(AnimalID);
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

        private BindableCollection<CostInfo> _animalCosts;
        public BindableCollection<CostInfo> AnimalCosts
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


        #region Selected cost bindings
        public DateTime? Date
        {
            get
            {
                return Cost.Date;
            }
            set
            {
                Cost.Date = value;
                NotifyOfPropertyChange(() => Date);
            }
        }

        public int? Price
        {
            get
            {
                return Cost.Price;
            }
            set
            {
                Cost.Price = value;
                NotifyOfPropertyChange(() => Price);
            }
        }

        public int? CostAnimalID
        {
            get
            {
                return Cost.AnimalID;
            }
            set
            {
                Cost.AnimalID = value;
                NotifyOfPropertyChange(() => CostAnimalID);
            }
        }
        public string CostName
        {
            get
            {
                return Cost.CostName;
            }
            set
            {
                Cost.CostName = value;
                NotifyOfPropertyChange(() => CostName);
            }
        }

        public string Description
        {
            get
            {
                return Cost.Description;
            }
            set
            {
                Cost.Description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }
        #endregion


        private CostInfo _selectedCost;

        public CostInfo SelectedCost
        {
            get
            {
                return _selectedCost;
            }
            set
            {
                _selectedCost = value;
                NotifyOfPropertyChange(() => SelectedCost);
                Task.Run(() => Selection());
            }
        }

        private async Task Selection()
        {
            if (SelectedCost != null)
            {
                IsWorking = true;
                await Task.Delay(150);
                await Task.Run(() =>
                {
                    Cost.GetCost(SelectedCost.ID);
                });
                IsWorking = false;
            }
            NotifyOfPropertyChange(() => CostName);
            NotifyOfPropertyChange(() => Description);
            NotifyOfPropertyChange(() => Price);
            NotifyOfPropertyChange(() => Date);
            NotifyOfPropertyChange(() => SelectedCost);
            NotifyOfPropertyChange(() => IsSelected);
        }

        public void UpdateCost()
        {
            if (Cost != null && Cost.ValidValues())
            {
                Cost.UpdateCost();
                MessageBox.Show("Upraveno.");
                Filter();
            }
            else
                MessageBox.Show("Vyplňte prosím název, datum a částku.");
        }

        #region NewCost binded properties

        public DateTime? NewDate
        {
            get
            {
                return NewCost.Date;
            }
            set
            {
                NewCost.Date = value;
                NotifyOfPropertyChange(() => NewDate);
            }
        }

        public int? NewPrice
        {
            get
            {
                return NewCost.Price;
            }
            set
            {
                NewCost.Price = value;
                NotifyOfPropertyChange(() => NewPrice);
            }
        }

        public int? NewCostAnimalID
        {
            get
            {
                return NewCost.AnimalID;
            }
            set
            {
                NewCost.AnimalID = value;
                NotifyOfPropertyChange(() => NewCostAnimalID);
            }
        }
        public string NewCostName
        {
            get
            {
                return NewCost.CostName;
            }
            set
            {
                NewCost.CostName = value;
                NotifyOfPropertyChange(() => NewCostName);
            }
        }

        public string NewDescription
        {
            get
            {
                return NewCost.Description;
            }
            set
            {
                NewCost.Description = value;
                NotifyOfPropertyChange(() => NewDescription);
            }
        }

        #endregion

        #region Methods

        public void Filter()
        {
            if (Since == null || To == null)
                Task.Run(() => LoadData());
            else
                Task.Run(() => FilterData());


        }

        public virtual async Task FilterData()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                AnimalCosts = CostModel.GetDatedCosts(Since, To);
            });
            IsWorking = false;
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


        public void CreateNewCost()
        {
            if (NewCost.ValidValues())
            {
                IsWorking = true;
                NewCost.AnimalID = AnimalID;
                NewCost.SaveCost();
                Task.Run(() => LoadData());
                ClearNewCost();
                IsWorking = false;
                MessageBox.Show("Záznam vytvořen.");
            }
            else
                MessageBox.Show("Vyplňte prosím název, datum a částku.");

        }

        public void ClearNewCost()
        {
            NewCost = new CostModel();
            NotifyOfPropertyChange(() => NewCost);
            NotifyOfPropertyChange(() => NewCostName);
            NotifyOfPropertyChange(() => NewDescription);
            NotifyOfPropertyChange(() => NewDate);
            NotifyOfPropertyChange(() => NewPrice);
        }


        public bool IsSelected
        {
            get
            {
                if (SelectedCost != null)
                    return true;
                else
                    return false;
            }

        }

        public void DeleteCost()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete vymazat zvolenoý náklad?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                CostModel.MarkAsDeleted((int)SelectedCost.ID);
                Cost = new CostModel();
                SelectedCost = null;

                Filter();
            }
        }

        #endregion


    }
}
