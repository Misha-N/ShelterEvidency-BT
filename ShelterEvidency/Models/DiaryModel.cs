using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.WrappingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static BindableCollection<DiaryRecordInfo> GetDiaryRecords(DateTime selectedDate)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                var results = (from record in db.DiaryRecords
                               where (record.Date.Equals(selectedDate))
                               select new DiaryRecordInfo
                               {
                                   ID = record.Id,
                                   Date = record.Date,
                                   Record = record.Record
                               });
                return new BindableCollection<DiaryRecordInfo>(results);

            }
        }
        #endregion
    }
}
