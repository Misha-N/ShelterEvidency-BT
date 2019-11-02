using Caliburn.Micro;
using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterEvidency.ViewModels
{
    public class SearchPersonViewModel: Conductor<object>
    {
        private List<Database.People> _people;

        public List<Database.People> People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;
                NotifyOfPropertyChange(() => People);
            }
        }

        public SearchPersonViewModel()
        {
            ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext();
            People = db.People.ToList();

        }

    }
}
