using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.WrappingClasses
{
    public class WalkInfo : WrappingClassBase
    {
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public string Note { get; set; }
        public int? AnimalID { get; set; }
        public string AnimalName { get; set; }
        public int? PersonID { get; set; }
        public string PersonName { get; set; }
        public static List<List<string>> ConvertToList(BindableCollection<WalkInfo> walks)
        {
            List<List<string>> result = new List<List<string>>();
            List<string> headers = new List<string> { "ID", "Datum", "ID zvířete", "Jméno zvířete","ID venčitele", "Jméno venčitele", "Poznámka" };
            result.Add(headers);

            foreach (WalkInfo walk in walks)
            {
                List<string> ls = new List<string>
                {
                    walk.ID.ToString(),
                    walk.Date.ToString(),
                    walk.AnimalID.ToString(),
                    walk.AnimalName.ToString(),
                    walk.PersonID.ToString(),
                    walk.PersonName,
                    walk.Note

                };

                result.Add(ls);
            }
            return result;
        }
    }
}
