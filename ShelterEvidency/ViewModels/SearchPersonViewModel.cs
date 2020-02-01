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
    public class SearchPersonViewModel: Conductor<object>
    {
        public List<PersonInfo> People
        {
            get
            {
                if (SearchValue == null)
                    return PersonModel.ReturnPeople();
                else
                    return Search();
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
                NotifyOfPropertyChange(() => People);
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
            }
        }

        public List<PersonInfo> Search()
        {
            return PersonModel.ReturnSpecificPeople(SearchValue);
        }

        public void AddPerson()
        {
            ActivateItem(new AddPersonViewModel());
        }

        public void UpdatePeople()
        {
            NotifyOfPropertyChange(() => People);
        }

        public void OpenPersonInfo()
        {
            if (SelectedPerson != null)
                ActivateItem(new PersonInfoViewModel(SelectedPerson.ID));
        }

    }
}
