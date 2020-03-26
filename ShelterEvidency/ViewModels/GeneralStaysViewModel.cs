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
                Escapes = EscapeModel.GetDatedEscapes(DateTime.Now.AddYears(-100), DateTime.Now.AddYears(100));

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

        #endregion

        #region Escapes

        private BindableCollection<EscapeInfo> _escapes;
        public BindableCollection<EscapeInfo> Escapes
        {
            get
            {
                return _escapes;
            }
            set
            {
                _escapes = value;
                NotifyOfPropertyChange(() => Escapes);
            }
        }

        private DateTime? _escapesince;
        public DateTime? EscapeSince
        {
            get
            {
                return _escapesince;
            }
            set
            {
                _escapesince = value;
                NotifyOfPropertyChange(() => EscapeSince);
            }

        }

        private DateTime? _escapeto;
        public DateTime? EscapeTo
        {
            get
            {
                return _escapeto;
            }
            set
            {
                _escapeto = value;
                NotifyOfPropertyChange(() => EscapeTo);
            }

        }

        public void FilterEscapes()
        {
            if (EscapeSince == null || EscapeTo == null)
            {
                IsWorking = true;
                Escapes = EscapeModel.GetDatedEscapes(DateTime.Now.AddYears(-100), DateTime.Now.AddYears(100));
                IsWorking = false;
            }
            else
            {
                IsWorking = true;
                Escapes = EscapeModel.GetDatedEscapes(EscapeSince, EscapeTo);
                IsWorking = false;
            }

        }

        private EscapeInfo _selectedescape;

        public EscapeInfo SelectedEscape
        {
            get
            {
                return _selectedescape;
            }
            set
            {
                _selectedescape = value;
                NotifyOfPropertyChange(() => SelectedEscape);
                NotifyOfPropertyChange(() => EscapeIsSelected);
            }
        }


        public bool EscapeIsSelected
        {
            get
            {
                if (SelectedEscape != null)
                    return true;
                else
                    return false;
            }

        }

        public void DeleteEscape()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete vymazat zvolený útěk?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                EscapeModel.MarkAsDeleted((int)SelectedEscape.ID);

                SelectedEscape = null;

                FilterEscapes();
            }
        }

        #endregion


    }
}
