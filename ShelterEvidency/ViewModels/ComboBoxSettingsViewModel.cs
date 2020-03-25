using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    class ComboBoxSettingsViewModel: Conductor<object>
    {
        #region Initialize
       
        public BreedModel NewBreed { get; set; }
        public SpeciesModel NewSpecies { get; set; }
        public FurColorModel NewFurColor { get; set; }
        public CoatTypeModel NewCoatType { get; set; }
        
        public ComboBoxSettingsViewModel()
        {
            SetModels();
        }

        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            Task.Run(() => LoadData());
        }


        private async Task LoadData()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                LoadSpecies();
                LoadFurColors();
                LoadBreeds();
                LoadCoatTypes();
            });
            IsWorking = false;
        }

        private volatile bool _isWorking;
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

        private void SetModels()
        {
            NewBreed = new BreedModel();
            NewSpecies = new SpeciesModel();
            NewCoatType = new CoatTypeModel();
            NewFurColor = new FurColorModel();
        }

        private void LoadSpecies() 
        {
            SpeciesList = SpeciesModel.ReturnSpecies();

        }

        private void LoadBreeds()
        {
            BreedList = BreedModel.ReturnBreeds(null);

        }

        private void LoadCoatTypes()
        {
            CoatTypeList = CoatTypeModel.ReturnCoatTypes();

        }

        private void LoadFurColors()
        {
            FurColorList = FurColorModel.ReturnFurColors();

        }

        #endregion

        #region List Setting

        private BindableCollection<Database.Breeds> _breedlist;
        public BindableCollection<Database.Breeds> BreedList
        {
            get
            {
                return _breedlist;
            }
            set
            {
                _breedlist = value;
                NotifyOfPropertyChange(() => BreedList);
            }
        }

        private BindableCollection<Database.Species> _specieslist;
        public BindableCollection<Database.Species> SpeciesList
        {
            get
            {
                return _specieslist;
            }
            set
            {
                _specieslist = value;
                NotifyOfPropertyChange(() => SpeciesList);
            }
        }

        private BindableCollection<Database.CoatTypes> _coattypelist;
        public BindableCollection<Database.CoatTypes> CoatTypeList
        {
            get
            {
                return _coattypelist;
            }
            set
            {
                _coattypelist = value;
                NotifyOfPropertyChange(() => CoatTypeList);
            }
        }

        private BindableCollection<Database.FurColors> _furcolorlist;
        public BindableCollection<Database.FurColors> FurColorList
        {
            get
            {
                return _furcolorlist;
            }
            set
            {
                _furcolorlist = value;
                NotifyOfPropertyChange(() => FurColorList);
            }
        }
        #endregion


        #region New CB values
        public string NewBreedName
        {
            get
            {
                return NewBreed.BreedName;
            }
            set
            {
                NewBreed.BreedName = value;
                NotifyOfPropertyChange(() => NewBreedName);
                NotifyOfPropertyChange(() => NewBreedSelected);
            }
        }

        public int? NewBreedSpecies
        {
            get
            {
                return NewBreed.SpeciesID;
            }
            set
            {
                NewBreed.SpeciesID = value;
                NotifyOfPropertyChange(() => NewBreedSpecies);
                NotifyOfPropertyChange(() => NewBreedSelected);
            }
        }

        public bool NewBreedSelected
        {
            get
            {
                if (!String.IsNullOrEmpty(NewBreedName) && NewBreedSpecies != null)
                    return true;
                else
                    return false;
            }

        }

        public void ClearNewBreed()
        {
            NewBreed = new BreedModel();
            NotifyOfPropertyChange(() => NewBreedName);
            NotifyOfPropertyChange(() => NewBreedSpecies);
            NotifyOfPropertyChange(() => NewBreedSelected);
        }


        public string NewSpeciesName
        {
            get
            {
                return NewSpecies.SpeciesName;
            }
            set
            {
                NewSpecies.SpeciesName = value;
                NotifyOfPropertyChange(() => NewSpeciesName);
                NotifyOfPropertyChange(() => NewSpeciesSelected);
            }
        }

        public bool NewSpeciesSelected
        {
            get
            {
                if (!String.IsNullOrEmpty(NewSpeciesName))
                    return true;
                else
                    return false;
            }
        }

        public void ClearNewSpecies()
        {
            NewSpecies = new SpeciesModel();
            NotifyOfPropertyChange(() => NewSpeciesName);
            NotifyOfPropertyChange(() => NewSpeciesSelected);
        }

        public string NewFurColorName
        {
            get
            {
                return NewFurColor.FurColorName;
            }
            set
            {
                NewFurColor.FurColorName = value;
                NotifyOfPropertyChange(() => NewFurColorName);
                NotifyOfPropertyChange(() => NewFurColorSelected);
            }
        }

        public bool NewFurColorSelected
        {
            get
            {
                if (!String.IsNullOrEmpty(NewFurColorName))
                    return true;
                else
                    return false;
            }
        }

        public void ClearNewFurColor()
        {
            NewFurColor = new FurColorModel();
            NotifyOfPropertyChange(() => NewFurColorName);
            NotifyOfPropertyChange(() => NewFurColorSelected);
        }

        public string NewCoatTypeName
        {
            get
            {
                return NewCoatType.CoatTypeName;
            }
            set
            {
                NewCoatType.CoatTypeName = value;
                NotifyOfPropertyChange(() => NewCoatTypeName);
                NotifyOfPropertyChange(() => NewCoatTypeSelected);
            }
        }

        public bool NewCoatTypeSelected
        {
            get
            {
                if (!String.IsNullOrEmpty(NewCoatTypeName))
                    return true;
                else
                    return false;
            }
        }

        public void ClearNewCoatType()
        {
            NewCoatType = new CoatTypeModel();
            NotifyOfPropertyChange(() => NewCoatTypeName);
            NotifyOfPropertyChange(() => NewCoatTypeSelected);
        }

        #endregion

        #region Selected Values

        private Database.Breeds _selectedBreed;
        public Database.Breeds SelectedBreed
        {
            get
            {
                return _selectedBreed;
            }
            set
            {
                _selectedBreed = value;
                NotifyOfPropertyChange(() => SelectedBreed);
                NotifyOfPropertyChange(() => BreedSelected);
            }
        }

        public bool BreedSelected
        {
            get
            {
                if (SelectedBreed != null)
                    return true;
                else
                    return false;
            }
        }

        private Database.Species _selectedSpecies;
        public Database.Species SelectedSpecies
        {
            get
            {
                return _selectedSpecies;
            }
            set
            {
                _selectedSpecies = value;
                NotifyOfPropertyChange(() => SelectedSpecies);
                NotifyOfPropertyChange(() => SpeciesSelected);
            }
        }

        public bool SpeciesSelected
        {
            get
            {
                if (SelectedSpecies != null)
                    return true;
                else
                    return false;
            }
        }

        private Database.FurColors _selectedFurColor;
        public Database.FurColors SelectedFurColor
        {
            get
            {
                return _selectedFurColor;
            }
            set
            {
                _selectedFurColor = value;
                NotifyOfPropertyChange(() => SelectedFurColor);
                NotifyOfPropertyChange(() => FurColorSelected);
            }
        }

        public bool FurColorSelected
        {
            get
            {
                if (SelectedFurColor != null)
                    return true;
                else
                    return false;
            }
        }

        private Database.CoatTypes _selectedCoatType;
        public Database.CoatTypes SelectedCoatType
        {
            get
            {
                return _selectedCoatType;
            }
            set
            {
                _selectedCoatType = value;
                NotifyOfPropertyChange(() => SelectedCoatType);
                NotifyOfPropertyChange(() => CoatTypeSelected);
            }
        }

        public bool CoatTypeSelected
        {
            get
            {
                if (SelectedCoatType != null)
                    return true;
                else
                    return false;
            }
        }

        #endregion


        #region Saving Methods
        public void AddBreed()
        {
            NewBreed.SaveBreed();
            ClearNewBreed();
            LoadBreeds();
            MessageBox.Show("Nové plemeno přidáno.");
        }

        public void AddSpecies()
        {
            NewSpecies.SaveSpecies();
            ClearNewSpecies();
            LoadSpecies();
            MessageBox.Show("Nový druh přidán.");
        }

        public void AddFurColor()
        {
            NewFurColor.SaveFurColor();
            ClearNewFurColor();
            LoadFurColors();
            MessageBox.Show("Nová barva srsti přidána.");
        }

        public void AddCoatType()
        {
            NewCoatType.SaveCoatType();
            ClearNewCoatType();
            LoadCoatTypes();
            MessageBox.Show("Nový typ srsti přidán.");
        }
        #endregion

        #region Delete functions

        public void DeleteBreed()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete vymazat zvolené plemeno?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                BreedModel.MarkAsDeleted(SelectedBreed.Id);
                LoadBreeds();
            }
        }

        public void DeleteSpecies()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete vymazat zvolený druh?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                SpeciesModel.MarkAsDeleted(SelectedSpecies.Id);
                LoadSpecies();
            }
        }

        public void DeleteFurColor()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete vymazat zvolenou barvu srsti?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                FurColorModel.MarkAsDeleted(SelectedFurColor.Id);
                LoadFurColors();
            }
        }

        public void DeleteCoatType()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete vymazat zvolený typ srsti?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                CoatTypeModel.MarkAsDeleted(SelectedCoatType.Id);
                LoadCoatTypes();
            }
        }

        #endregion

    }

}
