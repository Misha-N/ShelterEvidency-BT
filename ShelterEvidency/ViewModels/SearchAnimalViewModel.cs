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
    public class SearchAnimalViewModel: Conductor<object>
    {
        private List<Database.Animals> _animals;

        public List<Database.Animals> Animals
        {
            get
            {
                return _animals;
            }
            set
            {
                _animals = value;
                NotifyOfPropertyChange(() => Animals);
            }
        }

        public SearchAnimalViewModel()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            Animals = db.Animals.ToList();

        }

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
                Search();
            }
        }

        private Animals _selectedAnimal;

        public Animals SelectedAnimal
        {
            get
            {
                return _selectedAnimal;
            }
            set
            {
                _selectedAnimal = value;
                NotifyOfPropertyChange(() => SelectedAnimal);
            }
        }

        private AnimalModel _allAnimals;

        public AnimalModel AllAnimals
        {
            get
            {
                return _allAnimals;
            }
            set
            {
                _allAnimals = value;
                NotifyOfPropertyChange(() => AllAnimals);
            }
        }


        public void Search()
        {
            Animals = AllAnimals.ReturnAllAnimals(SearchValue);
        }

        public void AddAnimal()
        {
            ActivateItem(new AddAnimalViewModel());
        }

        public void OpenEvidencyCard()
        {
            if (SelectedAnimal != null)
                ActivateItem(new EvidencyCardViewModel(SelectedAnimal.AnimalID));
        }





    }
}
