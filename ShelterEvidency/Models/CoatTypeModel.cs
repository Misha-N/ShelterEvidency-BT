﻿using Caliburn.Micro;
using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class CoatTypeModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string CoatTypeName { get; set; }
        #endregion


        public static BindableCollection<CoatTypes> ReturnCoatTypes()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                return new  BindableCollection<CoatTypes>(db.CoatTypes);
            }
        }

        public void SaveCoatType()
        {
            if (CoatTypeName != null)
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    CoatTypes coatType = new CoatTypes
                    {
                        CoatTypeName = CoatTypeName
                    };
                    db.CoatTypes.InsertOnSubmit(coatType);
                    db.SubmitChanges();

                    ID = coatType.Id;
                }
            }

        }
    }
}
