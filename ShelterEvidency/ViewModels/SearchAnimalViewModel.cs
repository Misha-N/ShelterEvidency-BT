using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    public class SearchAnimalViewModel: Conductor<object>
    {
        public SearchAnimalViewModel()
        {
        }


        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            Task.Run(() => LoadData());
        }


        private async void LoadData()
        {
            IsWorking = true;
            await Task.Delay(150);
            Animals = await Task.Run(() => AnimalModel.ReturnAnimals());
            IsWorking = false;
        }

        private bool _isWorking;

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

        private BindableCollection<AnimalInfo> _animals;

        public BindableCollection<AnimalInfo> Animals
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

        /*

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
        

        public List<AnimalInfo> Search()
        {
            return AnimalModel.ReturnSpecificAnimals(SearchValue);
        }
        */

        public void AddAnimal()
        {
            ActivateItem(new AddAnimalViewModel(this));
        }

        public void UpdateAnimals()
        {
            NotifyOfPropertyChange(() => Animals);
        }

        /*
        public void OpenEvidencyCard()
        {
            if (SelectedAnimal != null)
                ActivateItem(new EvidencyCardViewModel((int)SelectedAnimal.ID));
        }
        */





    }
}
