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

namespace PR1
{
    public partial class AuthorizationPage : Page
    {
        AuthorizationEmployee MainEmployee;
        int attemptCount = 0;
        System.Windows.Threading.DispatcherTimer timer;
        public AuthorizationPage()
        {
            InitializeComponent();
            MainEmployee = new AuthorizationEmployee("Nameless", "Nameless");
        }
        private void Send_click(object sender, RoutedEventArgs e)
        {
            if ((Password.Text == MainEmployee.Password) &&
                (Login.Text == MainEmployee.Login))
            {
                MessageBox.Show("Авторизация успешна!");
                ((MainWindow)Application.Current.MainWindow).MainFrame.Content =
                    new CreateEmployeePage();
            }
            else
            {
                if (attemptCount == 2)
                {
                    attemptCount = 0;
                    MessageBox.Show("Превышено количество попыток авторизации!\n" +
                        "Повторите попытку по истечении одной минуты.");

                    Login.IsEnabled = false;
                    Password.IsEnabled = false;
                    Send.IsEnabled = false;

                    timer = new System.Windows.Threading.DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(10);
                    timer.Tick += Timer_Tick;
                    timer.Start();
                }
                else
                {
                    attemptCount++;
                    MessageBox.Show($"Неверный логин или пароль!\n" +
                        $"Осталось попыток: {3 - attemptCount}");
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Login.IsEnabled = true;
            Password.IsEnabled = true;
            Send.IsEnabled = true;
        }
    }
}
