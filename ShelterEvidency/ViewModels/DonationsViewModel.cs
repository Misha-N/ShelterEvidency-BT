using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    class DonationsViewModel: Screen
    {
        public DonationModel Donation { get; set; }
        public DonationModel NewDonation { get; set; }
        public DonationsViewModel()
        {
            Donation = new DonationModel();
            NewDonation = new DonationModel();
        }
        public virtual List<Database.Donations> Donations
        {
            get
            {
                if (Since != null && To != null)
                    return DonationModel.GetDatedDonations(Since, To);
                else
                    return DonationModel.GetDonations();
            }
        }

        public void Filter()
        {
            NotifyOfPropertyChange(() => Donations);
        }

        private DateTime? _since;
        public DateTime? Since
        {
            get
            {
                return _since;
            }
            set
            {
                _since = value;
                NotifyOfPropertyChange(() => Since);
            }

        }

        private DateTime? _to;
        public DateTime? To
        {
            get
            {
                return _to;
            }
            set
            {
                _to = value;
                NotifyOfPropertyChange(() => To);
            }

        }

        public List<PersonInfo> DonatorList
        {
            get
            {
                return PersonModel.ReturnDonators();
            }
        }

        #region Selected donation bindings

        public int? Donator
        {
            get
            {
                return Donation.DonatorID;
            }
            set
            {
                Donation.DonatorID = value;
                NotifyOfPropertyChange(() => Donator);
            }
        }
        public DateTime? Date
        {
            get
            {
                return Donation.Date;
            }
            set
            {
                Donation.Date = value;
                NotifyOfPropertyChange(() => Date);
            }
        }

        public int? Amount
        {
            get
            {
                return Donation.Amount;
            }
            set
            {
                Donation.Amount = value;
                NotifyOfPropertyChange(() => Amount);
            }
        }

        public string DonationName
        {
            get
            {
                return Donation.DonationName;
            }
            set
            {
                Donation.DonationName = value;
                NotifyOfPropertyChange(() => DonationName);
            }
        }

        public string Description
        {
            get
            {
                return Donation.Description;
            }
            set
            {
                Donation.Description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }
        #endregion
        public int? SelectedDonation
        {
            get
            {
                return Donation.ID;
            }
            set
            {
                Donation.GetDonation(value);
                Selection();
            }
        }

        private void Selection()
        {
            NotifyOfPropertyChange(() => DonationName);
            NotifyOfPropertyChange(() => Description);
            NotifyOfPropertyChange(() => Donator);
            NotifyOfPropertyChange(() => Amount);
            NotifyOfPropertyChange(() => Date);
            NotifyOfPropertyChange(() => SelectedDonation);
        }

        public void UpdateDonation()
        {
            if (SelectedDonation != null)
            {
                Donation.UpdateDonation();
                NotifyOfPropertyChange(() => Donations);
            }
        }

        #region NewCost binded properties

        public DateTime? NewDate
        {
            get
            {
                return NewDonation.Date;
            }
            set
            {
                NewDonation.Date = value;
                NotifyOfPropertyChange(() => NewDate);
            }
        }

        public int? NewAmount
        {
            get
            {
                return NewDonation.Amount;
            }
            set
            {
                NewDonation.Amount = value;
                NotifyOfPropertyChange(() => NewAmount);
            }
        }

        public int? NewDonator
        {
            get
            {
                return NewDonation.DonatorID;
            }
            set
            {
                NewDonation.DonatorID = value;
                NotifyOfPropertyChange(() => NewDonator);
            }
        }
        public string NewDonationName
        {
            get
            {
                return NewDonation.DonationName;
            }
            set
            {
                NewDonation.DonationName = value;
                NotifyOfPropertyChange(() => NewDonationName);
            }
        }

        public string NewDescription
        {
            get
            {
                return NewDonation.Description;
            }
            set
            {
                NewDonation.Description = value;
                NotifyOfPropertyChange(() => NewDescription);
            }
        }

        #endregion

        public void CreateNewDonation()
        {
            if (NewDonationName != null)
            {
                NewDonation.DonatorID = NewDonator;
                NewDonation.SaveDonation();
            }
            NotifyOfPropertyChange(() => Donations);
            ClearNewDonation();
        }

        public void ClearNewDonation()
        {
            NewDonation = new DonationModel();
            NotifyOfPropertyChange(() => NewDonation);
            NotifyOfPropertyChange(() => NewDonationName);
            NotifyOfPropertyChange(() => NewDonator);
            NotifyOfPropertyChange(() => NewDescription);
            NotifyOfPropertyChange(() => NewDate);
            NotifyOfPropertyChange(() => NewAmount);
        }
    }

}

