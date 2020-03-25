using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.WrappingClasses
{
    public class StayInfo
    {
        public int ID { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? FinishDate { get; set; }
        public int? AnimalID { get; set; }
        public string AnimalName { get; set; }
        public bool? Adopted { get; set; }
        public bool? Escaped { get; set; }
        public bool? Died { get; set; }
        public string Note { get; set; }

        public int? DaysInShelter
        {
            get
            {
                if (StartDate != null && FinishDate != null)
                    return (int)((DateTime)FinishDate - (DateTime)StartDate).TotalDays;
                else
                    return null;
            }
        }
    }
}
