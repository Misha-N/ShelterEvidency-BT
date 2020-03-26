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
                               where (cost.AnimalID.Equals(animalID)) && (cost.IsDeleted.Equals(false))
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
                               where (cost.Date >= since && cost.Date <= to) && (cost.IsDeleted.Equals(false))
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
                               where (cost.Date >= since && cost.Date <= to) && (cost.AnimalID.Equals(animalID) && (cost.IsDeleted.Equals(false)))
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
                               where((cost.IsDeleted.Equals(false)))
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

        public static void MarkAsDeleted(int id)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var cost = db.Costs.Single(x => x.Id == id);
                cost.IsDeleted = true;
                db.SubmitChanges();
            }
        }

        public bool ValidValues()
        {
            if (Date != null && Date != DateTime.MinValue && Date != DateTime.MaxValue
                && Price != null && Price > 0 && !String.IsNullOrEmpty(CostName))
                return true;
            else
                return false;
        }

    }
}
