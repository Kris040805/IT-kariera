using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personValidation
{
    class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private double salary;

        private Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Person(string firstName, string lastName, int age)
            : this(firstName, lastName)
        {
            this.Age = age;
        }

        public Person(string firstName, string lastName, int age, double salary)
            : this(firstName, lastName, age)
        {
            this.Salary = salary;
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot be less than 3 symbols.");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot be less than 3 symbols.");
                }
                lastName = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age can not be zero or negative integer.");
                }
                age = value;
            }
        }

        public double Salary
        {
            get { return salary; }
            set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary can not be less than 460 leva.");
                }
                salary = value;
            }
        }

        public void IncreaseSalary(double bonus)
        {
            if (this.age > 30)
            {
                this.salary += this.salary * bonus / 100;
            }
            else
            {
                this.salary += this.salary * bonus / 200;
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} get {this.salary:F2} leva.";
        }
    }
}
