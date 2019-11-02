using Caliburn.Micro;
using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    public class StaysViewModel: Screen
    {
        private List<Database.Stays> _animalStays;

        public List<Database.Stays> AnimalStays
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


        public StaysViewModel(int animalID)
        {
            AnimalID = animalID;
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            AnimalStays = db.Stays.Where(x => x.AnimalID.Equals(AnimalID)).ToList();

        }

    }
}
