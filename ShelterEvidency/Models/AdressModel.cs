using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class AdressModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string City { get; set; }

        public string Street { get; set; }

        public int? Zip { get; set; }

        public int? PersonID { get; set; }

        #endregion

        public void SaveAdress()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();

            Adresses adress = new Adresses
            {
                City = City,
                Street = Street,
                Zip = Zip,
                PersonID = PersonID,
            };
            db.Adresses.InsertOnSubmit(adress);
            db.SubmitChanges();

            ID = adress.ID;

        }

        public void GetAdress(int personID)
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            var adress = db.Adresses.FirstOrDefault(i => i.PersonID == personID);
            if (adress != null)
            {
                ID = adress.ID;
                City = adress.City;
                Street = adress.Street;
                Zip = adress.Zip;
                PersonID = adress.PersonID;
            }
        }

        public void UpdateAdress()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            Adresses adress = db.Adresses.FirstOrDefault(i => i.ID == ID);

            adress.City = City;
            adress.Street = Street;
            adress.Zip = Zip;
            adress.PersonID = PersonID;

            db.SubmitChanges();
        }
    }
}
