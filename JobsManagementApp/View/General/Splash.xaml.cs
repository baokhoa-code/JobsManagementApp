using JobsManagementApp.View.Admin;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace JobsManagementApp.View.General
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        DispatcherTimer dT = new DispatcherTimer();
        public Splash()
        {
            InitializeComponent();
            dT.Tick += new EventHandler(dt_Tick);
            dT.Interval = new TimeSpan(0, 0, 4);
            dT.Start();
        }

        private void dt_Tick(object sender, EventArgs e)
        {
            LoginWindow db = new LoginWindow();
            db.Show();
            dT.Stop();
            this.Close();
        }
    }
}
