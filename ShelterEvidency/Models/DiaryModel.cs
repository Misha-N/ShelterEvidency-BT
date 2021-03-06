﻿using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.WrappingClasses;
using System;
using System.Linq;
using System.Windows;

namespace ShelterEvidency.Models
{
    public class DiaryModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Record { get; set; }
        #endregion

        public DiaryModel()
        {
            Date = DateTime.Today;
        }

        #region Methods
        public void SaveDiaryRecord()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    DiaryRecords diaryRecord = new DiaryRecords
                    {
                        Date = Date,
                        Record = Record
                    };
                    db.DiaryRecords.InsertOnSubmit(diaryRecord);
                    db.SubmitChanges();

                    ID = diaryRecord.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static BindableCollection<DiaryRecordInfo> GetDiaryRecords(DateTime selectedDate)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var results = (from record in db.DiaryRecords
                                   where (record.Date.Equals(selectedDate)) && (record.IsDeleted.Equals(null))
                                   select new DiaryRecordInfo
                                   {
                                       ID = record.Id,
                                       Date = record.Date,
                                       Record = record.Record
                                   });
                    return new BindableCollection<DiaryRecordInfo>(results);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<DiaryRecordInfo>();
            }
        }

        public static void MarkAsDeleted(int id)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var record = db.DiaryRecords.Single(x => x.Id == id);
                    record.IsDeleted = DateTime.Now;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public bool ValidValues()
        {
            if (Date != null && Date != DateTime.MinValue && Date != DateTime.MaxValue &&
                !String.IsNullOrEmpty(Record))
                return true;
            else
                return false;
        }

        public static void RestoreDeleted(DateTime since, DateTime to)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var records = (from record in db.DiaryRecords
                                   where record.IsDeleted >= since && record.IsDeleted <= to
                                   select record).ToList();

                    foreach (var record in records)
                    {
                        record.IsDeleted = null;
                    }


                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
