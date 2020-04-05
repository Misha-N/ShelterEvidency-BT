using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.WrappingClasses;
using System;
using System.Linq;
using System.Windows;

namespace ShelterEvidency.Models
{
    class IncidentModel
    {
        #region Properties/Atributes
        public int? ID { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        public int? Severity { get; set; }
        public int? AnimalID { get; set; }
        #endregion

        public void SaveIncident()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    Incidents incident = new Incidents
                    {
                        AnimalID = AnimalID,
                        Severity = Severity,
                        Description = Description,
                        IncidentDate = Date
                    };
                    db.Incidents.InsertOnSubmit(incident);
                    db.SubmitChanges();

                    ID = incident.ID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static BindableCollection<IncidentInfo> GetAnimalIncidents(int animalID)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var results = (from incident in db.Incidents
                                   where (incident.AnimalID.Equals(animalID)) && (incident.IsDeleted.Equals(false))
                                   select new IncidentInfo
                                   {
                                       ID = incident.ID,
                                       Date = incident.IncidentDate,
                                       AnimalID = incident.AnimalID,
                                       AnimalName = incident.Animals.Name,
                                       Description = incident.Description,
                                       Severity = incident.Severity,
                                   });
                    return new BindableCollection<IncidentInfo>(results);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<IncidentInfo>();
            }
        }

        public static BindableCollection<IncidentInfo> GetDatedAnimalIncidents(int animalID, DateTime? since, DateTime? to)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var results = (from incident in db.Incidents
                                   where (incident.AnimalID.Equals(animalID) && (incident.IncidentDate >= since && incident.IncidentDate <= to))
                                    && (incident.IsDeleted.Equals(false))
                                   select new IncidentInfo
                                   {
                                       ID = incident.ID,
                                       Date = incident.IncidentDate,
                                       AnimalID = incident.AnimalID,
                                       AnimalName = incident.Animals.Name,
                                       Description = incident.Description,
                                       Severity = incident.Severity,
                                   });
                    return new BindableCollection<IncidentInfo>(results);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<IncidentInfo>();
            }
        }

        public void GetIncident(int? incidentID)
        {
            try
            {
                ID = incidentID;
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var incident = db.Incidents.FirstOrDefault(i => i.ID == incidentID);
                    if (incident != null)
                        SetInformations(incident);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SetInformations(Incidents incident)
        {
            Date = incident.IncidentDate;
            Description = incident.Description;
            Severity = incident.Severity;
            AnimalID = incident.AnimalID;
        }
        public void UpdateIncident()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    Incidents incident = db.Incidents.FirstOrDefault(i => i.ID == ID);

                    incident.IncidentDate = Date;
                    incident.Severity = Severity;
                    incident.Description = Description;
                    incident.AnimalID = AnimalID;

                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void MarkAsDeleted(int id)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var incident = db.Incidents.Single(x => x.ID == id);
                    incident.IsDeleted = true;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool ValidValues()
        {
            if (Date != null && Date != DateTime.MinValue && Date != DateTime.MaxValue &&
                 Severity != null)
                return true;
            else
                return false;
        }
    }
}
