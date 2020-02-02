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
                return CostModel.GetAllCosts();
            }
        }

    }
}
