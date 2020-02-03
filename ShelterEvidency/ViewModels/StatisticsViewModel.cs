using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    class StatisticsViewModel: Screen
    {

        public int AnimalsInShelterSum
        {
            get
            {
                return StatisticModel.AnimalsInShelterSum();
            }

        }

        public int SuccessfullyAdoptedAnimals
        {
            get
            {
                return StatisticModel.SuccessfullyAdoptedAnimals();
            }

        }

        public int? TotalCosts
        {
            get
            {
                return StatisticModel.TotalCosts();
            }

        }

        public int? TotalDonations
        {
            get
            {
                return StatisticModel.TotalDonations();
            }

        }
    }
}
