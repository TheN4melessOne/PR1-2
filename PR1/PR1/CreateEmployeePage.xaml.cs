using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace PR1
{
    public partial class CreateEmployeePage : Page
    {
        public CreateEmployeePage()
        {
            InitializeComponent();
            employees = new List<Employee>();
        }

        List<Employee> employees;

        bool correctId, correctFullName, correctPassport,
            correctPhone_num, correctEmail;
        public bool Is_correct_id(string input, List<Employee> employees)
        {
            int id = 1;
            if (int.TryParse(input, out id))
            {
                foreach (Employee employee in employees)
                {
                    if (id == employee.Id)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
        public bool Is_correct_email(string input)
        {
            Regex regex = new Regex(@"^[A-Za-z][A-Za-z0-9_]*@[A-Za-z][A-Za-z0-9_]*\.[A-Za-z][A-Za-z0-9_]*$");
            return regex.IsMatch(input);
        }

        public bool Is_correct_phone_num(string input)
        {
            Regex regex1 = new Regex(@"^8\d{10}$");
            Regex regex2 = new Regex(@"^\+7\d{10}$");
            return regex2.IsMatch(input) || regex1.IsMatch(input);
        }

        public bool Is_correct_passport(string input)
        {
            Regex regex = new Regex(@"^[6][3]\d{2}\s\d{6}$");
            return regex.IsMatch(input);
        }

        public bool Is_correct_full_name(string name, string surname, string patronymic)
        {
            Regex regex = new Regex(@"^[А-Я][а-я]*$");
            return regex.IsMatch(name) && regex.IsMatch(surname) && regex.IsMatch(patronymic);
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {

            correctEmail = Is_correct_email(Email.Text);

            correctPhone_num = Is_correct_phone_num(Phone_num.Text);

            correctPassport = Is_correct_passport(Passport.Text);

            correctFullName = Is_correct_full_name(Name.Text, Surname.Text, Patronymic.Text);

            correctId = Is_correct_id(Id.Text, employees);

            if (correctEmail && correctFullName && correctId && correctPassport && correctPhone_num)
            {
                MessageBox.Show("Корректные данные. Отправка успешна");
                employees.Add(new Employee(int.Parse(Id.Text), Name.Text, Surname.Text,
                    Patronymic.Text, Phone_num.Text, Email.Text, Passport.Text));

                StreamWriter fileOut = new StreamWriter(
                    "F:\\PR1-2\\PR1\\PR1\\employee.txt", false);

                foreach (Employee employee in employees)
                {
                    fileOut.WriteLine($"{employee.Id}\t{employee.Name}\t{employee.Surname}\t" +
                    $"{employee.Patronymic}\t{employee.Passport}\t{employee.Phone_num}\t{employee.Email}");
                }
                fileOut.Close();
            }
            else
            {
                string wrongData = "Отправка отменена. Допущены ошибки в полях:";
                if (correctEmail == false)
                {
                    wrongData += "\nEmail";
                }
                if (correctPhone_num == false)
                {
                    wrongData += "\nМобильный телефон";
                }
                if (correctPassport == false)
                {
                    wrongData += "\nПаспорт";
                }
                if (correctFullName == false)
                {
                    wrongData += "\nФИО";
                }
                if (correctId == false)
                {
                    wrongData += "\nИдентификатор";
                }
                MessageBox.Show(wrongData);
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainFrame.Content 
                = new AuthorizationPage();
        }
    }
}
