using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            SplashScreen splashScreen = new SplashScreen("LoadingScreen.png");
            splashScreen.Show(true);

            Initialize();
            LoadDatabase();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            DisplayRootViewFor<HomeViewModel>();
        }

        private void LoadDatabase()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
            {
                db.Animals.FirstOrDefault();
                db.People.FirstOrDefault();
                db.Breeds.FirstOrDefault();
                db.CoatTypes.FirstOrDefault();
                db.FurColors.FirstOrDefault();
                db.Sexes.FirstOrDefault();
                db.Species.FirstOrDefault();
            }

            // první query bývá pomalá, načítají se metadata a query plány?
        }
    }
}
