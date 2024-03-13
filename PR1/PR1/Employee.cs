using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR1
{
    public class Employee
    {
        int id;
        string name;
        string surname;
        string patronymic;
        string phone_num;
        string email;
        string passport;
        public Employee()
        {

        }

        public Employee(int id,
        string name, string surname, string patronymic,
        string phone_num, string email, string passport)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.patronymic = patronymic;
            this.phone_num = phone_num;
            this.email = email;
            this.passport = passport;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }
        public string Phone_num
        {
            get { return phone_num; }
            set { phone_num = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Passport
        {
            get { return passport; }
            set { passport = value; }
        }
    }
}
