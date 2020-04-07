using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.IO;
using System.Threading.Tasks;
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

        public void ChangeLogo()
        {
            try
            {
                Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog
                {
                    Title = "Vyberte obrázek",
                    Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                  "Portable Network Graphic (*.png)|*.png"
                };
                if (op.ShowDialog() == true)
                {
                    string path;
                    var fileName = Helpers.RandomStringGenerator.RandomString(10);
                    System.IO.Directory.CreateDirectory(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Graphics"));
                    path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Graphics", fileName);
                    System.IO.File.Copy(op.FileName, path, true);
                    ShelterModel.SetLogo(path);
                    MessageBox.Show("Logo bylo změněno úspěšně.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async void Restore()
        {
             if (Since == null || To == null || (Since > To))
             {
                MessageBox.Show("Zvolte prosím platné datum.");
             }
             else
             {
                IsWorking = true;
                await Task.Delay(150);
                await Task.Run(() =>
                {
                    AdoptionModel.RestoreDeleted((DateTime)Since, (DateTime)To);
                    AnimalModel.RestoreDeleted((DateTime)Since, (DateTime)To);
                    BreedModel.RestoreDeleted((DateTime)Since, (DateTime)To);
                    CoatTypeModel.RestoreDeleted((DateTime)Since, (DateTime)To);
                    CostModel.RestoreDeleted((DateTime)Since, (DateTime)To);
                    DeathModel.RestoreDeleted((DateTime)Since, (DateTime)To);
                    DiaryModel.RestoreDeleted((DateTime)Since, (DateTime)To);
                    DonationModel.RestoreDeleted((DateTime)Since, (DateTime)To);
                    EscapeModel.RestoreDeleted((DateTime)Since, (DateTime)To);
                    FurColorModel.RestoreDeleted((DateTime)Since, (DateTime)To);
                    IncidentModel.RestoreDeleted((DateTime)Since, (DateTime)To);
                    PersonModel.RestoreDeleted((DateTime)Since, (DateTime)To);
                    MedicalRecordModel.RestoreDeleted((DateTime)Since, (DateTime)To);
                    SpeciesModel.RestoreDeleted((DateTime)Since, (DateTime)To);
                    StayModel.RestoreDeleted((DateTime)Since, (DateTime)To);
                    WalkModel.RestoreDeleted((DateTime)Since, (DateTime)To);
                });
                ComboBoxSettings();
                IsWorking = false;
                MessageBox.Show("Záznamy od " + Since + " do " + To + " obnoveny.");
            }
        }

        #endregion


        public void ComboBoxSettings()
        {
            ActivateItem(new ComboBoxSettingsViewModel());
        }
    }
}
