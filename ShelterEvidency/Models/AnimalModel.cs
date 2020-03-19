using Caliburn.Micro;
using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class AnimalModel
    {
        #region Atributes/Properties
        public int? ID { get; set; }
        public string Name { get; set; }
        public string ChipNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? SexID { get; set; }
        public int? OwnerID { get; set; }
        public int? NewOwnerID { get; set; }
        public int? VetID { get; set; }
        public int? SpeciesID { get; set; }
        public int? BreedID { get; set; }
        public int? CrossBreedID { get; set; }
        public int? CoatTypeID { get; set; }
        public int? FurColorID { get; set; }
        public int? FeedRation { get; set; }
        public int? Weight { get; set; }
        public string Note { get; set; }
        public bool? Castration { get; set; }
        public bool? InShelter { get; set; }
        public string FolderPath { get; set; }
        public string ImagePath { get; set; }

        #endregion

        public AnimalModel()
        {
            Castration = false;
            InShelter = true;
        }

        public void SaveAnimal()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                Animals animal = new Animals
                {
                    Name = Name,
                    ChipNumber = ChipNumber,
                    Birth = BirthDate,
                    SexID = SexID,
                    SpeciesID = SpeciesID,
                    BreedID = BreedID,
                    CrossBreedID = CrossBreedID,
                    CoatTypeID = CoatTypeID,
                    FurColorID = FurColorID,
                    OwnerID = OwnerID,
                    NewOwnerID = NewOwnerID,
                    VetID = VetID,
                    FeedRation = FeedRation,
                    Weight = Weight,
                    Note = Note,
                    Castration = Castration,
                    InShelter = InShelter,
                    FolderPath = FolderPath,
                    ImagePath = ImagePath

                };
                db.Animals.InsertOnSubmit(animal);
                db.SubmitChanges();

                ID = animal.ID;

                CreateDocumentFolder();
                UpdateAnimal();
            }
        }

        public void UpdateAnimal()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                Animals animal = db.Animals.FirstOrDefault(i => i.ID == ID);

                animal.Name = Name;
                animal.ChipNumber = ChipNumber;
                animal.Birth = BirthDate;
                animal.SexID = SexID;
                animal.SpeciesID = SpeciesID;
                animal.BreedID = BreedID;
                animal.CrossBreedID = CrossBreedID;
                animal.CoatTypeID = CoatTypeID;
                animal.FurColorID = FurColorID;
                animal.FeedRation = FeedRation;
                animal.Weight = Weight;
                animal.OwnerID = OwnerID;
                animal.NewOwnerID = NewOwnerID;
                animal.VetID = VetID;
                animal.Note = Note;
                animal.Castration = Castration;
                animal.InShelter = InShelter;
                animal.FolderPath = FolderPath;
                animal.ImagePath = ImagePath;

                db.SubmitChanges();
            }
        }


        public void GetAnimal(int? animalID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var animal = db.Animals.FirstOrDefault(i => i.ID == animalID);
                if (animal != null)
                {
                    ID = animal.ID;
                    Name = animal.Name;
                    ChipNumber = animal.ChipNumber;
                    BirthDate = animal.Birth;
                    SexID = animal.SexID;
                    SpeciesID = animal.SpeciesID;
                    BreedID = animal.BreedID;
                    CrossBreedID = animal.CrossBreedID;
                    CoatTypeID = animal.CoatTypeID;
                    FurColorID = animal.FurColorID;
                    FeedRation = animal.FeedRation;
                    Weight = animal.Weight;
                    OwnerID = animal.OwnerID;
                    NewOwnerID = animal.NewOwnerID;
                    VetID = animal.VetID;
                    Note = animal.Note;
                    Castration = animal.Castration;
                    InShelter = animal.InShelter;
                    FolderPath = animal.FolderPath;
                    ImagePath = animal.ImagePath;
                }
            }
        }

        public static AnimalInfo GetAnimalInfo(int? animalID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var animal = db.Animals.FirstOrDefault(i => i.ID == animalID);
                if (animal != null)
                {
                    AnimalInfo info = new AnimalInfo
                    {
                        ID = animal.ID,
                        Name = animal.Name,
                        ChipNumber = animal.ChipNumber,
                        BirthDate = animal.Birth,
                        Sex = animal.Sexes.SexName,
                        Species = animal.Species.SpeciesName,
                        Breed = animal.Breeds.BreedName,
                        CoatType = animal.CoatTypes.CoatTypeName,
                        FurColor = animal.FurColors.FurColorName,
                        Castration = animal.Castration,
                        InShelter = animal.InShelter,
                        FolderPath = animal.FolderPath,
                        ImagePath = animal.ImagePath

                    };
                    return info;
                }
                else
                    return new AnimalInfo();
            }
        }

        public static BindableCollection<AnimalInfo> ReturnAnimals()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results =
                    (from animal in db.Animals
                               select new AnimalInfo
                               {
                                    ID = animal.ID,
                                    Name = animal.Name,
                                    ChipNumber = animal.ChipNumber,
                                    BirthDate = animal.Birth,
                                    Sex = animal.Sexes.SexName,
                                    Species = animal.Species.SpeciesName,
                                    Breed = animal.Breeds.BreedName,
                                    CrossBreed = animal.Breeds1.BreedName,
                                    CoatType = animal.CoatTypes.CoatTypeName,
                                    FurColor = animal.FurColors.FurColorName,
                                    FeedRation = animal.FeedRation,
                                    Weight = animal.Weight,
                                    Owner = animal.People.FirstName + " " + animal.People.LastName,
                                    NewOwner = animal.People1.FirstName + " " + animal.People1.LastName,
                                    Vet = animal.People2.FirstName + " " + animal.People2.LastName,
                                    Note = animal.Note,
                                    Castration = animal.Castration,
                                    InShelter = animal.InShelter,
                                    FolderPath = animal.FolderPath,
                                    ImagePath = animal.ImagePath
                               });
                

                return new BindableCollection<AnimalInfo>(results);
            }
        }

        public static BindableCollection<AnimalInfo> ReturnSpecificAnimals(string searchValue)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from animal in db.Animals
                               where ((animal.Name.Contains(searchValue)) ||
                                      (animal.ID.ToString().Equals(searchValue)) ||
                                      (animal.Species.SpeciesName.Contains(searchValue)) ||
                                      (animal.Breeds.BreedName.Contains(searchValue)))
                               select new AnimalInfo 
                               {
                                   ID = animal.ID,
                                   Name = animal.Name,
                                   ChipNumber = animal.ChipNumber,
                                   BirthDate = animal.Birth,
                                   Sex = animal.Sexes.SexName,
                                   Species = animal.Species.SpeciesName,
                                   Breed = animal.Breeds.BreedName,
                                   CrossBreed = animal.Breeds1.BreedName,
                                   CoatType = animal.CoatTypes.CoatTypeName,
                                   FurColor = animal.FurColors.FurColorName,
                                   FeedRation = animal.FeedRation,
                                   Weight = animal.Weight,
                                   Owner = animal.People.FirstName + " " + animal.People.LastName,
                                   NewOwner = animal.People1.FirstName + " " + animal.People1.LastName,
                                   Vet = animal.People2.FirstName + " " + animal.People2.LastName,
                                   Note = animal.Note,
                                   Castration = animal.Castration,
                                   InShelter = animal.InShelter,
                                   FolderPath = animal.FolderPath,
                                   ImagePath = animal.ImagePath
                               });
                return new BindableCollection<AnimalInfo>(results);
            }
        }

        public static BindableCollection<AnimalInfo> ReturnAnimalsInShelter()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from animal in db.Animals
                               where ((animal.InShelter.Equals(true)))
                               select new AnimalInfo
                               {
                                   ID = animal.ID,
                                   Name = animal.Name,
                                   ChipNumber = animal.ChipNumber,
                                   BirthDate = animal.Birth,
                                   Sex = animal.Sexes.SexName,
                                   Species = animal.Species.SpeciesName,
                                   Breed = animal.Breeds.BreedName,
                                   CrossBreed = animal.Breeds1.BreedName,
                                   CoatType = animal.CoatTypes.CoatTypeName,
                                   FurColor = animal.FurColors.FurColorName,
                                   FeedRation = animal.FeedRation,
                                   Weight = animal.Weight,
                                   Owner = animal.People.FirstName + " " + animal.People.LastName,
                                   NewOwner = animal.People1.FirstName + " " + animal.People1.LastName,
                                   Vet = animal.People2.FirstName + " " + animal.People2.LastName,
                                   Note = animal.Note,
                                   Castration = animal.Castration,
                                   InShelter = animal.InShelter,
                                   FolderPath = animal.FolderPath,
                                   ImagePath = animal.ImagePath
                               });
                return new BindableCollection<AnimalInfo>(results);
            }
        }

        public void CreateDocumentFolder()
        {
            System.IO.Directory.CreateDirectory("AnimalDocuments");
            string currentPath = Directory.GetCurrentDirectory() + "\\AnimalDocuments";
            if (!Directory.Exists(Path.Combine(currentPath, ID.ToString())))
                Directory.CreateDirectory(Path.Combine(currentPath, ID.ToString()));
            FolderPath = Path.Combine(currentPath, ID.ToString());
        }

        public static string ReturnFolder(int? animalID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var folder = db.Animals.FirstOrDefault(i => i.ID == animalID);
                return folder.FolderPath;
            }
        }

        public void Adopt(int adoptedBy)
        {
            InShelter = false;
            NewOwnerID = adoptedBy;
            UpdateAnimal();

        }

        public void Return()
        {
            InShelter = true;
            NewOwnerID = null;
            UpdateAnimal();

        }

    }

}
