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
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public int IncidentTypeID { get; set; }
        public int AnimalID { get; set; }
        #endregion
    }
}
