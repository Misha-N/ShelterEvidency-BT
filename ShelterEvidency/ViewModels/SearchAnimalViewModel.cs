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
        #region Initialize
        public SearchAnimalViewModel()
        {
        }


        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            LoadData();
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

        #endregion

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
                NotifyOfPropertyChange(() => IsSelected);
            }
        }


        public bool IsSelected
        {
            get
            {
                if (SelectedAnimal != null)
                    return true;
                else
                    return false;
            }

        }



        public async void Search()
        {
            IsWorking = true;
            await Task.Delay(150);
            Animals = await Task.Run(() => AnimalModel.ReturnSpecificAnimals(SearchValue));
            IsWorking = false;
        }
        

        #region Page Loading

        public void AddAnimal()
        {
            ActivateItem(new AddAnimalViewModel(this));
        }

        public void UpdateAnimals()
        {
            LoadData();
        }

       
        public void OpenEvidencyCard()
        {
            if (SelectedAnimal != null)
                ActivateItem(new EvidencyCardViewModel((int)SelectedAnimal.ID));
        }

        public void DeleteAnimal()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete vymazat zvolené zvíře?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                AnimalModel.MarkAsDeleted((int)SelectedAnimal.ID);
                LoadData();
            }
        }
        public void ExportExcell()
        {
            if (Animals != null && Animals.Count() != 0)
                DocumentManager.ExportDataExcell(AnimalInfo.ConvertToList(Animals), "Export zvířata");
            else
                MessageBox.Show("Žádná data pro export.");
        }

        public void ExportPDF()
        {
            if (Animals != null && Animals.Count() != 0)
                DocumentManager.ExportDataPDF(AnimalInfo.ConvertToList(Animals), "Export zvířata");
            else
                MessageBox.Show("Žádná data pro export.");
        }

        #endregion






    }
}
