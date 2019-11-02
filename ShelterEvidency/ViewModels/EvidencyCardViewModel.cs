using Caliburn.Micro;
using ShelterEvidency.Models;
using ShelterEvidency.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    class EvidencyCardViewModel : Conductor<object>
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


        public EvidencyCardViewModel(int animalID)
        {
            AnimalID = animalID;
            BasicInfo();
        }

        public void BasicInfo()
        {
                ActivateItem(new BasicInfoViewModel(AnimalID));
        }

        public void MedicalInfo()
        {
            ActivateItem(new MedicalInfoViewModel());
        }

        public void Costs()
        {
            ActivateItem(new CostsViewModel());
        }

        public void Stays()
        {
            ActivateItem(new StaysViewModel(AnimalID));
        }
    }
}
