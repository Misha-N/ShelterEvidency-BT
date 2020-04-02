using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.WrappingClasses
{
    class DeathInfo
    {
        public int ID { get; set; }
        public DateTime? Date { get; set; }

        public int? AnimalID { get; set; }
        public string AnimalName { get; set; }
        public string Description { get; set; }

        public bool? Euthanasia { get; set; }
        public bool? Natural { get; set; }
        public bool? Other { get; set; }

    }
}
