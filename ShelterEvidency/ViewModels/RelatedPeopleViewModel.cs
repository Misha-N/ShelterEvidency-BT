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
            if(Animal.VetID != null)
                Vet.GetPerson((int)Animal.VetID);
        }

        #region Binded Vet Properties

        public string VetFullName
        {
            get
            {
                if (Animal.VetID != null)
                    return Vet.Title.Trim() + " " + Vet.FirstName + " " + Vet.LastName;
                else
                    return null;
            }
        }
        public string VetPhone
        {
            get
            {
                if (Animal.VetID != null)
                    return Vet.Phone;
                else
                    return null;
            }
        }

        public string VetMail
        {
            get
            {
                if (Animal.VetID != null)
                    return Vet.Mail;
                else
                    return null;
            }
        }

        public string VetCity
        {
            get
            {
                if (Animal.VetID != null)
                    return Vet.AdressCity;
                else
                    return null;
            }
        }

        public string VetStreet
        {
            get
            {
                if (Animal.VetID != null)
                    return Vet.AdressStreet;
                else
                    return null;
            }
        }
        public string VetZip
        {
            get
            {
                if (Animal.VetID != null)
                    return Vet.AdressZip;
                else
                    return null;
            }
        }

        #endregion
    }
}
