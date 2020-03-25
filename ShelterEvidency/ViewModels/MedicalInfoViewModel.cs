using Caliburn.Micro;
using ShelterEvidency.Models;
using ShelterEvidency.WrappingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    public class MedicalInfoViewModel: Screen
    {
        #region Initialization

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

        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            Task.Run(() => LoadData());
        }


        private async Task LoadData()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                AnimalMedicalRecords = MedicalRecordModel.GetAnimalMedicalRecords(AnimalID);
                VetList = PersonModel.ReturnVets();
                NewVetList = PersonModel.ReturnVets();
            });
            IsWorking = false;
        }

        private volatile bool _isWorking;
        public bool IsWorking
        {
            get
            {
                return _isWorking;
            }
            set
            {
                _isWorking = value;
                NotifyOfPropertyChange(() => IsWorking);
            }
        }

        #endregion

        #region Lists 


        private BindableCollection<MedicalRecordInfo> _animalMedicalRecords;
        public BindableCollection<MedicalRecordInfo> AnimalMedicalRecords
        {
            get
            {
                return _animalMedicalRecords;
            }
            set
            {
                _animalMedicalRecords = value;
                NotifyOfPropertyChange(() => AnimalMedicalRecords);
            }
        }


        private BindableCollection<PersonInfo> _vetList;
        public BindableCollection<PersonInfo> VetList
        {
            get
            {
                return _vetList;
            }
            set
            {
                _vetList = value;
                NotifyOfPropertyChange(() => VetList);
            }
        }

        private BindableCollection<PersonInfo> _newvetList;
        public BindableCollection<PersonInfo> NewVetList
        {
            get
            {
                return _newvetList;
            }
            set
            {
                _newvetList = value;
                NotifyOfPropertyChange(() => NewVetList);
            }
        }

        #endregion

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

        private MedicalRecordInfo _selectedMedicalRecord;

        public MedicalRecordInfo SelectedMedicalRecord
        {
            get
            {
                return _selectedMedicalRecord;
            }
            set
            {
                _selectedMedicalRecord = value;
                NotifyOfPropertyChange(() => SelectedMedicalRecord);
                Task.Run(() => Selection());
            }
        }

        private async Task Selection()
        {
            if (SelectedMedicalRecord != null)
            {
                IsWorking = true;
                await Task.Delay(150);
                await Task.Run(() =>
                {
                    MedicalRecord.GetMedicalRecord(SelectedMedicalRecord.ID);
                    MedicalCost.GetCost(MedicalRecord.CostID);
                });
                IsWorking = false;
            }
            NotifyOfPropertyChange(() => RecordName);
            NotifyOfPropertyChange(() => Description);
            NotifyOfPropertyChange(() => Vet);
            NotifyOfPropertyChange(() => Date);
            NotifyOfPropertyChange(() => Price);
            NotifyOfPropertyChange(() => IsSelected);


        }

        public void UpdateMedicalRecord()
        {
            if (MedicalRecord != null)
            {
                IsWorking = true;
                MedicalRecord.UpdateMedicalRecord();
                MedicalCost.UpdateCost();
                Filter();
                MessageBox.Show("Upraveno.");
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

        #region Methods


        public void Filter()
        {
            if (Since == null || To == null)
                Task.Run(() => GetData());
            else
                Task.Run(() => FilterData());


        }

        private async Task FilterData()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                AnimalMedicalRecords = MedicalRecordModel.GetDatedMedicalRecords(AnimalID, Since, To);
            });
            IsWorking = false;
        }

        private async Task GetData()
        {
            IsWorking = true;
            await Task.Delay(150);
            await Task.Run(() =>
            {
                AnimalMedicalRecords = MedicalRecordModel.GetAnimalMedicalRecords(AnimalID);
            });
            IsWorking = false;
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

        public void CreateNewMedicalRecord()
        {
            if (NewRecordName != null)
            {
                IsWorking = true;
                NewMedicalCost.AnimalID = AnimalID;
                NewMedicalCost.SaveCost();
                NewMedicalRecord.CostID = NewMedicalCost.ID;
                NewMedicalRecord.AnimalID = AnimalID;
                NewMedicalRecord.SaveMedicalRecord();
                Filter();
                IsWorking = false;
                ClearNewMedicalRecord();
                MessageBox.Show("Záznam vytvořen.");
            }
            else
                MessageBox.Show("Vyplňte prosím název.");
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

        public bool IsSelected
        {
            get
            {
                if (SelectedMedicalRecord != null)
                    return true;
                else
                    return false;
            }

        }

        public void DeleteRecord()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete vymazat zvolený záznam?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                CostModel.MarkAsDeleted((int)SelectedMedicalRecord.CostID);
                MedicalRecordModel.MarkAsDeleted((int)SelectedMedicalRecord.ID);

                MedicalCost = new CostModel();
                MedicalRecord = new MedicalRecordModel();
                SelectedMedicalRecord = null;

                Filter();
            }
        }

        #endregion

    }
}
