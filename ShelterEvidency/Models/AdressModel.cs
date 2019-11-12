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

        public int Zip { get; set; }

        public int PersonID { get; set; }

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
    }
}
