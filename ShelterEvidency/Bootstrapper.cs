using Caliburn.Micro;
using ShelterEvidency.Database;
using ShelterEvidency.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            SplashScreen splashScreen = new SplashScreen("LoadingScreen.png");
            splashScreen.Show(true);

            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            

            string cesta = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\Database\\ShelterDatabase.mdf";

            LoadDatabase();

            DisplayRootViewFor<HomeViewModel>();
        }

        private void LoadDatabase()
        {
            using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext(ConfigurationManager.ConnectionStrings["ShelterEvidency.Properties.Settings.ShelterDatabaseConnectionString"].ConnectionString))
            {
                db.Animals.FirstOrDefault();
                db.People.FirstOrDefault();
                db.Breeds.FirstOrDefault();
                db.CoatTypes.FirstOrDefault();
                db.FurColors.FirstOrDefault();
                db.Sexes.FirstOrDefault();
                db.Species.FirstOrDefault();
                db.DiaryRecords.FirstOrDefault();
                db.Images.FirstOrDefault();
                db.Adoptions.FirstOrDefault();
            }

            // první query bývá pomalá, načítají se metadata a query plány?
        }
    }
}
