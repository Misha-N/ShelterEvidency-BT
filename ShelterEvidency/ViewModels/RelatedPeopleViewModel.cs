using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    public class RelatedPeopleViewModel: Screen
    {
        public AnimalModel Animal { get; set; }
        public PersonModel Vet { get; set; }
        public RelatedPeopleViewModel(int animalID)
        {
            Animal = new AnimalModel();
            Animal.GetAnimal(animalID);
            Vet = new PersonModel();
            Vet.GetPerson((int)Animal.VetID);
        }

        #region Binded Vet Properties

        public string VetFullName
        {
            get
            {
                    return Vet.Title.Trim() + " " + Vet.FirstName + " " + Vet.LastName;
            }
        }
        public string VetPhone
        {
            get
            {
                    return Vet.Phone;
            }
        }

        public string VetMail
        {
            get
            {
                    return Vet.Mail;
            }
        }

        public string VetCity
        {
            get
            {
                    return Vet.AdressCity;
            }
        }

        public string VetStreet
        {
            get
            {
                    return Vet.AdressStreet;
            }
        }
        public string VetZip
        {
            get
            {
                    return Vet.AdressZip;
            }
        }

        #endregion
    }
}
