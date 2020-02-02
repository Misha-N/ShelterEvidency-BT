using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    class EconomyViewModel: Conductor<object>
    {
        public EconomyViewModel()
        {
            Costs();
        }

        public void Costs()
        {
            ActivateItem(new GeneralCostsViewModel(null));
        }

        public void Donations()
        {
            ActivateItem(new DonationsViewModel());
        }
    }
}
