using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.ViewModels
{
    public class SearchAnimalViewModel: Screen
    {
        private List<Database.Animals> _animals;

        public List<Database.Animals> Animals
        {
            get
            {
                return _animals;
            }
            set
            {
                _animals = value;
                NotifyOfPropertyChange(() => Animals);
            }
        }

        public SearchAnimalViewModel()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            Animals = db.Animals.ToList();

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
                Search();
            }
        }


        public void Search()
        {
            //MessageBox.Show(SearchValue);
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            Animals = db.Animals.Where(x => x.Name.Contains(SearchValue)).ToList();
        }





    }
}
