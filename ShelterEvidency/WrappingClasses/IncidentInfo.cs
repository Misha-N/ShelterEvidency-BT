using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.WrappingClasses
{
    public class IncidentInfo
    {
        public int ID { get; set; }

        public DateTime? Date { get; set; }

        public int? AnimalID { get; set; }
        public string AnimalName { get; set; }

        public int? Severity { get; set; }
        public string Description { get; set; }
    }
}
