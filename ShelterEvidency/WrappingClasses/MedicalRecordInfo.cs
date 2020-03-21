using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.WrappingClasses
{
    public class MedicalRecordInfo
    {
        public int ID { get; set; }

        public string RecordName { get; set; }
        public DateTime? Date { get; set; }

        public int? AnimalID { get; set; }
        public string AnimalName { get; set; }

        public int? CostID { get; set; }

        public int? VetID { get; set; }

        public string VetName { get; set; }
        public string Description { get; set; }
    }
}

