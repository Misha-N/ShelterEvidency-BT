using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

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
        public string Note { get; set; }
        #endregion

        public void SaveAnimal()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();

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
                Note = Note,
            };
            db.Animals.InsertOnSubmit(animal);
            db.SubmitChanges();

            ID = animal.ID;
        }

        public void UpdateAnimal()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
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
            animal.OwnerID = OwnerID;
            animal.NewOwnerID = NewOwnerID;
            animal.VetID = VetID;
            animal.Note = Note;

            db.SubmitChanges();
        }


        public void GetAnimal(int animalID)
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
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
                OwnerID = animal.OwnerID;
                NewOwnerID = animal.NewOwnerID;
                VetID = animal.VetID;
                Note = animal.Note;
            }
        }

        public static List<AnimalInfo> ReturnAnimals()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();

            var results = (from animal in db.Animals
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
                                Owner = animal.People.FirstName + " " + animal.People.LastName,
                                NewOwner = animal.People1.FirstName + " " + animal.People.LastName,
                                Vet = animal.People2.FirstName + " " + animal.People.LastName,
                                Note = animal.Note
                            }).ToList();
            return results;
        }

        public static List<Animals> ReturnSpecificAnimals(string searchValue)
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.Animals.ToList();
        }

    }

}
