using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.WrappingClasses
{
    public class MedicalRecordInfo : WrappingClassBase
    {
        public int ID { get; set; }

        public string RecordName { get; set; }
        public DateTime? Date { get; set; }

        public int? AnimalID { get; set; }
        public string AnimalName { get; set; }

        public int? CostID { get; set; }

        public int? VetID { get; set; }

        public string VetName { get; set; }
        public string Description { get; set; }

        public static List<List<string>> ConvertToList(BindableCollection<MedicalRecordInfo> records)
        {
            List<List<string>> result = new List<List<string>>();
            List<string> headers = new List<string> { "ID", "Datum", "Název", "ID zvířete", "Jméno zvířete", "ID veterináře", "Jméno veterináře", "ID nákladu", "Popis" };
            result.Add(headers);

            foreach (MedicalRecordInfo record in records)
            {
                List<string> ls = new List<string>
                {
                    record.ID.ToString(),
                    record.Date.ToString(),
                    record.RecordName.ToString(),
                    record.AnimalID.ToString(),
                    record.AnimalName.ToString(),
                    record.VetID.ToString(),
                    record.VetName,
                    record.CostID.ToString(),
                    record.Description
                };

                result.Add(ls);
            }
            return result;
        }

    }
}

