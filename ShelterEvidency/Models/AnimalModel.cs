using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class AnimalModel
    {
        public string Name { get; set; }
        public string ChipNumber { get; set; }
        public string Sex { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string CoatType { get; set; }
        public string FurColor { get; set; }

        public void SaveAnimal()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();

            Animals animal = new Animals
                {
                    Name = Name,
                    ChipNumber = ChipNumber,
                    Sex = Sex,
                    Species = Species,
                    Breed = Breed,
                    CoatType = CoatType,
                    FurColor = FurColor
                };
            db.Animals.InsertOnSubmit(animal);
            db.SubmitChanges();
            
        }

        public void SetInformations(string name, string chipNumber, string sex, string species, string breed, string coatType, string furColor)
        {
            Name = name;
            ChipNumber = chipNumber;
            Sex = sex;
            Species = species;
            Breed = breed;
            CoatType = coatType;
            FurColor = furColor;
        }

    }

}
