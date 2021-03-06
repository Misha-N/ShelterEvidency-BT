﻿using ShelterEvidency.Models;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    class GeneralCostsViewModel : CostsViewModel
    {
        public GeneralCostsViewModel(int? animalID): base(animalID)
        {
           
        }

        public override async Task LoadData()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                AnimalCosts = CostModel.GetAllCosts();
            });
            IsWorking = false;
        }

    }
}
