using Caliburn.Micro;
using ShelterEvidency.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShelterEvidency.Models
{
    public class SexModel
    {
        #region Properties/Atributes
        public int ID { get; set; }
        public string SexName { get; set; }
        #endregion

        public static BindableCollection<Sexes> ReturnSexes()
        {
            try
            {
                using (ShelterDatabaseLINQDataContext db = new ShelterDatabaseLINQDataContext())
                {
                    return new BindableCollection<Sexes>(db.Sexes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new BindableCollection<Sexes>();
            }
        }
    }
}
