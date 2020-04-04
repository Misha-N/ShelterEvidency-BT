using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.WrappingClasses
{
    class DeathInfo : WrappingClassBase
    {
        public int ID { get; set; }
        public DateTime? Date { get; set; }

        public int? AnimalID { get; set; }
        public string AnimalName { get; set; }
        public string Description { get; set; }

        public bool? Euthanasia { get; set; }
        public bool? Natural { get; set; }
        public bool? Other { get; set; }

        public static List<List<string>> ConvertToList(BindableCollection<DeathInfo> deaths)
        {
            List<List<string>> result = new List<List<string>>();
            List<string> headers = new List<string> { "ID", "Datum", "ID zvířete", "Jméno zvířete", "Popis", "Eutanázie", "Přirozený", "Ostatní", };
            result.Add(headers);

            foreach (DeathInfo death in deaths)
            {
                List<string> ls = new List<string>
                {
                    death.ID.ToString(),
                    death.Date.ToString(),
                    death.AnimalID.ToString(),
                    death.AnimalName.ToString(),
                    death.Description,
                    death.Euthanasia.ToString(),
                    death.Natural.ToString(),
                    death.Other.ToString()
                };

                result.Add(ls);
            }
            return result;
        }

    }
}
