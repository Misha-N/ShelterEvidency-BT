using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    class MedicalRecordModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string RecordName { get; set; }
        public string Description { get; set; }
        public int CostID { get; set; }
        public int AnimalID { get; set; }
        public DateTime? Date { get; set; }
        public int VetID { get; set; }
        #endregion
    }
}
