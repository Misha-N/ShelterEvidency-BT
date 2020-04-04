using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.WrappingClasses
{
    public class StayInfo : WrappingClassBase
    {
        public int ID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FindDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int? AnimalID { get; set; }
        public string AnimalName { get; set; }
        public bool? Adopted { get; set; }
        public bool? Escaped { get; set; }
        public bool? Died { get; set; }
        public string FindPlace { get; set; }
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

        public static List<List<string>> ConvertToList(BindableCollection<StayInfo> stays)
        {
            List<List<string>> result = new List<List<string>>();
            List<string> headers = new List<string> { "ID", "Začátek", "Konec", "Datum nálezu", "Místo nálezu", 
                "ID zvířete", "Jméno zvířete", "Adopce", "Útěk", "Úhyn", "Poznámka" };
            result.Add(headers);

            foreach (StayInfo stay in stays)
            {
                List<string> ls = new List<string>
                {
                    stay.ID.ToString(),
                    stay.StartDate.ToString(),
                    stay.FinishDate.ToString(),
                    stay.FindDate.ToString(),
                    stay.FindPlace.ToString(),
                    stay.AnimalID.ToString(),
                    stay.AnimalName,
                    stay.Adopted.ToString(),
                    stay.Escaped.ToString(),
                    stay.Died.ToString(),
                    stay.Note.ToString()
                };

                result.Add(ls);
            }
            return result;
        }

    }
}
