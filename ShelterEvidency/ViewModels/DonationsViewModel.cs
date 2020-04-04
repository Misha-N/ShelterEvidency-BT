using Caliburn.Micro;
using ShelterEvidency.Models;
using ShelterEvidency.WrappingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    class DonationsViewModel: Screen
    {
        #region Initialize
        public DonationModel Donation { get; set; }
        public DonationModel NewDonation { get; set; }
        public DonationsViewModel()
        {
            Donation = new DonationModel();
            NewDonation = new DonationModel();
        }

        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            Task.Run(() => LoadData());
        }


        private async Task LoadData()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                Donations = DonationModel.GetDonations();
                DonatorList = PersonModel.ReturnDonators();
                NewDonatorList = PersonModel.ReturnDonators();
            });
            IsWorking = false;
        }

        private volatile bool _isWorking;
        public bool IsWorking
        {
            get
            {
                return _isWorking;
            }
            set
            {
                _isWorking = value;
                NotifyOfPropertyChange(() => IsWorking);
            }
        }

        #endregion

        private BindableCollection<DonationInfo> _donations;
        public BindableCollection<DonationInfo> Donations
        {
            get
            {
                return _donations;
            }
            set
            {
                _donations = value;
                NotifyOfPropertyChange(() => Donations);
            }
        }


        private BindableCollection<PersonInfo> _donatorList;
        public BindableCollection<PersonInfo> DonatorList
        {
            get
            {
                return _donatorList;
            }
            set
            {
                _donatorList = value;
                NotifyOfPropertyChange(() => DonatorList);
            }
        }

        private BindableCollection<PersonInfo> _newdonatorList;
        public BindableCollection<PersonInfo> NewDonatorList
        {
            get
            {
                return _newdonatorList;
            }
            set
            {
                _newdonatorList = value;
                NotifyOfPropertyChange(() => NewDonatorList);
            }
        }



        public void Filter()
        {
            if (Since == null || To == null)
                Task.Run(() => GetData());
            else
                Task.Run(() => FilterData());


        }

        private async Task FilterData()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                Donations = DonationModel.GetDatedDonations(Since, To);
            });
            IsWorking = false;
        }

        private async Task GetData()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                Donations = DonationModel.GetDonations();
            });
            IsWorking = false;
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

        private DonationInfo _selectedDonation;

        public DonationInfo SelectedDonation
        {
            get
            {
                return _selectedDonation;
            }
            set
            {
                _selectedDonation = value;
                NotifyOfPropertyChange(() => SelectedDonation);
                Task.Run(() => Selection());
            }
        }

        private async Task Selection()
        {
            if(SelectedDonation != null)
            {
                IsWorking = true;
                await Task.Delay(150);
                await Task.Run(() =>
                {
                    Donation.GetDonation(SelectedDonation.ID);
                });
                IsWorking = false;
            }
            NotifyOfPropertyChange(() => DonationName);
            NotifyOfPropertyChange(() => Description);
            NotifyOfPropertyChange(() => Donator);
            NotifyOfPropertyChange(() => Amount);
            NotifyOfPropertyChange(() => Date);
            NotifyOfPropertyChange(() => SelectedDonation);
            NotifyOfPropertyChange(() => IsSelected);
        }

        public void UpdateDonation()
        {
            if (Donation.ValidValues() && Donation != null)
            {
                Donation.UpdateDonation();
                MessageBox.Show("Upraveno.");
                Filter();
            }
            else
                MessageBox.Show("Vyplňte prosím název, hodnotu a datum.");
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

        #region Methods

        public void CreateNewDonation()
        {
            if (NewDonation.ValidValues())
            {
                IsWorking = true;
                NewDonation.DonatorID = NewDonator;
                NewDonation.SaveDonation();
                Task.Run(() => GetData());
                ClearNewDonation();
                IsWorking = false;
                MessageBox.Show("Záznam vytvořen.");
            }
            else
                MessageBox.Show("Vyplňte prosím název, hodnotu a datum.");

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

        public bool IsSelected
        {
            get
            {
                if (SelectedDonation != null)
                    return true;
                else
                    return false;
            }

        }

        public void DeleteDonation()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete vymazat zvolený dar?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DonationModel.MarkAsDeleted((int)SelectedDonation.ID);

                Donation = new DonationModel();
                SelectedDonation = null;
                
                Filter();
            }
        }

        public void ExportExcell()
        {
            if (Donations != null && Donations.Count() != 0)
                DocumentManager.ExportDataExcell(DonationInfo.ConvertToList(Donations), "Export zvířata");
            else
                MessageBox.Show("Žádná data pro export.");
        }

        public void ExportPDF()
        {
            if (Donations != null && Donations.Count() != 0)
                DocumentManager.ExportDataPDF(DonationInfo.ConvertToList(Donations), "Export zvířata");
            else
                MessageBox.Show("Žádná data pro export.");
        }

        #endregion
    }

}

