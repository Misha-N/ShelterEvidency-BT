using Caliburn.Micro;
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


        public static List<List<string>> ConvertToList(BindableCollection<DonationInfo> donations)
        {
            List<List<string>> result = new List<List<string>>();
            List<string> headers = new List<string> { "ID", "Datum", "Název", "Částka", "ID Sponzora", "Jméno sponzora", "Popis" };
            result.Add(headers);

            foreach (DonationInfo donation in donations)
            {
                List<string> ls = new List<string>
                {
                    donation.ID.ToString(),
                    donation.Date.ToString(),
                    donation.DonationName.ToString(),
                    donation.Amount.ToString(),
                    donation.DonatorID.ToString(),
                    donation.DonationName,
                    donation.Description.ToString()
                };

                result.Add(ls);
            }
            return result;
        }

    }
}

