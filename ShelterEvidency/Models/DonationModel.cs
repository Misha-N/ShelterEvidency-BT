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

        public static List<Donations> GetDonations()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                return db.Donations.ToList();
            }
        }

        public static List<Donations> GetDatedDonations(DateTime? since, DateTime? to)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                return db.Donations.Where(x => x.Date >= since && x.Date <= to).ToList();
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
                               where (donation.DonatorID.Equals(personID))
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
    }
}
