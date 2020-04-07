using Caliburn.Micro;
using ShelterEvidency.Database;
using System;
using System.IO;
using System.Linq;
using System.Windows;

namespace ShelterEvidency.Models
{
    public class AnimalModel
    {
        #region Atributes/Properties
        public int ID { get; set; }
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
        public bool? IsDead { get; set; }
        public string FolderPath { get; set; }
        public string ImagePath { get; set; }

        #endregion

        public AnimalModel()
        {
            Castration = false;
            InShelter = true;
            IsDead = false;
        }

        public void SaveAnimal()
        {

            try
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
                        IsDead = IsDead,
                        FolderPath = FolderPath,
                        ImagePath = ImagePath,

                    };
                    db.Animals.InsertOnSubmit(animal);
                    db.SubmitChanges();

                    ID = animal.ID;

                    CreateDocumentFolder();
                    UpdateAnimal();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void UpdateAnimal()
        {
            try
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
                    animal.IsDead = IsDead;
                    animal.FolderPath = FolderPath;
                    animal.ImagePath = ImagePath;

                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void GetAnimal(int? animalID)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var animal = db.Animals.FirstOrDefault(i => i.ID == animalID);
                    if (animal != null && animal.IsDeleted == null)
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
                        IsDead = animal.IsDead;
                        FolderPath = animal.FolderPath;
                        ImagePath = animal.ImagePath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static AnimalInfo GetAnimalInfo(int? animalID)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    db.DeferredLoadingEnabled = false;

                    var result =
                    (from animal in db.Animals
                     where (animal.ID.Equals(animalID))
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
                         Castration = animal.Castration,

                     });
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new AnimalInfo();
            }
        }

        public static BindableCollection<AnimalInfo> ReturnAnimals()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var results =
                        (from animal in db.Animals
                         where (animal.IsDeleted.Equals(null))
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
                             IsDead = animal.IsDead,
                             FolderPath = animal.FolderPath,
                             ImagePath = animal.ImagePath
                         });


                    return new BindableCollection<AnimalInfo>(results);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<AnimalInfo>();
            }
        }

        public static BindableCollection<AnimalInfo> ReturnSpecificAnimals(string searchValue)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var results = (from animal in db.Animals
                                   where ((animal.IsDeleted.Equals(null)) &&
                                          ((animal.Name.Contains(searchValue)) ||
                                          (animal.ID.ToString().Equals(searchValue)) ||
                                          (animal.Species.SpeciesName.Contains(searchValue)) ||
                                          (animal.Breeds.BreedName.Contains(searchValue))))
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
                                       IsDead = animal.IsDead,
                                       FolderPath = animal.FolderPath,
                                       ImagePath = animal.ImagePath
                                   });
                    return new BindableCollection<AnimalInfo>(results);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<AnimalInfo>();
            }
        }

        public static BindableCollection<AnimalInfo> ReturnAnimalsInShelter()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var results = (from animal in db.Animals
                                   where ((animal.InShelter.Equals(true)) && animal.IsDeleted.Equals(null))
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
                                       IsDead = animal.IsDead,
                                       FolderPath = animal.FolderPath,
                                       ImagePath = animal.ImagePath
                                   });
                    return new BindableCollection<AnimalInfo>(results);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<AnimalInfo>();
            }
        }

        public static BindableCollection<AnimalInfo> LastAnimals(int count)
        {
            try
            {

                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var results = (from animal in db.Animals
                                   where ((animal.InShelter.Equals(true)) && animal.IsDeleted.Equals(null))
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
                                       IsDead = animal.IsDead,
                                       FolderPath = animal.FolderPath,
                                       ImagePath = animal.ImagePath
                                   }).OrderByDescending(x => x.ID).Take(count);
                    return new BindableCollection<AnimalInfo>(results);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<AnimalInfo>();
            }
        }

        public void CreateDocumentFolder()
        {
            try
            {
                System.IO.Directory.CreateDirectory("AnimalDocuments");
                string currentPath = Directory.GetCurrentDirectory() + "\\AnimalDocuments";
                if (!Directory.Exists(Path.Combine(currentPath, ID.ToString())))
                    Directory.CreateDirectory(Path.Combine(currentPath, ID.ToString()));
                FolderPath = Path.Combine(currentPath, ID.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string ReturnFolder(int? animalID)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var folder = db.Animals.FirstOrDefault(i => i.ID == animalID);
                    return folder.FolderPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return String.Empty;
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

        public static void AnimalDied(int id)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var animal = db.Animals.Single(x => x.ID == id);
                    animal.IsDead = true;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void MarkAsDeleted(int id)
        {
            try
            {

                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var animal = db.Animals.Single(x => x.ID == id);
                    animal.IsDeleted = DateTime.Now;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool ValidValues()
        {
            if (!String.IsNullOrEmpty(Name))
                return true;
            else
                return false;
        }

        public static void RestoreDeleted(DateTime since, DateTime to)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var records = (from record in db.Animals
                               where record.IsDeleted >= since && record.IsDeleted <= to
                               select record).ToList();

                foreach (var record in records)
                {
                    record.IsDeleted = null;
                }


                db.SubmitChanges();
            }
        }

    }

}
