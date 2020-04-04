using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.WrappingClasses
{
    public class IncidentInfo : WrappingClassBase
    {
        public int ID { get; set; }

        public DateTime? Date { get; set; }

        public int? AnimalID { get; set; }
        public string AnimalName { get; set; }

        public int? Severity { get; set; }
        public string Description { get; set; }

        public static List<List<string>> ConvertToList(BindableCollection<IncidentInfo> incidents)
        {
            List<List<string>> result = new List<List<string>>();
            List<string> headers = new List<string> { "ID", "Datum","ID zvířete", "Jméno zvířete", "Závažnost", "Popis" };
            result.Add(headers);

            foreach (IncidentInfo incident in incidents)
            {
                List<string> ls = new List<string>
                {
                    incident.ID.ToString(),
                    incident.Date.ToString(),
                    incident.AnimalID.ToString(),
                    incident.AnimalName.ToString(),
                    incident.Severity.ToString(),
                    incident.Description
                };

                result.Add(ls);
            }
            return result;
        }
    }
}
