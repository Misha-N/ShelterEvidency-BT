using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    class GeneralCostsViewModel : CostsViewModel
    {
        public GeneralCostsViewModel(int? animalID): base(animalID)
        {

        }

        public override List<Database.Costs> AnimalCosts
        {
            get
            {
                if(Since != null && To != null)
                    return CostModel.GetDatedCosts(Since, To);
                else
                    return CostModel.GetAllCosts();
            }
        }

        public void Filter()
        {
            NotifyOfPropertyChange(() => AnimalCosts);
        }

        private DateTime? _since;
        public DateTime? Since
        {
            get
            {
                return _since;
            }
            set
            {
                _since = value;
                NotifyOfPropertyChange(() => Since);
            }

        }

        private DateTime? _to;
        public DateTime? To
        {
            get
            {
                return _to;
            }
            set
            {
                _to = value;
                NotifyOfPropertyChange(() => To);
            }

        }

    }
}
