using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    class IncidentTypeModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string IncidentTypeName { get; set; }
        public int Severity { get; set; }

        #endregion
    }
}
