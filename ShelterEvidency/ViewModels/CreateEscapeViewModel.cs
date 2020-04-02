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
        public EscapeModel Escape { get; set; }
        public CreateEscapeViewModel(int animalID, StaysViewModel parent)
        {
            Prnt = parent;
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
                Prnt.IsWorking = false;
                TryClose();
            }
            else
                MessageBox.Show("Vyplňte prosím platné ID zvířete.");
        }

        public void Cancel()
        {
            Prnt.IsWorking = false;
            TryClose();
        }

    }
}
