using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.WrappingClasses
{
    public class EscapeInfo : WrappingClassBase
    {

        public int ID { get; set; }
        public DateTime? Date { get; set; }

        public int? AnimalID { get; set; }
        public string AnimalName { get; set; }
        public string Description { get; set; }

        public static List<List<string>> ConvertToList(BindableCollection<EscapeInfo> escapes)
        {
            List<List<string>> result = new List<List<string>>();
            List<string> headers = new List<string> { "ID", "ID zvířete", "Jméno zvířete", "Datum" ,  "Popis" };
            result.Add(headers);

            foreach (EscapeInfo escape in escapes)
            {
                List<string> ls = new List<string>();
                ls.Add(escape.ID.ToString());
                ls.Add(escape.AnimalID.ToString());
                ls.Add(escape.AnimalName);
                ls.Add(escape.Date.ToString());
                ls.Add(escape.Description);
                
                result.Add(ls);
            }
            return result;
        }
    }
}
