using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    public class MedicalInfoViewModel: Screen
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

        public MedicalRecordModel MedicalRecord { get; set; }
        public MedicalRecordModel NewMedicalRecord { get; set; }
        public CostModel MedicalCost { get; set; }
        public CostModel NewMedicalCost { get; set; }

        public MedicalInfoViewModel(int animalID)
        {
            AnimalID = animalID;
            MedicalRecord = new MedicalRecordModel();
            NewMedicalRecord = new MedicalRecordModel();
            MedicalCost = new CostModel();
            NewMedicalCost = new CostModel();
        }
        public List<Database.MedicalRecords> AnimalMedicalRecords
        {
            get
            {
                return MedicalRecordModel.GetAnimalMedicalRecords(AnimalID);
            }
        }
        public BindableCollection<PersonInfo> VetList
        {
            get
            {
                return PersonModel.ReturnVets();
            }
        }

        #region Selected medical record bindings
        public string RecordName
        {
            get
            {
                return MedicalRecord.RecordName;
            }
            set
            {
                MedicalRecord.RecordName = value;
                MedicalCost.CostName = value;
                NotifyOfPropertyChange(() => RecordName);
            }
        }
        public DateTime? Date
        {
            get
            {
                return MedicalRecord.Date;
            }
            set
            {
                MedicalRecord.Date = value;
                MedicalCost.Date = value;
                NotifyOfPropertyChange(() => Date);
            }
        }
        public int? Vet
        {
            get
            {
                return MedicalRecord.VetID;
            }
            set
            {
                MedicalRecord.VetID = value;
                NotifyOfPropertyChange(() => Vet);
            }
        }
        public int? Price
        {
            get
            {
                return MedicalCost.Price;
            }
            set
            {
                MedicalCost.Price = value;
                NotifyOfPropertyChange(() => Price);
            }
        }
        public string Description
        {
            get
            {
                return MedicalRecord.Description;
            }
            set
            {
                MedicalRecord.Description = value;
                MedicalCost.Description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }
        #endregion
        public int? SelectedMedicalRecord
        {
            get
            {
                return MedicalRecord.ID;
            }
            set
            {
                MedicalRecord.GetMedicalRecord(value);
                MedicalCost.GetCost(MedicalRecord.CostID);
                Selection();
            }
        }

        private void Selection()
        {
            NotifyOfPropertyChange(() => RecordName);
            NotifyOfPropertyChange(() => Description);
            NotifyOfPropertyChange(() => Vet);
            NotifyOfPropertyChange(() => Date);
            NotifyOfPropertyChange(() => Price);
        }

        public void UpdateMedicalRecord()
        {
            if (SelectedMedicalRecord != null)
            {
                MedicalRecord.UpdateMedicalRecord();
                MedicalCost.UpdateCost();
                NotifyOfPropertyChange(() => AnimalMedicalRecords);
            }
        }

        #region New medical record bindings
        public string NewRecordName
        {
            get
            {
                return NewMedicalRecord.RecordName;
            }
            set
            {
                NewMedicalRecord.RecordName = value;
                NewMedicalCost.CostName = value;
                NotifyOfPropertyChange(() => NewRecordName);
            }
        }
        public DateTime? NewDate
        {
            get
            {
                return NewMedicalRecord.Date;
            }
            set
            {
                NewMedicalRecord.Date = value;
                NewMedicalCost.Date = value;
                NotifyOfPropertyChange(() => NewDate);
            }
        }
        public int? NewVet
        {
            get
            {
                return NewMedicalRecord.VetID;
            }
            set
            {
                NewMedicalRecord.VetID = value;
                NotifyOfPropertyChange(() => NewVet);
            }
        }
        public int? NewPrice
        {
            get
            {
                return NewMedicalCost.Price;
            }
            set
            {
                NewMedicalCost.Price = value;
                NotifyOfPropertyChange(() => NewPrice);
            }
        }
        public string NewDescription
        {
            get
            {
                return NewMedicalRecord.Description;
            }
            set
            {
                NewMedicalRecord.Description = value;
                NewMedicalCost.Description = value;
                NotifyOfPropertyChange(() => NewDescription);
            }
        }
        #endregion

        
        public void CreateNewMedicalRecord()
        {
            if (NewRecordName != null)
            {
                NewMedicalCost.AnimalID = AnimalID;
                NewMedicalCost.SaveCost();
                NewMedicalRecord.CostID = NewMedicalCost.ID;
                NewMedicalRecord.AnimalID = AnimalID;
                NewMedicalRecord.SaveMedicalRecord();
            }
            NotifyOfPropertyChange(() => AnimalMedicalRecords);
            ClearNewMedicalRecord();
        }

        public void ClearNewMedicalRecord()
        {
            NewMedicalRecord = new MedicalRecordModel();
            NewMedicalCost = new CostModel();
            NotifyOfPropertyChange(() => NewMedicalRecord);
            NotifyOfPropertyChange(() => NewMedicalCost);
            NotifyOfPropertyChange(() => NewRecordName);
            NotifyOfPropertyChange(() => NewDescription);
            NotifyOfPropertyChange(() => NewVet);
            NotifyOfPropertyChange(() => NewDate);
            NotifyOfPropertyChange(() => NewPrice);
            
        }

    }
}
