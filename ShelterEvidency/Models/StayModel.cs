﻿using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.WrappingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.Models
{
    public class StayModel
    {
        #region Properties/Atributes
        public int? ID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int? AnimalID { get; set; }
        public string Note { get; set; }
        public bool? Adopted { get; set; }
        public bool? Escaped { get; set; }
        public bool? Died { get; set; }
        #endregion

        public StayModel()
        {
            Adopted = false;
            Escaped = false;
            Died = false;
        }

        public void SaveStay()
            {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                Stays stay = new Stays
                {
                    AnimalID = AnimalID,
                    StartDate = StartDate,
                    FinishDate = FinishDate,
                    Note = Note,
                    Adopted = Adopted,
                    Escaped = Escaped,
                    Died = Died
                };
                db.Stays.InsertOnSubmit(stay);
                db.SubmitChanges();
            }

        }

        public void GetStay(int? stayID)
        {
            ID = stayID;
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var stay = db.Stays.FirstOrDefault(i => i.Id == stayID);
                if (stay != null)
                    SetInformations(stay);
            }
        }

        public static BindableCollection<StayInfo> GetAnimalStays(int animalID)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                    var results = (from stay in db.Stays
                                   where (stay.AnimalID.Equals(animalID)) && (stay.IsDeleted.Equals(false))
                                   select new StayInfo
                                   {
                                       ID = stay.Id,
                                       StartDate = stay.StartDate,
                                       FinishDate = stay.FinishDate,
                                       AnimalID = stay.AnimalID,
                                       AnimalName = stay.Animals.Name,
                                       Note = stay.Note,
                                       Adopted = stay.Adopted,
                                       Escaped = stay.Escaped,
                                       Died = stay.Died
                                   });
                    return new BindableCollection<StayInfo>(results);
                
            }
        }

        public void SetInformations(Stays stay)
        {
            StartDate = stay.StartDate;
            FinishDate = stay.FinishDate;
            AnimalID = stay.AnimalID;
            Note = stay.Note;
            Adopted = stay.Adopted;
            Escaped = stay.Escaped;
            Died = stay.Died;
        }

        public void UpdateStay()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                Stays stay = db.Stays.FirstOrDefault(i => i.Id == ID);

                stay.StartDate = StartDate;
                stay.FinishDate = FinishDate;
                stay.Note = Note;
                stay.Adopted = Adopted;
                stay.Escaped = Escaped;
                stay.Died = Died;

                db.SubmitChanges();
            }
        }

        public static BindableCollection<StayInfo> GetDatedStays(DateTime? since, DateTime? to)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {

                var results = (from stay in db.Stays
                               where (stay.StartDate >= since && stay.StartDate <= to) && (stay.IsDeleted.Equals(false))
                               select new StayInfo
                               {
                                   ID = stay.Id,
                                   StartDate = stay.StartDate,
                                   FinishDate = stay.FinishDate,
                                   AnimalID = stay.AnimalID,
                                   AnimalName = stay.Animals.Name,
                                   Note = stay.Note,
                                   Adopted = stay.Adopted,
                                   Escaped = stay.Escaped,
                                   Died = stay.Died
                               });
                return new BindableCollection<StayInfo>(results);
            }
        }

        public static void MarkAsDeleted(int id)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var stay = db.Stays.Single(x => x.Id == id);
                stay.IsDeleted = true;
                db.SubmitChanges();
            }
        }

        public bool ValidValues()
        {
            if (StartDate != null && StartDate != DateTime.MinValue && StartDate != DateTime.MaxValue)
                return true;
            else
                return false;
        }

    }
}
