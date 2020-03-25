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
        #region Initialize
        public AnimalModel Animal { get; set; }
        public ImageModel Image { get; set; }
        public BasicInfoViewModel(int animalID)
        {
            Animal = new AnimalModel();
            Animal.GetAnimal(animalID);
            Image = new ImageModel();
            Image.GetImage(Animal.ImagePath);
        }

        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            Task.Run(() => LoadData());
        }


        private async Task LoadData()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                SexList = SexModel.ReturnSexes();
                SpeciesList = SpeciesModel.ReturnSpecies();
                BreedList = BreedModel.ReturnBreeds(Animal.SpeciesID);
                CrossBreedList = BreedModel.ReturnBreeds(Animal.SpeciesID);
                CoatTypeList = CoatTypeModel.ReturnCoatTypes();
                FurColorList = FurColorModel.ReturnFurColors();
                VetList = PersonModel.ReturnVets();
                OwnerList = PersonModel.ReturnOwners();
                NewOwnerList = PersonModel.ReturnOwners();
            });
            IsWorking = false;
        }

        private bool _isWorking;

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

        public int? Owner
        {
            get
            {
                return Animal.OwnerID;
            }
            set
            {
                Animal.OwnerID = value;
                NotifyOfPropertyChange(() => Owner);
            }
        }

        public int? NewOwner
        {
            get
            {
                return Animal.NewOwnerID;
            }
            set
            {
                Animal.NewOwnerID = value;
                NotifyOfPropertyChange(() => NewOwner);
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

        public bool? InShelter
        {
            get
            {
                return Animal.InShelter;
            }
            set
            {
                Animal.InShelter = value;
                NotifyOfPropertyChange(() => InShelter);
            }
        }

        public bool? IsDead
        {
            get
            {
                return Animal.IsDead;
            }
            set
            {
                Animal.IsDead = value;
                NotifyOfPropertyChange(() => InShelter);
            }
        }

        #endregion

        #region List Setting

        private BindableCollection<PersonInfo> _vetlist;
        public BindableCollection<PersonInfo> VetList
        {
            get
            {
                return _vetlist;
            }
            set
            {
                _vetlist = value;
                NotifyOfPropertyChange(() => VetList);
            }
        }

        private BindableCollection<PersonInfo> _ownerlist;
        public BindableCollection<PersonInfo> OwnerList
        {
            get
            {
                return _ownerlist;
            }
            set
            {
                _ownerlist = value;
                NotifyOfPropertyChange(() => OwnerList);
            }
        }
        private BindableCollection<PersonInfo> _newownerlist;
        public BindableCollection<PersonInfo> NewOwnerList
        {
            get
            {
                return _newownerlist;
            }
            set
            {
                _newownerlist = value;
                NotifyOfPropertyChange(() => NewOwnerList);
            }
        }

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

        private BindableCollection<Database.Breeds> _crossbreedlist;
        public BindableCollection<Database.Breeds> CrossBreedList
        {
            get
            {
                return _crossbreedlist;
            }
            set
            {
                _crossbreedlist = value;
                NotifyOfPropertyChange(() => CrossBreedList);
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

        #region Methods

        private async void UpdateBreeds(int? speciesID)
        {
            await Task.Run(() =>
            {
                BreedList = BreedModel.ReturnBreeds(speciesID);
                CrossBreedList = BreedModel.ReturnBreeds(speciesID);
                NotifyOfPropertyChange(() => Breed);
                NotifyOfPropertyChange(() => CrossBreed);
            });
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
        public void UpdateAnimal()
        {
            Animal.ImagePath = Image.SaveImage();
            Animal.UpdateAnimal();
            MessageBox.Show("Aktualizováno.");
        }

        #endregion



    }
}
