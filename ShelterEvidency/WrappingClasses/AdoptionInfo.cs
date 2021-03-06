﻿using Caliburn.Micro;
using ShelterEvidency.WrappingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency
{
    public class AdoptionInfo: WrappingClassBase
    {
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public string AnimalName { get; set; }
        public string OwnerName { get; set; }
        public bool? Returned { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string ReturnReason { get; set; }

        public static List<List<string>> ConvertToList(BindableCollection<AdoptionInfo> adoptions)
        {
            List<List<string>> result = new List<List<string>>();
            List<string> headers = new List<string> { "ID", "Datum adopce", "Jméno zvířete", "Jméno majitele", "Vráceno", "Datum", "Důvod" };
            result.Add(headers);

            foreach (AdoptionInfo adoption in adoptions)
            {
                List<string> ls = new List<string>
                {
                    adoption.ID.ToString(),
                    adoption.Date.ToString(),
                    adoption.AnimalName,
                    adoption.OwnerName,
                    adoption.Returned.ToString(),
                    adoption.ReturnDate.ToString(),
                    adoption.ReturnReason
                };

                result.Add(ls);
            }
            return result;
        }

    }
}

