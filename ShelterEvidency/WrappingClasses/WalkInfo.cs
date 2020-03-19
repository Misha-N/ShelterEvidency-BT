using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.WrappingClasses
{
    public class WalkInfo
    {
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public string Note { get; set; }
        public string AnimalName { get; set; }
        public string PersonName { get; set; }
    }
}
