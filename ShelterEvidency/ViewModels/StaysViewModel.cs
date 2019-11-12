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
        public List<Database.EndTypes> EndTypes
        {
            get
            {
                return EndTypeModel.ReturnEndTypes();
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
        public int? EndType
        {
            get
            {
                return Stay.EndTypeID;
            }
            set
            {
                Stay.EndTypeID = value;
                NotifyOfPropertyChange(() => EndType);
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
            NotifyOfPropertyChange(() => EndType);
            NotifyOfPropertyChange(() => Note);
            NotifyOfPropertyChange(() => SelectedStayID);
        }

        private DateTime? _newStayDate;
        public DateTime? NewStayDate
        {
            get
            {
                return _newStayDate;
            }
            set
            {
                _newStayDate = value;
                NotifyOfPropertyChange(() => NewStayDate);
            }
        }

    }
}
