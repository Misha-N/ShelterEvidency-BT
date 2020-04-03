using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    class CreateDeathViewModel: Screen
    {
        public StaysViewModel Prnt { get; set; }

        public StayEndViewModel Prnt1 { get; set; }
        public DeathModel Death { get; set; }
        public CreateDeathViewModel(int animalID, StaysViewModel parent)
        {
            Prnt = parent;
            Prnt.IsWorking = true;
            Death = new DeathModel();
            AnimalID = animalID;
        }

        public CreateDeathViewModel(int animalID, StayEndViewModel parent)
        {
            Prnt1 = parent;
            Prnt.IsWorking = true;
            Death = new DeathModel();
            AnimalID = animalID;
        }

        public int AnimalID
        {
            get
            {
                return Death.AnimalID;
            }
            set
            {
                Death.AnimalID = value;
                NotifyOfPropertyChange(() => AnimalID);
            }
        }

        public DateTime? Date
        {
            get
            {
                return Death.Date;
            }
            set
            {
                Death.Date = value;
                NotifyOfPropertyChange(() => Date);
            }
        }

        public string Description
        {
            get
            {
                return Death.Description;
            }
            set
            {
                Death.Description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        public bool Euthanasia
        {
            get
            {
                return Death.Euthanasia;
            }
            set
            {
                Death.Euthanasia = value;
                NotifyOfPropertyChange(() => Euthanasia);
            }
        }

        public bool Natural
        {
            get
            {
                return Death.Natural;
            }
            set
            {
                Death.Natural = value;
                NotifyOfPropertyChange(() => Natural);
            }
        }

        public bool Other
        {
            get
            {
                return Death.Other;
            }
            set
            {
                Death.Other = value;
                NotifyOfPropertyChange(() => Other);
            }
        }

        public void SaveToDatabase()
        {
            if (Death.ValidValues())
            {
                Death.CreateDeath();
                MessageBox.Show("Záznam vytvořen.");
                AnimalModel.AnimalDied(AnimalID);
                if (Prnt != null)
                    Prnt.IsWorking = false;
                if (Prnt1 != null)
                {
                    Prnt1.IsWorking = false;
                    Prnt1.FilterDeaths();
                }
                TryClose();
            }
            else
                MessageBox.Show("Vyplňte prosím platné ID zvířete.");
        }

        public void Cancel()
        {
            if(Prnt != null)
                Prnt.IsWorking = false;
            if (Prnt1 != null)
                Prnt1.IsWorking = false;
            TryClose();
        }
    }
}
