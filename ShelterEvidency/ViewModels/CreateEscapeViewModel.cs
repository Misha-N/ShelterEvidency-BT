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
    class CreateEscapeViewModel: Screen
    {
        public StaysViewModel Prnt { get; set; }
        public StayEndViewModel Prnt1 { get; set; }
        public EscapeModel Escape { get; set; }
        public CreateEscapeViewModel(int animalID, StaysViewModel parent)
        {
            Prnt = parent;
            Prnt.IsWorking = true;
            Escape = new EscapeModel();
            AnimalID = animalID;
        }

        public CreateEscapeViewModel(int animalID, StayEndViewModel parent)
        {
            Prnt1 = parent;
            Prnt.IsWorking = true;
            Escape = new EscapeModel();
            AnimalID = animalID;
        }

        public int AnimalID
        {
            get
            {
                return Escape.AnimalID;
            }
            set
            {
                Escape.AnimalID = value;
                NotifyOfPropertyChange(() => Date);
            }
        }

        public DateTime? Date
        {
            get
            {
                return Escape.Date;
            }
            set
            {
                Escape.Date = value;
                NotifyOfPropertyChange(() => Date);
            }
        }

        public string Description
        {
            get
            {
                return Escape.Description;
            }
            set
            {
                Escape.Description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        public void SaveToDatabase()
        {
            if(Escape.ValidValues())
            {
                Escape.CreateEscape();
                MessageBox.Show("Záznam vytvořen.");
                if(Prnt != null)
                    Prnt.IsWorking = false;
                if (Prnt1 != null)
                {
                    Prnt1.IsWorking = false;
                    Prnt1.FilterEscapes();
                }
                TryClose();
            }
            else
                MessageBox.Show("Vyplňte prosím platné ID zvířete.");
        }

        public void Cancel()
        {
            if (Prnt != null)
                Prnt.IsWorking = false;
            if (Prnt1 != null)
                Prnt1.IsWorking = false;
            TryClose();
        }

    }
}
