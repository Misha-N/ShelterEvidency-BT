using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static List<Incidents> GetAnimalIncidents(int animalID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                return db.Incidents.Where(x => x.AnimalID.Equals(animalID)).ToList();
            }
        }

        public void GetIncident(int? incidentID)
        {
            ID = incidentID;
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var incident = db.Incidents.FirstOrDefault(i => i.ID == incidentID);
                if (incident != null)
                    SetInformations(incident);
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
    }
}
