﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShelterEvidency.Models;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Media.Imaging;

namespace ShelterEvidency.ViewModels
{
    public class AddAnimalViewModel: Conductor<object>
    {
        private BitmapImage _animalImage;

        public BitmapImage AnimalImage
        {
            get 
            { 
            return _animalImage; 
            }
            set
            {
                _animalImage = value;
                NotifyOfPropertyChange(() => AnimalImage);
            }
        }

        public AddAnimalViewModel()
        {
            SetLists();
            Animal = new AnimalModel();
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


        #region Properties
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
                Animal.ChipNumber = value;
                NotifyOfPropertyChange(() => ChipNumber);
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
        #endregion


        private AnimalModel _animal;

        public AnimalModel Animal
        {
            get
            {
                return _animal;
            }
            set
            {
                _animal = value;
                NotifyOfPropertyChange(() => Animal);
            }
        }




        public void SaveToDatabase()
        {
            Animal.SaveAnimal();
            MessageBox.Show(Animal.Name + " přidán do evidence.");
            TryClose();
        }

        public void LoadImage()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Vyberte obrázek";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                AnimalImage = new BitmapImage(new Uri(op.FileName));
            }
        }


        public void Cancel()
        {
            TryClose();
        }
        


    }
}
