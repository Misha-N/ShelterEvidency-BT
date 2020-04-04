using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.WrappingClasses
{
    public class CostInfo : WrappingClassBase
    {
        public int ID { get; set; }
        public int? Price { get; set; }
        public DateTime? Date { get; set; }
        public string CostName { get; set; }
        public int? AnimalID { get; set; }
        public string AnimalName { get; set; }
        public string Description { get; set; }

        public static List<List<string>> ConvertToList(BindableCollection<CostInfo> costs)
        {
            List<List<string>> result = new List<List<string>>();
            List<string> headers = new List<string> { "ID", "Datum", "Částka", "Název", "ID zvířete", "Jméno zvířete", "Popis" };
            result.Add(headers);

            foreach (CostInfo cost in costs)
            {
                List<string> ls = new List<string>
                {
                    cost.ID.ToString(),
                    cost.Date.ToString(),
                    cost.Price.ToString(),
                    cost.CostName,
                    cost.AnimalID.ToString(),
                    cost.AnimalName.ToString(),
                    cost.Description
                };

                result.Add(ls);
            }
            return result;
        }

    }
}
