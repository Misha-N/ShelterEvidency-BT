using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class ShelterModel
    {

        #region Properties/Atributes
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public string Phone2 { get; set; }

        public string Mail { get; set; }

        public string Adress { get; set; }

        public string Account { get; set; }

        #endregion

        public ShelterModel()
        {
            GetInfo();
        }

        public void GetInfo()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                Shelter shelter = db.Shelter.FirstOrDefault();

                ID = shelter.Id;
                Name = shelter.Name;
                Phone = shelter.Phone;
                Phone2 = shelter.Phone2;
                Mail = shelter.Mail;
                Account = shelter.Account;
                Adress = shelter.Adress;
            }

        }
   

        public void UpdatePerson()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                Shelter shelter = db.Shelter.FirstOrDefault();

                shelter.Name = Name;
                shelter.Phone = Phone;
                shelter.Phone2 = Phone2;
                shelter.Mail = Mail;
                shelter.Adress = Adress;
                shelter.Account = Account;

                db.SubmitChanges();
            }
        }




    }
}
