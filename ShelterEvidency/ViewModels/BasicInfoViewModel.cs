using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ShelterEvidency.ViewModels
{
    public class BasicInfoViewModel: Screen
    {

        public AnimalModel Animal { get; set; }
        public ImageModel Image { get; set; }
        public BasicInfoViewModel(int animalID)
        {
            SetLists();
            Animal = new AnimalModel();
            Animal.GetAnimal(animalID);
            Image = new ImageModel();
            Image.GetImage(animalID);
        }

        #region Binded Properties
        public BitmapImage AnimalImage
        {
            get
            {
                return Image.Image;
            }
            set
            {
                Image.Image = value;
                NotifyOfPropertyChange(() => Image);
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
                Animal.ChipNumber= value;
                NotifyOfPropertyChange(() => ChipNumber);
            }
        }
        public int? Sex
        {
            get
            {
                return Animal.SexID;
            }
            set
            {
                Animal.SexID = value;
                NotifyOfPropertyChange(() => Sex);
            }
        }
        public int? Species
        {
            get
            {
                return Animal.SpeciesID;
            }
            set
            {
                Animal.SpeciesID = value;
                NotifyOfPropertyChange(() => Species);
            }
        }
        public int? Breed
        {
            get
            {
                return Animal.BreedID;
            }
            set
            {
                Animal.BreedID = value;
                NotifyOfPropertyChange(() => Breed);
            }
        }
        public int? CoatType
        {
            get
            {
                return Animal.CoatTypeID;
            }
            set
            {
                Animal.CoatTypeID = value;
                NotifyOfPropertyChange(() => CoatType);
            }
        }
        public int? FurColor
        {
            get
            {
                return Animal.FurColorID;
            }
            set
            {
                Animal.FurColorID = value;
                NotifyOfPropertyChange(() => FurColor);
            }
        }
        
        
        
        #endregion

        #region List Setting
        public List<Sexes> SexList { get; private set; }
        public List<Breeds> BreedList { get; private set; }
        public List<Species> SpeciesList { get; private set; }
        public List<CoatTypes> CoatTypeList { get; private set; }
        public List<FurColors> FurColorList { get; private set; }

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
            SexList = SexModel.ReturnSexes();
        }

        private void SetBreedList()
        {
            BreedList = BreedModel.ReturnBreeds();
        }

        private void SetSpeciesList()
        {
            SpeciesList = SpeciesModel.ReturnSpecies();
        }

        private void SetCoatTypeList()
        {
            CoatTypeList = CoatTypeModel.ReturnCoatTypes();
        }

        private void SetFurColorList()
        {
            FurColorList = FurColorModel.ReturnFurColors();
        }

        #endregion

        public void UpdateAnimal()
        {
            Animal.UpdateAnimal();
        }

    }
}
