using Caliburn.Micro;
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
        public int? ID { get; set; }
        public DateTime? Date { get; set; }
        public int? PersonID { get; set; }
        public int? AnimalID { get; set; }
        public bool? Returned { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string ReturnReason { get; set; }

        #endregion

        public void SaveAdoption()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                Adoptions adoption = new Adoptions
                {
                    AnimalID = AnimalID,
                    PersonID = PersonID,
                    Returned = false,
                    ReturnDate = ReturnDate,
                    ReturnReason = ReturnReason,
                    Date = Date
                };
                db.Adoptions.InsertOnSubmit(adoption);
                db.SubmitChanges();

                ID = adoption.ID;
            }
        }

        public static BindableCollection<AdoptionInfo> ReturnAdoptions()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from adoption in db.Adoptions
                               where (adoption.IsDeleted.Equals(false))
                               select new AdoptionInfo
                               {
                                   ID = adoption.ID,
                                   Date = adoption.Date,
                                   OwnerName = adoption.People.FirstName + " " + adoption.People.LastName,
                                   AnimalName = adoption.Animals.Name,
                                   Returned = adoption.Returned,
                                   ReturnDate = adoption.ReturnDate,
                                   ReturnReason = adoption.ReturnReason
                               });
                return new BindableCollection<AdoptionInfo>(results);
            }
        }

        public static List<AdoptionInfo> ReturnSpecificAdoptions(string searchValue)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from adoption in db.Adoptions
                           where ((adoption.IsDeleted.Equals(false)) &&
                           ((adoption.Date.ToString().Contains(searchValue)) ||
                                  (adoption.ID.ToString().Equals(searchValue)) ||
                                  (adoption.Animals.Name.Contains(searchValue)) ||
                                  (adoption.People.LastName.Contains(searchValue))))
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

        public void GetAdoption(int? adoptionID)
        {
            ID = adoptionID;
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var adoption = db.Adoptions.FirstOrDefault(i => i.ID == adoptionID);
                if (adoption != null)
                    SetInformations(adoption);
            }
        }

        public void SetInformations(Adoptions adoption)
        {
            Date = adoption.Date;
            PersonID = adoption.PersonID;
            AnimalID = adoption.AnimalID;
            Returned = adoption.Returned;
            ReturnDate = adoption.ReturnDate;
            ReturnReason = adoption.ReturnReason;
        }

        public void UpdateAdoption()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                Adoptions adoption = db.Adoptions.FirstOrDefault(i => i.ID == ID);

                adoption.Returned = Returned;
                adoption.ReturnDate = ReturnDate;
                adoption.ReturnReason = ReturnReason;

                db.SubmitChanges();
            }
        }

        public static BindableCollection<AdoptionInfo> ReturnPersonAdoptions(int personID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from adoption in db.Adoptions
                               where (adoption.PersonID.Equals(personID))
                               select new AdoptionInfo
                               {
                                   ID = adoption.ID,
                                   Date = adoption.Date,
                                   OwnerName = adoption.People.FirstName + " " + adoption.People.LastName,
                                   AnimalName = adoption.Animals.Name,
                                   Returned = adoption.Returned,
                                   ReturnDate = adoption.ReturnDate,
                                   ReturnReason = adoption.ReturnReason
                               });
                return new BindableCollection<AdoptionInfo>(results);
            }
        }

        public static void MarkAsDeleted(int id)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var adoption = db.Adoptions.Single(x => x.ID == id);
                adoption.IsDeleted = true;
                db.SubmitChanges();
            }
        }

        public bool ValidValues()
        {
            if (Date != null && Date != DateTime.MinValue && Date != DateTime.MaxValue)
                return true;
            else
                return false;
        }
    }
}
