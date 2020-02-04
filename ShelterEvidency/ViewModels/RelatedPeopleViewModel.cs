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
        public PersonModel Owner { get; set; }
        public PersonModel NewOwner { get; set; }
        public RelatedPeopleViewModel(int animalID)
        {
            Animal = new AnimalModel();
            Animal.GetAnimal(animalID);

            Vet = new PersonModel();
            if(Animal.VetID != null)
                Vet.GetPerson((int)Animal.VetID);

            Owner = new PersonModel();
            if (Animal.OwnerID != null)
                Owner.GetPerson((int)Animal.OwnerID);

            NewOwner = new PersonModel();
            if (Animal.NewOwnerID != null)
                NewOwner.GetPerson((int)Animal.NewOwnerID);
        }


        #region Binded Vet Properties

        public string VetFullName
        {
            get
            {
                 return Vet.Title + " " + Vet.FirstName + " " + Vet.LastName;
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
        
        #region Binded ExOwner Properties

        public string ExFullName
        {
            get
            {
                 return Owner.Title + " " + Owner.FirstName + " " + Owner.LastName;
            }
        }
        public string ExPhone
        {
            get
            {
                 return Owner.Phone;
            }
        }

        public string ExMail
        {
            get
            {
                 return Owner.Mail;
            }
        }

        public string ExCity
        {
            get
            {

                 return Owner.AdressCity;

            }
        }

        public string ExStreet
        {
            get
            {

                 return Owner.AdressStreet;

            }
        }
        public string ExZip
        {
            get
            {

                 return Owner.AdressZip;

            }
        }

        #endregion
    
        #region Binded NewOwner Properties

        public string FullName
        {
            get
            {
                 return NewOwner.Title + " " + NewOwner.FirstName + " " + NewOwner.LastName;
            }
        }
        public string Phone
        {
            get
            {
                 return NewOwner.Phone;
            }
        }

        public string Mail
        {
            get
            {
                 return NewOwner.Mail;
            }
        }

        public string City
        {
            get
            {
                 return NewOwner.AdressCity;
            }
        }

        public string Street
        {
            get
            {
                 return NewOwner.AdressStreet;
            }
        }
        public string Zip
        {
            get
            {
                 return NewOwner.AdressZip;
            }
        }

        #endregion
    }
}
