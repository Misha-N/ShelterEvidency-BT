using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency
{
    public class AdoptionInfo
    {
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public string AnimalName { get; set; }
        public string OwnerName { get; set; }
        public bool? Returned { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string ReturnReason { get; set; }

    }
}

