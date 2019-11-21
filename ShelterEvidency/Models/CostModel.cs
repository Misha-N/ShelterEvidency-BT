using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class CostModel
    {
        #region Properties/Atributes
        public int? ID { get; set; }
        public string CostName { get; set; }
        public string Description { get; set; }
        public int? Price { get; set; }
        public int? AnimalID { get; set; }
        public DateTime? Date { get; set; }

        #endregion

        public void SaveCost()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();

            Costs cost = new Costs
            {
                AnimalID = AnimalID,
                CostName = CostName,
                Description = Description,
                Price = Price,
                Date = Date
            };
            db.Costs.InsertOnSubmit(cost);
            db.SubmitChanges();

            ID = cost.Id;
        }

        public static List<Costs> GetAnimalCosts(int animalID)
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.Costs.Where(x => x.AnimalID.Equals(animalID)).ToList();
        }

        public void GetCost(int? costID)
        {
            ID = costID;
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            var cost = db.Costs.FirstOrDefault(i => i.Id == costID);
            if (cost != null)
                SetInformations(cost);
        }

        public void SetInformations(Costs cost)
        {
            CostName = cost.CostName;
            Description = cost.Description;
            Price = cost.Price;
            AnimalID = cost.AnimalID;
            Date = cost.Date;
        }

        public void UpdateCost()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            Costs cost = db.Costs.FirstOrDefault(i => i.Id == ID);

            cost.Price = Price;
            cost.Date = Date;
            cost.CostName = CostName;
            cost.Description = Description;
            cost.AnimalID = AnimalID;

            db.SubmitChanges();
        }

    }
}
