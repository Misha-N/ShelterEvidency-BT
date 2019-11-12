﻿using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class SexModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string SexName { get; set; }
        #endregion

        public static List<Sexes> ReturnSexes()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            return db.Sexes.ToList();
        }
    }
}
