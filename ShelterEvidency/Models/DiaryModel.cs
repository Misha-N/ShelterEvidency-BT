using ShelterEvidency.Database;
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
        public DateTime? Date { get; set; }
        public string Record { get; set; }
        #endregion

        public DiaryModel()
        {
            Date = DateTime.Today;
        }

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

        public static List<DiaryRecords> GetDiaryRecords(DateTime? selectedDate)
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                return db.DiaryRecords.Where(x => x.Date.Equals(selectedDate)).ToList();
            }
        }
    }
}
