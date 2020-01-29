using Caliburn.Micro;
using Microsoft.Win32;
using ShelterEvidency.Database;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public int? ID
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
        public string AnimalName
        {
            get
            {
                return Animal.Name;
            }
            set
            {
                Animal.Name = value;
                NotifyOfPropertyChange(() => AnimalName);
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

        public int? Vet
        {
            get
            {
                return Animal.VetID;
            }
            set
            {
                Animal.VetID = value;
                NotifyOfPropertyChange(() => Vet);
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
                NotifyOfPropertyChange(() => BreedList);
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

        public bool? Castration
        {
            get
            {
                return Animal.Castration;
            }
            set
            {
                Animal.Castration = value;
                NotifyOfPropertyChange(() => Castration);
            }
        }

        #endregion

        #region List Setting

        public List<PersonInfo> VetList
        {
            get
            {
                return PersonModel.ReturnVets();
            }
        }

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

        public void LoadImage()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Vyberte obrázek";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Image.Image = new BitmapImage(new Uri(op.FileName));
                Image.ImagePath = Path.GetFullPath(op.FileName);
                Image.AnimalID = Animal.ID;
            }

            NotifyOfPropertyChange(() => AnimalImage);
        }
        public void UpdateAnimal()
        {
            Animal.UpdateAnimal();
            Image.UpdateImage();
            MessageBox.Show("updated");
        }



    }
}
