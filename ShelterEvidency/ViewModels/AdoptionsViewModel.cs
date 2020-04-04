using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    public class AdoptionsViewModel: Conductor<object>
    {
        #region Initialize

        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            LoadData();
        }


        private async void LoadData()
        {
            IsWorking = true;
            await Task.Delay(150);
            Adoptions = await Task.Run(() => AdoptionModel.ReturnAdoptions());
            IsWorking = false;
        }

        private bool _isWorking;

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

        private BindableCollection<AdoptionInfo> _adoptions;

        public BindableCollection<AdoptionInfo> Adoptions
        {
            get
            {
                return _adoptions;
            }
            set
            {
                _adoptions = value;
                NotifyOfPropertyChange(() => Adoptions);
            }
        }


        private string _searchValue;

        public string SearchValue
        {
            get
            {
                return _searchValue;
            }
            set
            {
                _searchValue = value;
                NotifyOfPropertyChange(() => SearchValue);
            }
        }

        private AdoptionInfo _selectedAdoption;

        public AdoptionInfo SelectedAdoption
        {
            get
            {
                return _selectedAdoption;
            }
            set
            {
                _selectedAdoption = value;
                NotifyOfPropertyChange(() => SelectedAdoption);
                NotifyOfPropertyChange(() => IsSelected);
            }
        }

        public bool IsSelected
        {
            get
            {
                if (SelectedAdoption != null)
                    return true;
                else
                    return false;
            }

        }

        public async void Search()
        {
            IsWorking = true;
            await Task.Delay(150);
            Adoptions = await Task.Run(() => AdoptionModel.ReturnAdoptions());
            IsWorking = false;
        }

        public void CreateAdoption()
        {
            ActivateItem(new CreateAdoptionViewModel(this));
        }

        public void OpenAdoption()
        {
            if (SelectedAdoption != null)
                ActivateItem(new AdoptionCardViewModel(SelectedAdoption.ID, this));
        }

        public void UpdateAdoptions()
        {
            LoadData();
        }

        public void DeleteAdoption()
        {
            MessageBoxResult result = MessageBox.Show("Opravdu chcete vymazat zvolenou osobu?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                AdoptionModel.MarkAsDeleted((int)SelectedAdoption.ID);
                LoadData();
            }
        }

        public void ExportExcell()
        {
            if (Adoptions != null && Adoptions.Count() != 0)
                DocumentManager.ExportDataExcell(AdoptionInfo.ConvertToList(Adoptions), "Export zvířata");
            else
                MessageBox.Show("Žádná data pro export.");
        }

        public void ExportPDF()
        {
            if (Adoptions != null && Adoptions.Count() != 0)
                DocumentManager.ExportDataPDF(AdoptionInfo.ConvertToList(Adoptions), "Export zvířata");
            else
                MessageBox.Show("Žádná data pro export.");
        }

    }
}

