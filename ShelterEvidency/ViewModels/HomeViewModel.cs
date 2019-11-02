using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    public class HomeViewModel: Conductor<object>
    {
        public void LoadAddAnimalPage()
        {
            ActivateItem(new AddAnimalViewModel());
        }

        public void LoadSearchAnimalPage()
        {
            ActivateItem(new SearchAnimalViewModel());
        }

        public void LoadSearchPersonPage()
        {
            ActivateItem(new SearchPersonViewModel());
        }

        public void LoadAddPersonPage()
        {
            ActivateItem(new AddPersonViewModel());
        }

        public void LoadSettingsPAge()
        {
            ActivateItem(new SettingsViewModel());
        }

        public void Home()
        {
            ActivateItem(null);
        }
    }
}
