using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class AdoptionModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public int PersonID { get; set; }
        public int AnimalID { get; set; }
        public bool? Returned { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string ReturnReason { get; set; }

        #endregion

        public static List<AdoptionInfo> ReturnAdoptions()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from adoption in db.Adoptions
                           select new AdoptionInfo
                           {
                               ID = adoption.ID,
                               Date = adoption.Date,
                               OwnerName = adoption.People.FirstName + " " + adoption.People.LastName,
                               AnimalName = adoption.Animals.Name,
                               Returned = adoption.Returned,
                               ReturnDate = adoption.ReturnDate,
                               ReturnReason = adoption.ReturnReason
                           }).ToList();
                return results;
            }
        }

        public static List<AdoptionInfo> ReturnSpecificAdoptions(string searchValue)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from adoption in db.Adoptions
                           where ((adoption.Date.Equals(searchValue)) ||
                                  (adoption.ID.ToString().Equals(searchValue)) ||
                                  (adoption.Animals.Name.Contains(searchValue)) ||
                                  (adoption.People.LastName.Contains(searchValue)))
                           select new AdoptionInfo
                           {
                               ID = adoption.ID,
                               Date = adoption.Date,
                               OwnerName = adoption.People.FirstName + " " + adoption.People.LastName,
                               AnimalName = adoption.Animals.Name,
                               Returned = adoption.Returned,
                               ReturnDate = adoption.ReturnDate,
                               ReturnReason = adoption.ReturnReason
                           }).ToList();
                return results;
            }
        }
    }
}
