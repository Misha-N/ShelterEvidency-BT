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
        #region Initialization
        public ImageModel Image { get; set; }
        public AnimalModel Animal { get; set; }
        public StayModel Stay { get; set; }

        readonly SearchAnimalViewModel prnt;

        public AddAnimalViewModel(SearchAnimalViewModel parent = null)
        {
            prnt = parent;
            Image = new ImageModel();
            Animal = new AnimalModel();
            Stay = new StayModel();
        }

        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            LoadData();
        }


        private async void LoadData()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                SexList = SexModel.ReturnSexes();
                SpeciesList = SpeciesModel.ReturnSpecies();
                BreedList = BreedModel.ReturnBreeds(null);
                CoatTypeList = CoatTypeModel.ReturnCoatTypes();
                FurColorList = FurColorModel.ReturnFurColors();
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

        #endregion

        #region List Setting

        private BindableCollection<Database.Sexes> _sexlist;
        public BindableCollection<Database.Sexes> SexList
        {
            get
            {
                return _sexlist;
            }
            set
            {
                _sexlist = value;
                NotifyOfPropertyChange(() => SexList);
            }
        }

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
                UpdateBreeds(value);
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

        #region Stay Bindings
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

        #endregion

        #region Methods

        private async void UpdateBreeds(int? speciesID)
        {
            await Task.Run(() =>
            {
                BreedList = BreedModel.ReturnBreeds(speciesID);
                NotifyOfPropertyChange(() => Breed);
                NotifyOfPropertyChange(() => CrossBreed);
            });
        }

        public void SaveToDatabase()
        {
            Animal.ImagePath = Image.SaveImage();
            Animal.SaveAnimal();
            Stay.AnimalID = Animal.ID;
            Stay.SaveStay();
            MessageBox.Show(Animal.Name + " přidán do evidence.");
            if(prnt != null)
                prnt.UpdateAnimals();
            TryClose();
        }
        public void LoadImage()
        {
            OpenFileDialog op = new OpenFileDialog
            {
               Title = "Vyberte obrázek",
               Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png"
            };
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

        #endregion

    }
}
