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
    class WalksViewModel: Screen
    {
        #region Initialize

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

        public WalkModel Walk { get; set; }
        public WalkModel NewWalk { get; set; }

        public WalksViewModel(int animalID)
        {
            AnimalID = animalID;
            Walk = new WalkModel();
            NewWalk = new WalkModel();
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
                AnimalWalks = WalkModel.GetAnimalWalks(AnimalID);
                WalkerList = PersonModel.ReturnWalkers();
                NewWalkerList = PersonModel.ReturnWalkers();
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

        private BindableCollection<WalkInfo> _animalWalks;
        public BindableCollection<WalkInfo> AnimalWalks
        {
            get
            {
                return _animalWalks;
            }
            set
            {
                _animalWalks = value;
                NotifyOfPropertyChange(() => AnimalWalks);
            }
        }

        private BindableCollection<PersonInfo> _walkerList;
        public BindableCollection<PersonInfo> WalkerList
        {
            get
            {
                return _walkerList;
            }
            set
            {
                _walkerList = value;
                NotifyOfPropertyChange(() => WalkerList);
            }
        }

        private BindableCollection<PersonInfo> _newwalkerList;
        public BindableCollection<PersonInfo> NewWalkerList
        {
            get
            {
                return _newwalkerList;
            }
            set
            {
                _newwalkerList = value;
                NotifyOfPropertyChange(() => NewWalkerList);
            }
        }

        #region Selected medical record bindings

        public DateTime? Date
        {
            get
            {
                return Walk.Date;
            }
            set
            {
                Walk.Date = value;
                NotifyOfPropertyChange(() => Date);
            }
        }
        public int? Walker
        {
            get
            {
                return Walk.PersonID;
            }
            set
            {
                Walk.PersonID = value;
                NotifyOfPropertyChange(() => Walker);
            }
        }
        public string Note
        {
            get
            {
                return Walk.Note;
            }
            set
            {
                Walk.Note = value;
                NotifyOfPropertyChange(() => Note);
            }
        }

        #endregion

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
                AnimalWalks = WalkModel.GetAnimalDatedWalks(AnimalID, Since, To);
            });
            IsWorking = false;
        }

        private async Task GetData()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                AnimalWalks = WalkModel.GetAnimalWalks(AnimalID);
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

        private WalkInfo _selectedWalk;

        public WalkInfo SelectedWalk
        {
            get
            {
                return _selectedWalk;
            }
            set
            {
                _selectedWalk = value;
                NotifyOfPropertyChange(() => SelectedWalk);
                Task.Run(() => Selection());
            }
        }

        private async Task Selection()
        {
            if (SelectedWalk != null)
            {
                IsWorking = true;
                await Task.Delay(150);
                await Task.Run(() =>
                {
                    Walk.GetWalk(SelectedWalk.ID);
                });
                IsWorking = false;
            }
            NotifyOfPropertyChange(() => Note);
            NotifyOfPropertyChange(() => Date);
            NotifyOfPropertyChange(() => Walker);
            NotifyOfPropertyChange(() => IsSelected);
        }

        public void UpdateWalk()
        {
            if (Walk != null && Walk.ValidValues())
            {
                Walk.UpdateWalk();
                MessageBox.Show("Upraveno.");
                Filter();
            }
            else
                MessageBox.Show("Vyplňte prosím datum.");
        }


        #region New walk bindings

        public DateTime? NewDate
        {
            get
            {
                return NewWalk.Date;
            }
            set
            {
                NewWalk.Date = value;
                NotifyOfPropertyChange(() => NewDate);
            }
        }
        public int? NewWalker
        {
            get
            {
                return NewWalk.PersonID;
            }
            set
            {
                NewWalk.PersonID = value;
                NotifyOfPropertyChange(() => NewWalker);
            }
        }
        public string NewNote
        {
            get
            {
                return NewWalk.Note;
            }
            set
            {
                NewWalk.Note = value;
                NotifyOfPropertyChange(() => NewNote);
            }
        }

        #endregion

        public void CreateNewWalk()
        {
            if (NewWalk.ValidValues())
            {
                IsWorking = true;
                NewWalk.AnimalID = AnimalID;
                NewWalk.SaveWalk();
                Task.Run(() => GetData());
                ClearNewWalk();
                IsWorking = false;
                MessageBox.Show("Záznam vytvořen.");
            }
            else
                MessageBox.Show("Vyplňte prosím datum.");

        }

        public void ClearNewWalk()
        {
            NewWalk = new WalkModel();
            NotifyOfPropertyChange(() => NewWalk);
            NotifyOfPropertyChange(() => NewDate);
            NotifyOfPropertyChange(() => NewWalker);
            NotifyOfPropertyChange(() => NewNote);
        }


        public bool IsSelected
        {
            get
            {
                if (SelectedWalk != null)
                    return true;
                else
                    return false;
            }

        }

        public void DeleteWalk()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete vymazat zvolenou procházku?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                WalkModel.MarkAsDeleted((int)SelectedWalk.ID);

                Walk = new WalkModel();

                SelectedWalk = null;

                Filter();
            }
        }

        public void ExportExcell()
        {
            if (AnimalWalks != null && AnimalWalks.Count() != 0)
                DocumentManager.ExportDataExcell(WalkInfo.ConvertToList(AnimalWalks), "Export zvířata");
            else
                MessageBox.Show("Žádná data pro export.");
        }

        public void ExportPDF()
        {
            if (AnimalWalks != null && AnimalWalks.Count() != 0)
                DocumentManager.ExportDataPDF(WalkInfo.ConvertToList(AnimalWalks), "Export zvířata");
            else
                MessageBox.Show("Žádná data pro export.");
        }


    }

}

