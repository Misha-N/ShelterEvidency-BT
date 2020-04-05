using Caliburn.Micro;
using ShelterEvidency.Models;
using ShelterEvidency.WrappingClasses;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    class StayEndViewModel: Conductor<object>
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
                Escapes = EscapeModel.GetDatedEscapes(DateTime.Now.AddYears(-100), DateTime.Now.AddYears(100));
                Deaths = DeathModel.GetDatedDeaths(DateTime.Now.AddYears(-100), DateTime.Now.AddYears(100));

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


        #region Deaths

        private BindableCollection<DeathInfo> _deaths;
        public BindableCollection<DeathInfo> Deaths
        {
            get
            {
                return _deaths;
            }
            set
            {
                _deaths = value;
                NotifyOfPropertyChange(() => Deaths);
            }
        }

        private DateTime? _deathsince;
        public DateTime? DeathSince
        {
            get
            {
                return _deathsince;
            }
            set
            {
                _deathsince = value;
                NotifyOfPropertyChange(() => DeathSince);
            }

        }

        private DateTime? _deathto;
        public DateTime? DeathTo
        {
            get
            {
                return _deathto;
            }
            set
            {
                _deathto = value;
                NotifyOfPropertyChange(() => DeathTo);
            }

        }

        public void FilterDeaths()
        {
            if (Deaths == null || DeathTo == null)
            {
                IsWorking = true;
                Deaths = DeathModel.GetDatedDeaths(DateTime.Now.AddYears(-100), DateTime.Now.AddYears(100));
                IsWorking = false;
            }
            else
            {
                IsWorking = true;
                Deaths = DeathModel.GetDatedDeaths(DeathSince, DeathTo);
                IsWorking = false;
            }

        }

        private DeathInfo _selecteddeath;

        public DeathInfo SelectedDeath
        {
            get
            {
                return _selecteddeath;
            }
            set
            {
                _selecteddeath = value;
                NotifyOfPropertyChange(() => SelectedDeath);
                NotifyOfPropertyChange(() => DeathIsSelected);
            }
        }


        public bool DeathIsSelected
        {
            get
            {
                if (SelectedDeath != null)
                    return true;
                else
                    return false;
            }

        }

        public void DeleteDeath()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete vymazat zvolený úhyn?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DeathModel.MarkAsDeleted((int)SelectedDeath.ID);

                SelectedDeath = null;

                FilterDeaths();
            }
        }

        public void Export()
        {
            if (Escapes != null && Escapes.Count() != 0)
                DocumentManager.ExportDataPDF(EscapeInfo.ConvertToList(Escapes), "Export útěky: " + EscapeSince + " až " + EscapeTo);
            else
                MessageBox.Show("Žádná data pro export.");
        }

        public void CreateDeath()
        {
            ActivateItem(new CreateDeathViewModel(0, this));
        }

        public void CreateEscape()
        {
            ActivateItem(new CreateEscapeViewModel(0, this));
        }

        public void ExportEscapesExcell()
        {
            if (Escapes != null && Escapes.Count() != 0)
                DocumentManager.ExportDataExcell(EscapeInfo.ConvertToList(Escapes), "Export zvířata");
            else
                MessageBox.Show("Žádná data pro export.");
        }

        public void ExportEscapesPDF()
        {
            if (Escapes != null && Escapes.Count() != 0)
                DocumentManager.ExportDataPDF(EscapeInfo.ConvertToList(Escapes), "Export zvířata");
            else
                MessageBox.Show("Žádná data pro export.");
        }

        public void ExportDeathsExcell()
        {
            if (Deaths != null && Deaths.Count() != 0)
                DocumentManager.ExportDataExcell(DeathInfo.ConvertToList(Deaths), "Export zvířata");
            else
                MessageBox.Show("Žádná data pro export.");
        }

        public void ExportDeathsPDF()
        {
            if (Deaths != null && Deaths.Count() != 0)
                DocumentManager.ExportDataPDF(DeathInfo.ConvertToList(Deaths), "Export zvířata");
            else
                MessageBox.Show("Žádná data pro export.");
        }



        #endregion

    }
}
