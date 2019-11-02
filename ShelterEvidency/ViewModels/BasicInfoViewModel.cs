using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    public class BasicInfoViewModel: Screen
    {
        private AnimalModel _animal;

        public BasicInfoViewModel(int animalID)
        {
            SetLists();
            Animal = new AnimalModel();
            Animal.GetAnimal(animalID);
            AnimalID = animalID;
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


        public AnimalModel Animal
        {
            get
            {
                return _animal;
            }
            set
            {
                _animal = value;
            }
        }

        #region List Setting
        public List<string> SexList { get; private set; }
        public List<string> BreedList { get; private set; }
        public List<string> SpeciesList { get; private set; }
        public List<string> CoatTypeList { get; private set; }
        public List<string> FurColorList { get; private set; }

        private void SetLists()
        {
            SetSexList();
            SetBreedList();
            SetSpeciesList();
            SetCoatTypeList();
            SetFurColorList();
        }

        private void SetSexList()
        {
            SexModel sexList = new SexModel();
            SexList = sexList.ReturnSexList();
        }

        private void SetBreedList()
        {
            BreedModel breedList = new BreedModel();
            BreedList = breedList.ReturnBreedList();
        }

        private void SetSpeciesList()
        {
            SpeciesModel speciesList = new SpeciesModel();
            SpeciesList = speciesList.ReturnSpeciesList();
        }

        private void SetCoatTypeList()
        {
            CoatTypeModel coatTypeList = new CoatTypeModel();
            CoatTypeList = coatTypeList.ReturnCoatTypeList();
        }

        private void SetFurColorList()
        {
            FurColorModel furColorList = new FurColorModel();
            FurColorList = furColorList.ReturnFurColorList();
        }

        #endregion

        public string Name
        {
            get
            {
                return Animal.Name;
            }
            set
            {
                Animal.Name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
        public string ChipNumber
        {
            get
            {
                return Animal.ChipNumber;
            }
            set
            {
                Animal.ChipNumber= value;
                NotifyOfPropertyChange(() => ChipNumber);
            }
        }
        public string Sex
        {
            get
            {
                return Animal.Sex;
            }
            set
            {
                Animal.Sex = value;
                NotifyOfPropertyChange(() => Sex);
            }
        }
        public string Species
        {
            get
            {
                return Animal.Species;
            }
            set
            {
                Animal.Species = value;
                NotifyOfPropertyChange(() => Species);
            }
        }
        public string Breed
        {
            get
            {
                return Animal.Breed;
            }
            set
            {
                Animal.Breed = value;
                NotifyOfPropertyChange(() => Breed);
            }
        }
        public string CoatType
        {
            get
            {
                return Animal.CoatType;
            }
            set
            {
                Animal.CoatType = value;
                NotifyOfPropertyChange(() => CoatType);
            }
        }
        public string FurColor
        {
            get
            {
                return Animal.FurColor;
            }
            set
            {
                Animal.FurColor = value;
                NotifyOfPropertyChange(() => FurColor);
            }
        }

        public void UpdateAnimal()
        {
            Animal.UpdateAnimal(AnimalID);
        }

    }
}
