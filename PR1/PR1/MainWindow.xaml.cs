using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Threading;

namespace PR1
{
    public partial class MainWindow : Window
    {
        AuthorizationPage authorizationPage;
        CreateEmployeePage createEmployeePage;
        DispatcherTimer ifInactive;
        public MainWindow()
        {
            InitializeComponent();

            authorizationPage = new AuthorizationPage();
            MainFrame.Content = authorizationPage;

            ifInactive = new DispatcherTimer();
            ifInactive.Interval = TimeSpan.FromSeconds(10);
            ifInactive.Tick += IfInactive_Tick;
            ifInactive.Start();

        }

        private void IfInactive_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение не используется более 10 секунд.\n");
            ifInactive.Stop();
        }

        private void Grid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            ifInactive.Interval = TimeSpan.FromSeconds(10);
            ifInactive.Start();
        }

    }
}
