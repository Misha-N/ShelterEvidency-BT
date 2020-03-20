using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    class WalksViewModel: Screen
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

        public WalkModel Walk { get; set; }
        public WalkModel NewWalk { get; set; }

        public WalksViewModel(int animalID)
        {
            AnimalID = animalID;
            Walk = new WalkModel();
            NewWalk = new WalkModel();
        }
        public List<Database.Walks> AnimalWalks
        {
            get
            {
                return WalkModel.GetAnimalWalks(AnimalID);
            }
        }
        public BindableCollection<PersonInfo> WalkerList
        {
            get
            {
                return PersonModel.ReturnWalkers();
            }
        }

        #region Selected medical record bindings

        public DateTime? Date
        {
            get
            {
                return Walk.Date;
            }
            set
            {
                Walk.Date = value;
                NotifyOfPropertyChange(() => Date);
            }
        }
        public int? Walker
        {
            get
            {
                return Walk.PersonID;
            }
            set
            {
                Walk.PersonID = value;
                NotifyOfPropertyChange(() => Walker);
            }
        }
        public string Note
        {
            get
            {
                return Walk.Note;
            }
            set
            {
                Walk.Note = value;
                NotifyOfPropertyChange(() => Note);
            }
        }

        #endregion
        public int? SelectedWalk
        {
            get
            {
                return Walk.ID;
            }
            set
            {
                Walk.GetWalk(value);
                Selection();
            }
        }

        private void Selection()
        {
            NotifyOfPropertyChange(() => Note);
            NotifyOfPropertyChange(() => Date);
            NotifyOfPropertyChange(() => Walker);
        }

        public void UpdateWalk()
        {
            if (SelectedWalk != null)
            {
                Walk.UpdateWalk();
                NotifyOfPropertyChange(() => AnimalWalks);
            }
        }

        #region New walk bindings

        public DateTime? NewDate
        {
            get
            {
                return NewWalk.Date;
            }
            set
            {
                NewWalk.Date = value;
                NotifyOfPropertyChange(() => NewDate);
            }
        }
        public int? NewWalker
        {
            get
            {
                return NewWalk.PersonID;
            }
            set
            {
                NewWalk.PersonID = value;
                NotifyOfPropertyChange(() => NewWalker);
            }
        }
        public string NewNote
        {
            get
            {
                return NewWalk.Note;
            }
            set
            {
                NewWalk.Note = value;
                NotifyOfPropertyChange(() => NewNote);
            }
        }

        #endregion


        public void CreateNewWalk()
        {
            if (NewDate != null)
            {
                NewWalk.AnimalID = AnimalID;
                NewWalk.SaveWalk();
                NotifyOfPropertyChange(() => AnimalWalks);
                ClearNewWalk();
            }
        }

        public void ClearNewWalk()
        {
            NewWalk = new WalkModel();
            NotifyOfPropertyChange(() => NewWalk);
            NotifyOfPropertyChange(() => NewDate);
            NotifyOfPropertyChange(() => NewWalker);
            NotifyOfPropertyChange(() => NewNote);
        }

    }

}

