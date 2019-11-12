using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    class WalkModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int AnimalID { get; set; }
        public int PersonID { get; set; }
        #endregion
    }
}
