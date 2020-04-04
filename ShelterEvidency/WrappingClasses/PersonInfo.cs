using Caliburn.Micro;
using ShelterEvidency.WrappingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency
{
    public class PersonInfo : WrappingClassBase
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Note { get; set; }
        public string AdressCity { get; set; }
        public string AdressStreet { get; set; }
        public string AdressZip { get; set; }
        public bool? IsOwner { get; set; }
        public bool? IsVet { get; set; }
        public bool? IsWalker { get; set; }
        public bool? IsSponsor { get; set; }
        public bool? IsVolunteer { get; set; }
        public string TitledFullName
        {
            get
            {
                string titledFullName = Title + " " + FirstName + " " + LastName;
                return titledFullName;
            }

        }

        public static List<List<string>> ConvertToList(BindableCollection<PersonInfo> people)
        {
            List<List<string>> result = new List<List<string>>();
            List<string> headers = new List<string> { "ID", "Titul", "Jméno", "Příjmení", "Telefon", "E-mail", "Město", "Ulice a číslo domu", "PSČ",
                "Poznámka", "Majitel", "Veterinář", "Venčitel", "Sponzor", "Dobrovolník" };
            result.Add(headers);

            foreach (PersonInfo person in people)
            {
                List<string> ls = new List<string>
                {
                    person.ID.ToString(),
                    person.Title.ToString(),
                    person.FirstName.ToString(),
                    person.LastName.ToString(),
                    person.Phone.ToString(),
                    person.Mail.ToString(),
                    person.AdressCity,
                    person.AdressStreet.ToString(),
                    person.AdressZip.ToString(),
                    person.Note.ToString(),
                    person.IsOwner.ToString(),
                    person.IsVet.ToString(),
                    person.IsWalker.ToString(),
                    person.IsVolunteer.ToString()
                };

                result.Add(ls);
            }
            return result;
        }
    }
}
