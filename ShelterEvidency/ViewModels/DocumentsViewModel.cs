using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    class DocumentsViewModel: Screen
    {
        #region Initialize

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

        public DocumentsViewModel(int animalID)
        {
            AnimalID = animalID;
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
                Documents = DocumentManager.ReturnAnimalFolder(AnimalID);

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

        private FileInfo[] _documents;
        public FileInfo[] Documents
        {
            get
            {
                return _documents;
            }
            set
            {
                _documents = value;
                NotifyOfPropertyChange(() => Documents);
            }
        }

        private FileInfo _selectedDocument;

        public FileInfo SelectedDocument
        {
            get
            {
                return _selectedDocument;
            }
            set
            {
                _selectedDocument = value;
                NotifyOfPropertyChange(() => SelectedDocument);
                Task.Run(() => Selection());
            }
        }

        private async Task Selection()
        {
            if (SelectedDocument != null)
            {
                IsWorking = true;
                await Task.Delay(150);
                await Task.Run(() =>
                {
                    SelectedDocumentPath = SelectedDocument.FullName;
                });
                IsWorking = false;
            }
            NotifyOfPropertyChange(() => SelectedDocumentPath);
            NotifyOfPropertyChange(() => IsSelected);
        }


        private string _selectedDocumentPath;
        public string SelectedDocumentPath
        {
            get
            {
                return _selectedDocumentPath;
            }
            set
            {
                _selectedDocumentPath = value;
                NotifyOfPropertyChange(() => SelectedDocumentPath);
            }
        }

        public bool IsSelected
        {
            get
            {
                if (SelectedDocument != null)
                    return true;
                else
                    return false;
            }

        }

        public void Open()
        {
            if (IsSelected)
                DocumentManager.OpenDocument(SelectedDocumentPath);
        }

        public void Print()
        {
            if (IsSelected)
                DocumentManager.PrintDocument(SelectedDocumentPath);
        }

        public void Delete()
        {
            if (IsSelected)
            {

                MessageBoxResult result = MessageBox.Show("Opravdu chcete dokument smazat?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DocumentManager.DeleteDocument(SelectedDocumentPath);
                    Task.Run(() => LoadData());
                }
        
            }
        }

        public void LoadNewDocument()
        {
            DocumentManager.LoadNewAnimalDocument(AnimalID);
            Task.Run(() => LoadData());
        }

        public void GenerateEvidencyCard()
        {
            DocumentManager.GenerateAnimalEvidencyCard(AnimalID);
            Task.Run(() => LoadData());
        }

    }
}
