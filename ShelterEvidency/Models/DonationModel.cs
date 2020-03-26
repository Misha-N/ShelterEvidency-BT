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
    class DonationModel
    {

        #region Properties/Atributes
        public int? ID { get; set; }
        public string DonationName { get; set; }
        public string Description { get; set; }
        public int? Amount { get; set; }
        public int? DonatorID { get; set; }
        public DateTime? Date { get; set; }

        #endregion

        public void SaveDonation()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                Donations donation = new Donations
                {
                    DonatorID = DonatorID,
                    DonationName = DonationName,
                    Description = Description,
                    Amount = Amount,
                    Date = Date
                };
                db.Donations.InsertOnSubmit(donation);
                db.SubmitChanges();

                ID = donation.ID;
            }
        }

        public static BindableCollection<DonationInfo> GetDonations()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from donation in db.Donations
                               where ((donation.IsDeleted.Equals(false)))
                               select new DonationInfo
                               {
                                   ID = donation.ID,
                                   Date = donation.Date,
                                   DonatorID = donation.DonatorID,
                                   DonatorName = donation.People.FirstName + " " + donation.People.LastName,
                                   Amount = donation.Amount,
                                   DonationName = donation.DonationName,
                                   Description = donation.Description
                               });
                return new BindableCollection<DonationInfo>(results);
            }
        }

        public static BindableCollection<DonationInfo> GetDatedDonations(DateTime? since, DateTime? to)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                //return db.Donations.Where(x => x.Date >= since && x.Date <= to).ToList();

                var results = (from donation in db.Donations
                               where (donation.Date >= since && donation.Date <= to) && (donation.IsDeleted.Equals(false))
                               select new DonationInfo
                               {
                                   ID = donation.ID,
                                   Date = donation.Date,
                                   DonatorName = donation.People.FirstName + " " + donation.People.LastName,
                                   Amount = donation.Amount,
                                   DonationName = donation.DonationName,
                                   Description = donation.Description
                               });
                return new BindableCollection<DonationInfo>(results);
            }
        }

        public void GetDonation(int? donationID)
        {
            ID = donationID;
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var donation = db.Donations.FirstOrDefault(i => i.ID == donationID);
                if (donation != null)
                    SetInformations(donation);
            }
        }

        public void SetInformations(Donations donation)
        {
            DonationName = donation.DonationName;
            Description = donation.Description;
            Amount = donation.Amount;
            DonatorID = donation.DonatorID;
            Date = donation.Date;
        }

        public void UpdateDonation()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                Donations donation = db.Donations.FirstOrDefault(i => i.ID == ID);

                donation.Amount = Amount;
                donation.Date = Date;
                donation.DonationName = DonationName;
                donation.Description = Description;
                donation.DonatorID = DonatorID;

                db.SubmitChanges();
            }
        }

        public static BindableCollection<DonationInfo> ReturnPersonDonations(int personID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from donation in db.Donations
                               where (donation.DonatorID.Equals(personID)) && (donation.IsDeleted.Equals(false))
                               select new DonationInfo
                               {
                                   ID = donation.ID,
                                   Date = donation.Date,
                                   DonatorName = donation.People.FirstName + " " + donation.People.LastName,
                                   Amount = donation.Amount,
                                   DonationName = donation.DonationName,
                                   Description = donation.Description
                               });
                return new BindableCollection<DonationInfo>(results);
            }
        }

        public static void MarkAsDeleted(int id)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var incident = db.Incidents.Single(x => x.ID == id);
                incident.IsDeleted = true;
                db.SubmitChanges();
            }
        }

        public bool ValidValues()
        {
            if (Date != null && Date != DateTime.MinValue && Date != DateTime.MaxValue &&
                !String.IsNullOrEmpty(DonationName) && Amount > 0 && Amount != null)
                return true;
            else
                return false;
        }
    }
}
