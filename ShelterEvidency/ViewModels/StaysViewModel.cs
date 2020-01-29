using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    public class StaysViewModel: Screen
    {
        private int _animalID;
        public int AnimalID
        {
            get
            {
                return _animalID;
            }
            set
            {
                _animalID = value;
                NotifyOfPropertyChange(() => AnimalID);
            }
        }

        public StayModel Stay { get; set; }
        public StayModel NewStay { get; set; }
        public StaysViewModel(int animalID)
        {
            AnimalID = animalID;
            Stay = new StayModel();
            NewStay = new StayModel();
        }
        public List<Database.Stays> AnimalStays
        {
            get
            {
                return StayModel.GetAnimalStays(AnimalID);
            }
        }

        #region Selected stay bindings
        public DateTime? Start
        {
            get
            {
                return Stay.StartDate;
            }
            set
            {
                Stay.StartDate = value;
                NotifyOfPropertyChange(() => Start);
            }
        }
        public DateTime? Finish
        {
            get
            {
                return Stay.FinishDate;
            }
            set
            {
                Stay.FinishDate = value;
                NotifyOfPropertyChange(() => Finish);
            }
        }
        public string Note
        {
            get
            {
                return Stay.Note;
            }
            set
            {
                Stay.Note = value;
                NotifyOfPropertyChange(() => Note);
            }
        }

        public bool? Adopted
        {
            get
            {
                return Stay.Adopted;
            }
            set
            {
                Stay.Adopted = value;
                NotifyOfPropertyChange(() => Adopted);
            }
        }

        public bool? Escaped
        {
            get
            {
                return Stay.Escaped;
            }
            set
            {
                Stay.Escaped = value;
                NotifyOfPropertyChange(() => Escaped);
            }
        }

        public bool? Died
        {
            get
            {
                return Stay.Died;
            }
            set
            {
                Stay.Died = value;
                NotifyOfPropertyChange(() => Escaped);
            }
        }
        #endregion
        public int? SelectedStayID
        {
            get
            {
                return Stay.ID;
            }
            set
            {
                Stay.GetStay(value);
                Selection();
            }
        }

        private void Selection()
        {
            NotifyOfPropertyChange(() => Start);
            NotifyOfPropertyChange(() => Finish);
            NotifyOfPropertyChange(() => Note);
            NotifyOfPropertyChange(() => SelectedStayID);
            NotifyOfPropertyChange(() => Adopted);
            NotifyOfPropertyChange(() => Escaped);
            NotifyOfPropertyChange(() => Died);
        }

        public void UpdateStay()
        {
            if (SelectedStayID != null)
            {
                Stay.UpdateStay();
                NotifyOfPropertyChange(() => AnimalStays);
            }
        }

        public void CreateNewStay()
        {
            if (NewStayDate != null)
            {
                NewStay.AnimalID = AnimalID;
                NewStay.SaveStay();
            }
            NotifyOfPropertyChange(() => AnimalStays);
        }
        public DateTime? NewStayDate
        {
            get
            {
                return NewStay.StartDate;
            }
            set
            {
                NewStay.StartDate = value;
                NotifyOfPropertyChange(() => NewStayDate);
            }
        }

    }
}
