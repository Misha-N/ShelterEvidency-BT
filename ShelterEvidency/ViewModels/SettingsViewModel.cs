using Caliburn.Micro;
using ShelterEvidency.Models;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    class SettingsViewModel: Conductor<object>
    {
        #region Initialize
        public ShelterModel ShelterInfo { get; set; }

        public SettingsViewModel()
        {
            ComboBoxSettings();
            ShelterInfo = new ShelterModel();

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

        #region Shelter Info Bindings

        public string ShelterName
        {
            get
            {
                return ShelterInfo.Name;
            }
            set
            {
                ShelterInfo.Name = value;
                NotifyOfPropertyChange(() => ShelterName);
            }
        }

        public string ShelterPhone
        {
            get
            {
                return ShelterInfo.Phone;
            }
            set
            {
                ShelterInfo.Phone = value;
                NotifyOfPropertyChange(() => ShelterPhone);
            }
        }

        public string ShelterEmergencyPhone
        {
            get
            {
                return ShelterInfo.Phone2;
            }
            set
            {
                ShelterInfo.Phone2 = value;
                NotifyOfPropertyChange(() => ShelterEmergencyPhone);
            }
        }

        public string ShelterMail
        {
            get
            {
                return ShelterInfo.Mail;
            }
            set
            {
                ShelterInfo.Mail = value;
                NotifyOfPropertyChange(() => ShelterMail);
            }
        }

        public string ShelterAdress
        {
            get
            {
                return ShelterInfo.Adress;
            }
            set
            {
                ShelterInfo.Adress = value;
                NotifyOfPropertyChange(() => ShelterAdress);
            }
        }

        public string ShelterAccount
        {
            get
            {
                return ShelterInfo.Account;
            }
            set
            {
                ShelterInfo.Account = value;
                NotifyOfPropertyChange(() => ShelterAccount);
            }
        }

        public void UpdateShelterInfo()
        {
            ShelterInfo.UpdateInfo();
            MessageBox.Show("Aktualizováno");
        }

        #endregion


        public void ComboBoxSettings()
        {
            ActivateItem(new ComboBoxSettingsViewModel());
        }
    }
}
