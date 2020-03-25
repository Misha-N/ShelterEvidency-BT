using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    public class SearchPersonViewModel: Conductor<object>
    {
        #region Initialize
        public PersonModel Person { get; set; }
        public SearchPersonViewModel()
        {
            Person = new PersonModel();
        }

        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            LoadData();
        }


        private async void LoadData()
        {
            IsWorking = true;
            await Task.Delay(150);
            People = await Task.Run(() => PersonModel.ReturnPeople());
            IsWorking = false;
        }

        private bool _isWorking;

        public bool IsWorking
        {
            get
            {
                return _isWorking;
            }
            set
            {
                _isWorking = value;
                NotifyOfPropertyChange(() => IsWorking);
            }
        }

        #endregion

        #region People Data Table

        private BindableCollection<PersonInfo> _people;

        public BindableCollection<PersonInfo> People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;
                NotifyOfPropertyChange(() => People);
            }
        }


        private string _searchValue;

        public string SearchValue
        {
            get
            {
                return _searchValue;
            }
            set
            {
                _searchValue = value;
                NotifyOfPropertyChange(() => SearchValue);
            }
        }

        private PersonInfo _selectedPerson;

        public PersonInfo SelectedPerson
        {
            get
            {
                return _selectedPerson;
            }
            set
            {
                _selectedPerson = value;
                NotifyOfPropertyChange(() => SelectedPerson);
                NotifyOfPropertyChange(() => IsSelected);
            }
        }

        #endregion

        #region Methods
        public async void Search()
        {
            IsWorking = true;
            await Task.Delay(150);
            People = await Task.Run(() => PersonModel.ReturnSpecificPeople(SearchValue));
            IsWorking = false;
        }


        public void UpdatePeople()
        {
            LoadData();
        }

        public void OpenPersonInfo()
        {
            if (SelectedPerson != null)
                ActivateItem(new PersonInfoViewModel(SelectedPerson.ID, this));
        }

        #endregion



        #region Person Binded Atributes
        public string Title
        {
            get
            {
                return Person.Title;
            }
            set
            {
                Person.Title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }
        public string FirstName
        {
            get
            {
                return Person.FirstName;
            }
            set
            {
                Person.FirstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }
        public string LastName
        {
            get
            {
                return Person.LastName;
            }
            set
            {
                Person.LastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }
        public string Note
        {
            get
            {
                return Person.Note;
            }
            set
            {
                Person.Note = value;
                NotifyOfPropertyChange(() => Note);
            }
        }
        public string Phone
        {
            get
            {
                return Person.Phone;
            }
            set
            {
                Person.Phone = value;
                NotifyOfPropertyChange(() => Phone);
            }
        }
        public string Mail
        {
            get
            {
                return Person.Mail;
            }
            set
            {
                Person.Mail = value;
                NotifyOfPropertyChange(() => Mail);
            }
        }

        public string City
        {
            get
            {
                return Person.AdressCity;
            }
            set
            {
                Person.AdressCity = value;
                NotifyOfPropertyChange(() => City);
            }
        }

        public string Street
        {
            get
            {
                return Person.AdressStreet;
            }
            set
            {
                Person.AdressStreet = value;
                NotifyOfPropertyChange(() => Street);
            }
        }
        public string Zip
        {
            get
            {
                return Person.AdressZip;
            }
            set
            {
                Person.AdressZip = value;
                NotifyOfPropertyChange(() => Zip);
            }
        }

        public bool? IsOwner
        {
            get
            {
                return Person.IsOwner;
            }
            set
            {
                Person.IsOwner = value;
                NotifyOfPropertyChange(() => IsOwner);
            }
        }

        public bool? IsVet
        {
            get
            {
                return Person.IsVet;
            }
            set
            {
                Person.IsVet = value;
                NotifyOfPropertyChange(() => IsVet);
            }
        }

        public bool? IsWalker
        {
            get
            {
                return Person.IsWalker;
            }
            set
            {
                Person.IsWalker = value;
                NotifyOfPropertyChange(() => IsWalker);
            }
        }

        public bool? IsSponsor
        {
            get
            {
                return Person.IsSponsor;
            }
            set
            {
                Person.IsSponsor = value;
                NotifyOfPropertyChange(() => IsSponsor);
            }
        }

        public bool? IsVolunteer
        {
            get
            {
                return Person.IsVolunteer;
            }
            set
            {
                Person.IsVolunteer = value;
                NotifyOfPropertyChange(() => IsVolunteer);
            }
        }

        #endregion

        #region Methods

        public bool IsSelected
        {
            get
            {
                if (SelectedPerson != null)
                    return true;
                else
                    return false;
            }

        }

        public void SaveToDatabase()
        {
            Person.SavePerson();
            MessageBox.Show(Person.FirstName + " " + Person.LastName + " přidán do evidence.");
            UpdatePeople();

            Person = new PersonModel();
            NotifyOfPropertyChange(() => Title);
            NotifyOfPropertyChange(() => FirstName);
            NotifyOfPropertyChange(() => LastName);
            NotifyOfPropertyChange(() => Note);
            NotifyOfPropertyChange(() => Phone);
            NotifyOfPropertyChange(() => Mail);
            NotifyOfPropertyChange(() => City);
            NotifyOfPropertyChange(() => Street);
            NotifyOfPropertyChange(() => Zip);
            NotifyOfPropertyChange(() => IsOwner);
            NotifyOfPropertyChange(() => IsVet);
            NotifyOfPropertyChange(() => IsSponsor);
            NotifyOfPropertyChange(() => IsVolunteer);
            NotifyOfPropertyChange(() => IsWalker);
        }

        public void DeletePerson()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete vymazat zvolenou osobu?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                PersonModel.MarkAsDeleted((int)SelectedPerson.ID);
                LoadData();
            }
        }

        #endregion


    }
}
