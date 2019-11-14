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
        #region Models        
        private void SetModels()
        {
            NewBreed = new BreedModel();
            NewSpecies = new SpeciesModel();
            NewRole = new RoleModel();
            NewCoatType = new CoatTypeModel();
            NewFurColor = new FurColorModel();
        }
        public BreedModel NewBreed { get; set; }
        public SpeciesModel NewSpecies { get; set; }
        public RoleModel NewRole { get; set; }
        public FurColorModel NewFurColor { get; set; }
        public CoatTypeModel NewCoatType { get; set; }
        #endregion
        public ComboBoxSettingsViewModel()
        {
            SetModels();
            //SetLists();
        }


        #region New Atributes
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
            }
        }

        public int? NewBreedSpeciesID
        {
            get
            {
                return NewBreed.SpeciesID;
            }
            set
            {
                NewBreed.SpeciesID = value;
                NotifyOfPropertyChange(() => NewBreedSpeciesID);
            }
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
            }
        }

        public string NewRoleName
        {
            get
            {
                return NewRole.RoleName;
            }
            set
            {
                NewRole.RoleName = value;
                NotifyOfPropertyChange(() => NewRoleName);
            }
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
            }
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
            }
        }
        #endregion

        #region Set Data Lists
        public List<Database.Breeds> Breeds
        {
            get
            {
                return BreedModel.ReturnBreeds(null);
            }
        }
        public List<Database.Species> Species
        {
            get
            {
                return SpeciesModel.ReturnSpecies();
            }
        }
        public List<Database.Roles> Roles
        {
            get
            {
                return RoleModel.ReturnRoles();
            }
        }
        public List<Database.FurColors> FurColors
        {
            get
            {
                return FurColorModel.ReturnFurColors();
            }
        }
        public List<Database.CoatTypes> CoatTypes
        {
            get
            {
                return CoatTypeModel.ReturnCoatTypes();
            }
        }

        #endregion

        #region Saving Methods
        public void AddBreed()
        {
            NewBreed.SaveBreed();
            NotifyOfPropertyChange(() => Breeds);
        }

        public void AddSpecies()
        {
            NewSpecies.SaveSpecies();
            NotifyOfPropertyChange(() => Species);
        }

        public void AddRole()
        {
            NewRole.SaveRole();
            NotifyOfPropertyChange(() => Roles);
        }

        public void AddFurColor()
        {
            NewFurColor.SaveFurColor();
            NotifyOfPropertyChange(() => FurColors);
        }

        public void AddCoatType()
        {
            NewCoatType.SaveCoatType();
            NotifyOfPropertyChange(() => CoatTypes);
        }
        #endregion
    }
}
