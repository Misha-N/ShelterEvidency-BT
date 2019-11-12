using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    class DonationModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string Name { get; set; }
        public int PersonID { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        #endregion
    }
}
