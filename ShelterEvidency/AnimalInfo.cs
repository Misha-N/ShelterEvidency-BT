using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency
{
    public class AnimalInfo
    {
        public int ID { get; set; }
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
        public string Note { get; set; }
    }
}
