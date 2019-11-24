using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    class CreateAdoptionViewModel
    {
        public List<AnimalInfo> Animals
        {
            get
            {
                    return AnimalModel.ReturnAnimals();
            }
        }
        public List<PersonInfo> Owners
        {
            get
            {
                    return PersonModel.ReturnOwners();
            }
        }
    }
}
