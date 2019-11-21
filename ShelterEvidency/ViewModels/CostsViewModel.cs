using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    public class CostsViewModel: Screen
    {
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

        public CostModel Cost { get; set; }
        public CostModel NewCost { get; set; }
        public CostsViewModel(int animalID)
        {
            AnimalID = animalID;
            Cost = new CostModel();
            NewCost = new CostModel();
        }
        public List<Database.Costs> AnimalCosts
        {
            get
            {
                return CostModel.GetAnimalCosts(AnimalID);
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
        public int? SelectedCost
        {
            get
            {
                return Cost.ID;
            }
            set
            {
                Cost.GetCost(value);
                Selection();
            }
        }

        private void Selection()
        {
            NotifyOfPropertyChange(() => CostName);
            NotifyOfPropertyChange(() => Description);
            NotifyOfPropertyChange(() => Price);
            NotifyOfPropertyChange(() => Date);
            NotifyOfPropertyChange(() => SelectedCost);

        }

        public void UpdateCost()
        {
            if (SelectedCost != null)
            {
                Cost.UpdateCost();
                NotifyOfPropertyChange(() => AnimalCosts);
            }
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

        public void CreateNewCost()
        {
            if (NewCostName != null)
            {
                NewCost.AnimalID = AnimalID;
                NewCost.SaveCost();
            }
            NotifyOfPropertyChange(() => AnimalCosts);
            ClearNewStay();
        }

        public void ClearNewStay()
        {
            NewCost = new CostModel();
            NotifyOfPropertyChange(() => NewCost);
            NotifyOfPropertyChange(() => NewCostName);
            NotifyOfPropertyChange(() => NewDescription);
            NotifyOfPropertyChange(() => NewDate);
            NotifyOfPropertyChange(() => NewPrice);
        }


    }
}
