using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShelterEvidency.Views
{
    /// <summary>
    /// Interakční logika pro StaysView.xaml
    /// </summary>
    public partial class StaysView : UserControl
    {
        public StaysView()
        {
            InitializeComponent();
        }

        private void DataGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as DataGrid).SelectedItem = null;
        }
    }
}
