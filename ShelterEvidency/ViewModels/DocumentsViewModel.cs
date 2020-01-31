using Caliburn.Micro;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    class DocumentsViewModel: Screen
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

        public DocumentsViewModel(int animalID)
        {
            AnimalID = animalID;
        }

        public FileInfo[] Documents
        {
            get
            {
                return DocumentManager.ReturnAnimalFolder(AnimalID);
            }

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

        public void Open()
        {
            if (SelectedDocumentPath != null)
                DocumentManager.OpenDocument(SelectedDocumentPath);
        }

        public void Print()
        {
            if (SelectedDocumentPath != null)
                DocumentManager.PrintDocument(SelectedDocumentPath);
        }

        public void LoadNewDocument()
        {
            DocumentManager.LoadNewAnimalDocument(AnimalID);
            NotifyOfPropertyChange(() => Documents);
        }

        public void GenerateEvidencyCard()
        {
            DocumentManager.GenerateAnimalEvidencyCard(AnimalID);
            NotifyOfPropertyChange(() => Documents);
        }

    }
}
