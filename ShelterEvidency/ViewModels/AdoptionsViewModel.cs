using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    class AdoptionsViewModel: Conductor<object>
    {
        public List<AdoptionInfo> Adoptions
        {
            get
            {
                if (SearchValue == null)
                    return AdoptionModel.ReturnAdoptions();
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
                NotifyOfPropertyChange(() => Adoptions);
            }
        }

        private AdoptionInfo _selectedAdoption;

        public AdoptionInfo SelectedAdoption
        {
            get
            {
                return _selectedAdoption;
            }
            set
            {
                _selectedAdoption = value;
                NotifyOfPropertyChange(() => SelectedAdoption);
            }
        }


        public List<AdoptionInfo> Search()
        {
            return AdoptionModel.ReturnSpecificAdoptions(SearchValue);
        }

        public void CreateAdoption()
        {
            ActivateItem(new CreateAdoptionViewModel());
        }

        public void OpenAdoption()
        {
            if (SelectedAdoption != null)
                ActivateItem(new AdoptionCardViewModel(SelectedAdoption.ID));
        }

        public void UpdateAdoptions()
        {
            NotifyOfPropertyChange(() => Adoptions);
        }

    }
}

