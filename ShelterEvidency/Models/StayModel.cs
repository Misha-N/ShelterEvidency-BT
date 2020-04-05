using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.WrappingClasses;
using System;
using System.Linq;
using System.Windows;

namespace ShelterEvidency.Models
{
    public class StayModel
    {
        #region Properties/Atributes
        public int? ID { get; set; }

        public DateTime? FindDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int? AnimalID { get; set; }
        public string Note { get; set; }
        public string FindPlace { get; set; }
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
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    Stays stay = new Stays
                    {
                        AnimalID = AnimalID,
                        StartDate = StartDate,
                        FinishDate = FinishDate,
                        Note = Note,
                        FindDate = FindDate,
                        FindPlace = FindPlace,
                        Adopted = Adopted,
                        Escaped = Escaped,
                        Died = Died
                    };
                    db.Stays.InsertOnSubmit(stay);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void GetStay(int? stayID)
        {
            try
            {
                ID = stayID;
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var stay = db.Stays.FirstOrDefault(i => i.Id == stayID);
                    if (stay != null)
                        SetInformations(stay);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static BindableCollection<StayInfo> GetAnimalStays(int animalID)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var results = (from stay in db.Stays
                                   where (stay.AnimalID.Equals(animalID)) && (stay.IsDeleted.Equals(false))
                                   select new StayInfo
                                   {
                                       ID = stay.Id,
                                       FindDate = stay.FindDate,
                                       FindPlace = stay.FindPlace,
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<StayInfo>();
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
            FindPlace = stay.FindPlace;
            FindDate = stay.FindDate;
        }

        public void UpdateStay()
        {
            try
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
                    stay.FindDate = FindDate;
                    stay.FindPlace = FindPlace;

                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static BindableCollection<StayInfo> GetDatedStays(DateTime? since, DateTime? to)
        {
            try
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
                                       Died = stay.Died,
                                       FindDate = stay.FindDate,
                                       FindPlace = stay.FindPlace
                                   });
                    return new BindableCollection<StayInfo>(results);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<StayInfo>();
            }
        }

        public static void MarkAsDeleted(int id)
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    var stay = db.Stays.Single(x => x.Id == id);
                    stay.IsDeleted = true;
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
            if (StartDate != null && StartDate != DateTime.MinValue && StartDate != DateTime.MaxValue)
                return true;
            else
                return false;
        }

    }
}
