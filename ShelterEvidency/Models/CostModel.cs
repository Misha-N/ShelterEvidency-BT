using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    class CostModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string CostName { get; set; }
        public string Description { get; set; }
        public int price { get; set; }
        public int AnimalID { get; set; }

        #endregion
    }
}
