using Caliburn.Micro;

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
