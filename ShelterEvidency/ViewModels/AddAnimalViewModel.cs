using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShelterEvidency.Models;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    public class AddAnimalViewModel: Screen
    {
        private string _name;
        private string _chipNumber;
        private string _sex;
        private string _species;
        private string _breed;
        private string _furColor;
        private string _coatType;
        private AnimalModel _animal = new AnimalModel();
        public AddAnimalViewModel()
        {
            SetLists();
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
            StaticLists sexList = new StaticLists();
            SexList = sexList.Sex();
        }

        private void SetBreedList()
        {
            StaticLists breedList = new StaticLists();
            BreedList = breedList.Breed();
        }

        private void SetSpeciesList()
        {
            StaticLists speciesList = new StaticLists();
            SpeciesList = speciesList.Species();
        }

        private void SetCoatTypeList()
        {
            StaticLists coatTypeList = new StaticLists();
            CoatTypeList = coatTypeList.CoatType();
        }

        private void SetFurColorList()
        {
            StaticLists furColorList = new StaticLists();
            FurColorList = furColorList.FurColor();
        }

        #endregion


        #region Properties
        public string Sex
        {
            get
            {
                return _sex;
            }
            set
            {
                _sex = value;
                NotifyOfPropertyChange(() => Sex);
            }
        } 
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
        public string ChipNumber
        {
            get
            {
                return _chipNumber;
            }
            set
            {
                _chipNumber = value;
                NotifyOfPropertyChange(() => ChipNumber);
            }
        }
        public string Species
        {
            get
            {
                return _species;
            }
            set
            {
                _species = value;
                NotifyOfPropertyChange(() => Species);
            }
        }
        public string Breed
        {
            get
            {
                return _breed;
            }
            set
            {
                _breed = value;
                NotifyOfPropertyChange(() => Breed);
            }
        }
        public string FurColor
        {
            get
            {
                return _furColor;
            }
            set
            {
                _furColor = value;
                NotifyOfPropertyChange(() => FurColor);
            }
        }
        public string CoatType
        {
            get
            {
                return _coatType;
            }
            set
            {
                _coatType = value;
                NotifyOfPropertyChange(() => CoatType);
            }
        }
        #endregion


        

        public AnimalModel Animal
        {
            get
            {
                _animal.SetInformations(Name, ChipNumber, Sex, Species, Breed, CoatType, FurColor);
                return _animal;
            }
        }


        public void SaveToDatabase()
        {
            MessageBox.Show(Animal.Name);
            Animal.SaveAnimal();
        }

        public void Cancel()
        {
            TryClose();
        }



    }
}
