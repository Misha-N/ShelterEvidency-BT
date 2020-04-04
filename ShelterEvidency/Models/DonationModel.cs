using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.WrappingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static BindableCollection<DonationInfo> GetDonations()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<DonationInfo>();
            }
        }

        public static BindableCollection<DonationInfo> GetDatedDonations(DateTime? since, DateTime? to)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<DonationInfo>();
            }
        }

        public void GetDonation(int? donationID)
        {
            try
            {
                ID = donationID;
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var donation = db.Donations.FirstOrDefault(i => i.ID == donationID);
                    if (donation != null)
                        SetInformations(donation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static BindableCollection<DonationInfo> ReturnPersonDonations(int personID)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<DonationInfo>();
            }
        }

        public static void MarkAsDeleted(int id)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var incident = db.Incidents.Single(x => x.ID == id);
                    incident.IsDeleted = true;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
