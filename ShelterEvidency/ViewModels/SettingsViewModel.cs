using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    class SettingsViewModel: Conductor<object>
    {
        public void ComboBoxSettings()
        {
            ActivateItem(new ComboBoxSettingsViewModel());
        }
    }
}
