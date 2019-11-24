using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    class IncidentsViewModel: Screen
    {
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

        public List<Database.Incidents> AnimalIncidents
        {
            get
            {
                return IncidentModel.GetAnimalIncidents(AnimalID);
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
        public int? SelectedIncident
        {
            get
            {
                return Incident.ID;
            }
            set
            {
                Incident.GetIncident(value);
                Selection();
            }
        }

        private void Selection()
        {
            NotifyOfPropertyChange(() => Severity);
            NotifyOfPropertyChange(() => Description);
            NotifyOfPropertyChange(() => Date);
        }

        public void UpdateIncident()
        {
            if (SelectedIncident != null)
            {
                Incident.UpdateIncident();
                NotifyOfPropertyChange(() => AnimalIncidents);
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
                NewIncident.AnimalID = AnimalID;
                NewIncident.SaveIncident();
            }
            NotifyOfPropertyChange(() => AnimalIncidents);
            ClearNewIncident();
        }

        public void ClearNewIncident()
        {
            NewIncident = new IncidentModel();
            NotifyOfPropertyChange(() => NewDescription);
            NotifyOfPropertyChange(() => NewDate);
            NotifyOfPropertyChange(() => NewSeverity);
        }
    }
}
