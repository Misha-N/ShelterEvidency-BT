using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.WrappingClasses;
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
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
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
        }

        public static BindableCollection<CostInfo> GetAnimalCosts(int? animalID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from cost in db.Costs
                               where (cost.AnimalID.Equals(animalID))
                               select new CostInfo
                               {
                                   ID = cost.Id,
                                   CostName = cost.CostName,
                                   Date = cost.Date,
                                   AnimalName = cost.Animals.Name,
                                   Price = cost.Price,
                                   AnimalID = cost.AnimalID,
                                   Description = cost.Description
                               });
                return new BindableCollection<CostInfo>(results);

            }
        }

        public static BindableCollection<CostInfo> GetDatedCosts(DateTime? since, DateTime? to)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {

                var results = (from cost in db.Costs
                               where (cost.Date >= since && cost.Date <= to)
                               select new CostInfo
                               {
                                   ID = cost.Id,
                                   CostName = cost.CostName,
                                   Date = cost.Date,
                                   AnimalName = cost.Animals.Name,
                                   Price = cost.Price,
                                   AnimalID = cost.AnimalID,
                                   Description = cost.Description
                               });
                return new BindableCollection<CostInfo>(results);
            }
        }

        public static BindableCollection<CostInfo> GetDatedAnimalCosts(int? animalID, DateTime? since, DateTime? to)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {

                var results = (from cost in db.Costs
                               where (cost.Date >= since && cost.Date <= to) && (cost.AnimalID.Equals(animalID))
                               select new CostInfo
                               {
                                   ID = cost.Id,
                                   CostName = cost.CostName,
                                   Date = cost.Date,
                                   AnimalName = cost.Animals.Name,
                                   Price = cost.Price,
                                   AnimalID = cost.AnimalID,
                                   Description = cost.Description
                               });
                return new BindableCollection<CostInfo>(results);
            }
        }


        public static BindableCollection<CostInfo> GetAllCosts()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from cost in db.Costs
                               select new CostInfo
                               {
                                   ID = cost.Id,
                                   CostName = cost.CostName,
                                   Date = cost.Date,
                                   AnimalName = cost.Animals.Name,
                                   Price = cost.Price,
                                   AnimalID = cost.AnimalID,
                                   Description = cost.Description
                               });
                return new BindableCollection<CostInfo>(results);

            }
        }


        public void GetCost(int? costID)
        {
            ID = costID;
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var cost = db.Costs.FirstOrDefault(i => i.Id == costID);
                if (cost != null)
                    SetInformations(cost);
            }
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
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
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
}
