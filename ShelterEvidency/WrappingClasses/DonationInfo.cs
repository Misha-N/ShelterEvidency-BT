using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.WrappingClasses
{
    public class DonationInfo : WrappingClassBase
    {
        public int ID { get; set; }
        public int? Amount { get; set; }
        public DateTime? Date { get; set; }
        public string DonatorName { get; set; }
        public int? DonatorID { get; set; }
        public string Description { get; set; }
        public string DonationName { get; set; }

    }
}

