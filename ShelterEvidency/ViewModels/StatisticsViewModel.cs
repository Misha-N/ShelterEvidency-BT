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
        private int _animalID;

        public int AnimalID
        {
            get 
            { 
                return _animalID; 
            }
            set 
            { 
                _animalID = value;
                NotifyOfPropertyChange(() => AnimalID);
            }
        }


        public int? AnimalsInShelterSum
        {
            get
            {
                return StatisticModel.AnimalsInShelterSum();
            }

        }

        public int? SuccessfullyAdoptedAnimals
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
