using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency
{
    public class PersonInfo
    {
        public int ID { get; set; }

        /*
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        */
        public string TitledFullName { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Note { get; set; }
        public string AdressCity { get; set; }
        public string AdressStreet { get; set; }
        public string AdressZip { get; set; }
        public bool? IsOwner { get; set; }
        public bool? IsVet { get; set; }
        public bool? IsWalker { get; set; }
        public bool? IsSponsor { get; set; }
        public bool? IsVolunteer { get; set; }
    }
}
