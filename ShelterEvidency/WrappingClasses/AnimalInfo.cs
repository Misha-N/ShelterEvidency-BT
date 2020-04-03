using Caliburn.Micro;
using ShelterEvidency.WrappingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency
{
    public class AnimalInfo : WrappingClassBase
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string ChipNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Sex { get; set; }
        public string Owner { get; set; }
        public string NewOwner { get; set; }
        public string Vet { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string CrossBreed { get; set; }
        public string CoatType { get; set; }
        public string FurColor { get; set; }
        public int? FeedRation { get; set; }
        public int? Weight { get; set; }
        public string Note { get; set; }
        public bool? Castration { get; set; }
        public string FolderPath { get; set; }
        public string ImagePath { get; set; }
        public bool? InShelter { get; set; }
        public bool? IsDead { get; set; }


        public static List<List<string>> ConvertToList(BindableCollection<AnimalInfo> animals)
        {
            List<List<string>> result = new List<List<string>>();
            List<string> headers = new List<string> { "ID", "Jméno", "Číslo čipu", "Datum narození", "Pohlaví", "Vlastník", "Nový vlastník",
                "Veterinář", "Druh", "Plemeno", "Kříženec", "Barva srsti", "Typ srsti", "Krmná dávka", "Váha", "Poznámka", "Kastrát", "V útulku", "Úhyn" };
            result.Add(headers);

            foreach (AnimalInfo animal in animals)
            {
                List<string> ls = new List<string>();
                ls.Add(animal.ID.ToString());
                ls.Add(animal.Name);
                ls.Add(animal.ChipNumber);
                ls.Add(animal.BirthDate.ToString());
                ls.Add(animal.Sex);
                ls.Add(animal.Owner);
                ls.Add(animal.NewOwner);
                ls.Add(animal.Vet);
                ls.Add(animal.Species);
                ls.Add(animal.Breed);
                ls.Add(animal.CrossBreed);
                ls.Add(animal.FurColor);
                ls.Add(animal.CoatType);
                ls.Add(animal.FeedRation.ToString());
                ls.Add(animal.Weight.ToString());
                ls.Add(animal.Note);
                ls.Add(animal.Castration.ToString());
                ls.Add(animal.InShelter.ToString());
                ls.Add(animal.IsDead.ToString());

                result.Add(ls);
            }
            return result;
        }

    }
}
