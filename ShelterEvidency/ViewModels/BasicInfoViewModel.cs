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
        public int ID
        {
            get
            {
                return Animal.ID;
            }
            set
            {
                Animal.ID = value;
                NotifyOfPropertyChange(() => ID);
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

        public int? CrossBreed
        {
            get
            {
                return Animal.CrossBreedID;
            }
            set
            {
                Animal.CrossBreedID = value;
                NotifyOfPropertyChange(() => CrossBreed);
            }
        }
        public DateTime? BirthDate
        {
            get
            {
                return Animal.BirthDate;
            }
            set
            {
                Animal.BirthDate = value;
                NotifyOfPropertyChange(() => BirthDate);
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

        public int? FeedRation
        {
            get
            {
                return Animal.FeedRation;
            }
            set
            {
                Animal.FeedRation = value;
                NotifyOfPropertyChange(() => FeedRation);
            }
        }
        public string Note
        {
            get
            {
                return Animal.Note;
            }
            set
            {
                Animal.Note = value;
                NotifyOfPropertyChange(() => Note);
            }
        }

        #endregion

        #region List Setting
        public List<Database.Sexes> SexList
        {
            get
            {
                return SexModel.ReturnSexes();
            }
        }
        public List<Database.Breeds> BreedList
        {
            get
            {
                return BreedModel.ReturnBreeds(Species);
            }
        }
        public List<Database.Species> SpeciesList
        {
            get
            {
                return SpeciesModel.ReturnSpecies();
            }
        }
        public List<Database.CoatTypes> CoatTypeList
        {
            get
            {
                return CoatTypeModel.ReturnCoatTypes();
            }
        }
        public List<Database.FurColors> FurColorList
        {
            get
            {
                return FurColorModel.ReturnFurColors();
            }
        }
        #endregion

        public void UpdateAnimal()
        {
            Animal.UpdateAnimal();
        }

        public void Cancel()
        {
            TryClose();
        }


    }
}
