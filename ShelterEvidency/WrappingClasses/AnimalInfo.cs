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
                List<string> ls = new List<string>
                {
                    animal.ID.ToString(),
                    animal.Name,
                    animal.ChipNumber,
                    animal.BirthDate.ToString(),
                    animal.Sex,
                    animal.Owner,
                    animal.NewOwner,
                    animal.Vet,
                    animal.Species,
                    animal.Breed,
                    animal.CrossBreed,
                    animal.FurColor,
                    animal.CoatType,
                    animal.FeedRation.ToString(),
                    animal.Weight.ToString(),
                    animal.Note,
                    animal.Castration.ToString(),
                    animal.InShelter.ToString(),
                    animal.IsDead.ToString()
                };

                result.Add(ls);
            }
            return result;
        }

    }
}
