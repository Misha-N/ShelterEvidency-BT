using Caliburn.Micro;
using ShelterEvidency.Models;
using ShelterEvidency.WrappingClasses;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    class GeneralStaysViewModel: Screen
    {
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
                Stays = StayModel.GetDatedStays(DateTime.Now.AddYears(-100), DateTime.Now.AddYears(100));
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

        #region Stays

        private BindableCollection<StayInfo> _stays;
        public BindableCollection<StayInfo> Stays
        {
            get
            {
                return _stays;
            }
            set
            {
                _stays = value;
                NotifyOfPropertyChange(() => Stays);
            }
        }

        private DateTime? _staysince;
        public DateTime? StaySince
        {
            get
            {
                return _staysince;
            }
            set
            {
                _staysince = value;
                NotifyOfPropertyChange(() => StaySince);
            }

        }

        private DateTime? _stayto;
        public DateTime? StayTo
        {
            get
            {
                return _stayto;
            }
            set
            {
                _stayto = value;
                NotifyOfPropertyChange(() => StayTo);
            }

        }

        public void FilterStays()
        {
            if (StaySince == null || StayTo == null)
            { 
                IsWorking = true;
                Stays = StayModel.GetDatedStays(DateTime.Now.AddYears(-100), DateTime.Now.AddYears(100));
                IsWorking = false;
            }
            else
            {
                IsWorking = true;
                Stays = StayModel.GetDatedStays(StaySince, StayTo);
                IsWorking = false;
            }

        }

        private StayInfo _selectedstay;

        public StayInfo SelectedStay
        {
            get
            {
                return _selectedstay;
            }
            set
            {
                _selectedstay = value;
                NotifyOfPropertyChange(() => SelectedStay);
                NotifyOfPropertyChange(() => StayIsSelected);
            }
        }


        public bool StayIsSelected
        {
            get
            {
                if (SelectedStay != null)
                    return true;
                else
                    return false;
            }

        }

        public void DeleteStay()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete vymazat zvolený pobyt?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                StayModel.MarkAsDeleted((int)SelectedStay.ID);

                SelectedStay = null;

                FilterStays();
            }
        }


        public void ExportExcell()
        {
            if (Stays != null && Stays.Count() != 0)
                DocumentManager.ExportDataExcell(StayInfo.ConvertToList(Stays), "Export zvířata");
            else
                MessageBox.Show("Žádná data pro export.");
        }

        public void ExportPDF()
        {
            if (Stays != null && Stays.Count() != 0)
                DocumentManager.ExportDataPDF(StayInfo.ConvertToList(Stays), "Export zvířata");
            else
                MessageBox.Show("Žádná data pro export.");
        }

        #endregion



    }
}
