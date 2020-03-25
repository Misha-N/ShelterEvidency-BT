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
    class IncidentsViewModel: Screen
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

        public IncidentModel Incident { get; set; }
        public IncidentModel NewIncident { get; set; }
        public IncidentsViewModel(int animalID)
        {
            AnimalID = animalID;
            Incident = new IncidentModel();
            NewIncident = new IncidentModel();
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
                AnimalIncidents = IncidentModel.GetAnimalIncidents(AnimalID);
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

        private BindableCollection<IncidentInfo> _animalIncidents;
        public BindableCollection<IncidentInfo> AnimalIncidents
        {
            get
            {
                return _animalIncidents;
            }
            set
            {
                _animalIncidents = value;
                NotifyOfPropertyChange(() => AnimalIncidents);
            }
        }

        #region Selected incident bindings
        public DateTime? Date
        {
            get
            {
                return Incident.Date;
            }
            set
            {
                Incident.Date = value;
                NotifyOfPropertyChange(() => Date);
            }
        }

        public int? Severity
        {
            get
            {
                return Incident.Severity;
            }
            set
            {
                Incident.Severity = value;
                NotifyOfPropertyChange(() => Severity);
            }
        }

        public string Description
        {
            get
            {
                return Incident.Description;
            }
            set
            {
                Incident.Description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        #endregion

        private IncidentInfo _selectedIncident;

        public IncidentInfo SelectedIncident
        {
            get
            {
                return _selectedIncident;
            }
            set
            {
                _selectedIncident = value;
                NotifyOfPropertyChange(() => SelectedIncident);
                Task.Run(() => Selection());
            }
        }

        private async Task Selection()
        {
            if (SelectedIncident != null)
            {
                IsWorking = true;
                await Task.Delay(150);
                await Task.Run(() =>
                {
                    Incident.GetIncident(SelectedIncident.ID);
                });
                IsWorking = false;
            }
            NotifyOfPropertyChange(() => Severity);
            NotifyOfPropertyChange(() => Description);
            NotifyOfPropertyChange(() => Date);
            NotifyOfPropertyChange(() => IsSelected);
        }

        public void UpdateIncident()
        {
            if (Incident != null)
            {
                IsWorking = true;
                Incident.UpdateIncident();
                Filter();
                MessageBox.Show("Upraveno.");
            }
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
                AnimalIncidents = IncidentModel.GetDatedAnimalIncidents(AnimalID, Since, To);
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


        #region NewIncident binded properties

        public DateTime? NewDate
        {
            get
            {
                return NewIncident.Date;
            }
            set
            {
                NewIncident.Date = value;
                NotifyOfPropertyChange(() => NewDate);
            }
        }

        public int? NewSeverity
        {
            get
            {
                return NewIncident.Severity;
            }
            set
            {
                NewIncident.Severity = value;
                NotifyOfPropertyChange(() => NewSeverity);
            }
        }

        public int? NewIncidentAnimalID
        {
            get
            {
                return NewIncident.AnimalID;
            }
            set
            {
                NewIncident.AnimalID = value;
                NotifyOfPropertyChange(() => NewIncidentAnimalID);
            }
        }

        public string NewDescription
        {
            get
            {
                return NewIncident.Description;
            }
            set
            {
                NewIncident.Description = value;
                NotifyOfPropertyChange(() => NewDescription);
            }
        }

        #endregion

        public void CreateNewIncident()
        {
            if (NewDate != null)
            {
                IsWorking = true;
                NewIncident.AnimalID = AnimalID;
                NewIncident.SaveIncident();
                Filter();
                IsWorking = false;
                ClearNewIncident();
                MessageBox.Show("Záznam vytvořen.");
            }
            else
                MessageBox.Show("Vyplňte prosím datum.");
        }

        public void ClearNewIncident()
        {
            NewIncident = new IncidentModel();
            NotifyOfPropertyChange(() => NewDescription);
            NotifyOfPropertyChange(() => NewDate);
            NotifyOfPropertyChange(() => NewSeverity);

        }

        public bool IsSelected
        {
            get
            {
                if (SelectedIncident != null)
                    return true;
                else
                    return false;
            }

        }

        public void DeleteIncident()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete vymazat zvolený incident?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DonationModel.MarkAsDeleted((int)SelectedIncident.ID);

                Incident = new IncidentModel();
                SelectedIncident = null;

                Filter();
            }
        }

    }
}
