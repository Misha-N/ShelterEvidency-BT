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
        public BreedModel Breed { get; set; }
        public SpeciesModel Species { get; set; }
        public RoleModel Role { get; set; }
        public FurColorModel FurColor { get; set; }
        public CoatTypeModel CoatType { get; set; }
        public string NewBreedName
        {
            get
            {
                return Breed.BreedName;
            }
            set
            {
                Breed.BreedName = value;
                NotifyOfPropertyChange(() => NewBreedName);
            }
        }

        public string NewSpeciesName
        {
            get
            {
                return Species.SpeciesName;
            }
            set
            {
                Species.SpeciesName = value;
                NotifyOfPropertyChange(() => NewSpeciesName);
            }
        }

        public string NewRoleName
        {
            get
            {
                return Role.RoleName;
            }
            set
            {
                Role.RoleName = value;
                NotifyOfPropertyChange(() => NewRoleName);
            }
        }

        public string NewFurColorName
        {
            get
            {
                return FurColor.FurColorName;
            }
            set
            {
                FurColor.FurColorName = value;
                NotifyOfPropertyChange(() => NewFurColorName);
            }
        }

        public string NewCoatTypeName
        {
            get
            {
                return CoatType.CoatTypeName;
            }
            set
            {
                CoatType.CoatTypeName = value;
                NotifyOfPropertyChange(() => NewCoatTypeName);
            }
        }
        public List<string> SpeciesList { get; set; }

        public ComboBoxSettingsViewModel()
        {
            SetModels();
            SetLists();
        }
        private void SetSpeciesList()
        {
            SpeciesModel speciesList = new SpeciesModel();
            SpeciesList = speciesList.ReturnSpeciesList();
        }
        private void SetModels()
        {
            Breed = new BreedModel();
            Species = new SpeciesModel();
            Role = new RoleModel();
            CoatType = new CoatTypeModel();
            FurColor = new FurColorModel();
        }

        private void SetLists()
        {
            SetSpeciesList();
        }

        public string SelectedSpecies
        {
            get
            {
                return Breed.Species.SpeciesName;
            }
            set
            {
                Breed.Species.SpeciesName = value;
                NotifyOfPropertyChange(() => SelectedSpecies);
            }
        }

        public ObservableCollection<Breeds> Breeds
        {
            get
            {
                return Breed.ReturnBreeds();
            }
        }

        public List<Database.Species> SpeciesL
        {
            get
            {
                return Species.ReturnSpecies();
            }
        }

        public List<Database.Roles> Roles
        {
            get
            {
                return Role.ReturnRoles();
            }
        }

        public List<Database.FurColors> FurColors
        {
            get
            {
                return FurColor.ReturnFurColors();
            }
        }

        public List<Database.CoatTypes> CoatTypes
        {
            get
            {
                return CoatType.ReturnCoatTypes();
            }
        }





        public void AddBreed()
        {
            Breed.SaveBreed();
            MessageBox.Show(Breed.BreedName + " přidán do databáze.");
            NotifyOfPropertyChange(() => Breeds);
        }

        public void AddSpecies()
        {
            Species.SaveSpecies();
            MessageBox.Show(Breed.BreedName + " přidán do databáze.");
            NotifyOfPropertyChange(() => Species);
        }

        public void AddRole()
        {
            Role.SaveRole();
            MessageBox.Show(Breed.BreedName + " přidán do databáze.");
            NotifyOfPropertyChange(() => Roles);
        }

        public void AddFurColor()
        {
            FurColor.SaveFurColor();
            MessageBox.Show(Breed.BreedName + " přidán do databáze.");
            NotifyOfPropertyChange(() => FurColors);
        }

        public void AddCoatType()
        {
            CoatType.SaveCoatType();
            MessageBox.Show(Breed.BreedName + " přidán do databáze.");
            NotifyOfPropertyChange(() => CoatTypes);
        }
    }
}
