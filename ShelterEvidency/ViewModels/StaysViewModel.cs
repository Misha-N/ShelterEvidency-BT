using Caliburn.Micro;
using ShelterEvidency.Database;
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
    public class StaysViewModel: Conductor<object>
    {
        #region Initialization

        private int _animalID;
        public int AnimalID
        {
            get
            {
                return _animalID;
            }
            set
            {
                _animalID = value;
                NotifyOfPropertyChange(() => AnimalID);
            }
        }

        public StayModel Stay { get; set; }
        public StayModel NewStay { get; set; }
        public StaysViewModel(int animalID)
        {
            AnimalID = animalID;
            Stay = new StayModel();
            NewStay = new StayModel();
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
                AnimalStays = StayModel.GetAnimalStays(AnimalID);

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

        private BindableCollection<StayInfo> _animalStays;
        public BindableCollection<StayInfo> AnimalStays
        {
            get
            {
                return _animalStays;
            }
            set
            {
                _animalStays = value;
                NotifyOfPropertyChange(() => AnimalStays);
            }
        }

        #region Selected stay bindings
        public DateTime? Start
        {
            get
            {
                return Stay.StartDate;
            }
            set
            {
                Stay.StartDate = value;
                NotifyOfPropertyChange(() => Start);
            }
        }
        public DateTime? Finish
        {
            get
            {
                return Stay.FinishDate;
            }
            set
            {
                Stay.FinishDate = value;
                NotifyOfPropertyChange(() => Finish);
            }
        }

        public DateTime? FindDate
        {
            get
            {
                return Stay.FindDate;
            }
            set
            {
                Stay.FindDate = value;
                NotifyOfPropertyChange(() => FindDate);
            }
        }
        public string Note
        {
            get
            {
                return Stay.Note;
            }
            set
            {
                Stay.Note = value;
                NotifyOfPropertyChange(() => Note);
            }
        }

        public string FindPlace
        {
            get
            {
                return Stay.FindPlace;
            }
            set
            {
                Stay.FindPlace = value;
                NotifyOfPropertyChange(() => FindPlace);
            }
        }

        public bool? Adopted
        {
            get
            {
                return Stay.Adopted;
            }
            set
            {
                Stay.Adopted = value;
                NotifyOfPropertyChange(() => Adopted);
            }
        }

        public bool? Escaped
        {
            get
            {
                return Stay.Escaped;
            }
            set
            {
                Stay.Escaped = value;
                NotifyOfPropertyChange(() => Escaped);
            }
        }

        public bool? Died
        {
            get
            {
                return Stay.Died;
            }
            set
            {
                Stay.Died = value;
                NotifyOfPropertyChange(() => Escaped);
            }
        }
        #endregion

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
                Task.Run(() => Selection());
            }
        }

        private async Task Selection()
        {
            if (SelectedStay != null)
            {
                IsWorking = true;
                await Task.Delay(150);
                await Task.Run(() =>
                {
                    Stay.GetStay(SelectedStay.ID);
                });
                IsWorking = false;
            }
            NotifyOfPropertyChange(() => Start);
            NotifyOfPropertyChange(() => Finish);
            NotifyOfPropertyChange(() => Note);
            NotifyOfPropertyChange(() => Adopted);
            NotifyOfPropertyChange(() => Escaped);
            NotifyOfPropertyChange(() => Died);
            NotifyOfPropertyChange(() => FindDate);
            NotifyOfPropertyChange(() => FindPlace);
            NotifyOfPropertyChange(() => IsSelected);
        }

        public void UpdateStay()
        {
            if (Stay.ValidValues())
            {
                if ((Start < Finish))
                {
                    IsWorking = true;
                    Stay.UpdateStay();
                    Filter();
                    MessageBox.Show("Upraveno.");
                    CheckDeath();
                    CheckEscape();
                }
                else
                    MessageBox.Show("Pobyt nesmí končit před jeho začátkem.");
            }
            else
                MessageBox.Show("Vyplňte prosím počáteční datum.");
        }

        private void CheckEscape()
        {
            if (Stay.Escaped == true && Stay.ValidValues())
            {
                MessageBoxResult result = MessageBox.Show("Založit nový záznam o útěku?",
                              "Confirmation",
                              MessageBoxButton.YesNo,
                              MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (Stay.FinishDate != null)
                        OpenEscapeCreation();

                }
            }

        }

        public void OpenEscapeCreation()
        {
                ActivateItem(new CreateEscapeViewModel(AnimalID, this));
        }

        private void CheckDeath()
        {
            if (Stay.Died == true && Stay.ValidValues())
            {
                MessageBoxResult result = MessageBox.Show("Založit nový záznam o úhynu?",
                  "Confirmation",
                  MessageBoxButton.YesNo,
                  MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (Stay.FinishDate != null)
                        OpenDeathCreation();

                }
            }
        }

        public void OpenDeathCreation()
        {
            ActivateItem(new CreateDeathViewModel(AnimalID, this));
        }

        public void Filter()
        {
            if (Since == null || To == null)
                Task.Run(() => LoadData());
            else
                Task.Run(() => FilterData());
        }

        private async Task FilterData()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                AnimalStays = StayModel.GetDatedStays(Since, To);
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

        public void CreateNewStay()
        {
            if (NewStay.ValidValues())
            {
                NewStay.AnimalID = AnimalID;
                NewStay.SaveStay();
                ClearNewStay();
                Task.Run(() => LoadData());
                IsWorking = false;
                MessageBox.Show("Záznam vytvořen.");
            }
            else
                MessageBox.Show("Vyplňte prosím počáteční datum.");

        }

        public void ClearNewStay()
        {
            NewStay = new StayModel();
            NotifyOfPropertyChange(() => NewStayDate);
            NotifyOfPropertyChange(() => NewFindDate);
            NotifyOfPropertyChange(() => NewFindPlace);
        }

        public bool CanCreate()
        {
            if(NewStayDate != DateTime.MinValue)
                return true;
            else
                return false;
        }


        public DateTime? NewStayDate
        {
            get
            {
                return NewStay.StartDate;
            }
            set
            {
                NewStay.StartDate = value;
                NotifyOfPropertyChange(() => NewStayDate);
            }
        }

        public DateTime? NewFindDate
        {
            get
            {
                return NewStay.FindDate;
            }
            set
            {
                NewStay.FindDate = value;
                NotifyOfPropertyChange(() => NewFindDate);
            }
        }

        public string NewFindPlace
        {
            get
            {
                return NewStay.FindPlace;
            }
            set
            {
                NewStay.FindPlace = value;
                NotifyOfPropertyChange(() => NewFindPlace);
            }
        }

        public bool IsSelected
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

                Stay = new StayModel();

                SelectedStay = null;

                Filter();
            }
        }

    }
}
