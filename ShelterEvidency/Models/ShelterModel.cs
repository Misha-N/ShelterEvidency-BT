﻿using ShelterEvidency.Database;
using System;
using System.Linq;
using System.Windows;

namespace ShelterEvidency.Models
{
    public class ShelterModel
    {

        #region Properties/Atributes
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public string Phone2 { get; set; }

        public string Mail { get; set; }

        public string Adress { get; set; }

        public string Account { get; set; }

        public string LogoPath { get; set; }

        #endregion

        public ShelterModel()
        {
            GetInfo();
        }

        public void GetInfo()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    Shelter shelter = db.Shelter.FirstOrDefault();

                    ID = shelter.Id;
                    Name = shelter.Name;
                    Phone = shelter.Phone;
                    Phone2 = shelter.Phone2;
                    Mail = shelter.Mail;
                    Account = shelter.Account;
                    Adress = shelter.Adress;
                    LogoPath = shelter.LogoPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
   

        public void UpdateInfo()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    Shelter shelter = db.Shelter.FirstOrDefault();

                    shelter.Name = Name;
                    shelter.Phone = Phone;
                    shelter.Phone2 = Phone2;
                    shelter.Mail = Mail;
                    shelter.Adress = Adress;
                    shelter.Account = Account;

                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void SetLogo(string path)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    Shelter shelter = db.Shelter.FirstOrDefault();

                    shelter.LogoPath = path;


                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




    }
}
