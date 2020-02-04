using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShelterEvidency.Models;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.IO;
using ShelterEvidency.Database;

namespace ShelterEvidency.ViewModels
{
    public class AddAnimalViewModel: Conductor<object>
    {
        public ImageModel Image { get; set; }
        public AnimalModel Animal { get; set; }
        public StayModel Stay { get; set; }

        public AddAnimalViewModel()
        {
            Image = new ImageModel();
            Animal = new AnimalModel();
            Stay = new StayModel();
        }

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

        #region AddAnimal Atributes Bindings
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
                Animal.ChipNumber = value;
                NotifyOfPropertyChange(() => ChipNumber);
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

        public int? Weight
        {
            get
            {
                return Animal.Weight;
            }
            set
            {
                Animal.Weight = value;
                NotifyOfPropertyChange(() => Weight);
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

        public BitmapImage AnimalImage
        {
            get
            {
                return Image.Image;
            }
            set
            {
                Image.Image = value;
                NotifyOfPropertyChange(() => AnimalImage);
            }
        }
        #endregion

        public DateTime? StayStartDate
        {
            get
            {
                return Stay.StartDate;
            }
            set
            {
                Stay.StartDate = value;
                NotifyOfPropertyChange(() => StayStartDate);
            }
        }

        public void SaveToDatabase()
        {
            Animal.SaveAnimal();
            Stay.AnimalID = Animal.ID;
            Image.AnimalID = Animal.ID;
            Stay.SaveStay();
            Image.SaveImage();
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
                Image.Image = new BitmapImage(new Uri(op.FileName));
                Image.ImagePath = Path.GetFullPath(op.FileName);
            }

            NotifyOfPropertyChange(() => AnimalImage);
        }
        public void Cancel()
        {
            TryClose();
        }
        
    }
}
