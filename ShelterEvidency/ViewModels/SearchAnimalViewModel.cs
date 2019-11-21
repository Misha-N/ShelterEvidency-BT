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
        public List<AnimalInfo> Animals
        {
            get
            {
                if (SearchValue == null)
                    return AnimalModel.ReturnAnimals();
                else
                    return Search();
            }

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
                NotifyOfPropertyChange(() => Animals);
            }
        }

        private AnimalInfo _selectedAnimal;

        public AnimalInfo SelectedAnimal
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


        public List<AnimalInfo> Search()
        {
            return AnimalModel.ReturnSpecificAnimals(SearchValue);
        }

        public void AddAnimal()
        {
            ActivateItem(new AddAnimalViewModel());
        }

        public void OpenEvidencyCard()
        {
            if (SelectedAnimal != null)
                ActivateItem(new EvidencyCardViewModel(SelectedAnimal.ID));
        }





    }
}
