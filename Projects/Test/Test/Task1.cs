using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Task1
    {
        class Person
        {
            public string firstName;
            public string lastName;
            public int age;
            public Gender g;
            public enum Gender
            {
                Male,
                Female,
            }
            public Person(string firstName, string lastName, int age)
            {
                this.firstName = firstName;
                this.lastName = lastName;
                this.age = age;
            }
            public Person(string firstName, string lastName, int age, Gender g)
                : this(firstName, lastName, age)
            {
                this.g = g;
            }
            public override string ToString()
            {
                return "Person's name: " + firstName + " " + lastName + ", age: " + age + ", gender: "  + g;
            }
        }
        class Manager : Person
        {
            string phoneNumber;
            string officeLocation;
            public Manager(string firstName, string lastName, int age, Gender g, string phoneNumber, string officeLocation)
                : base(firstName, lastName, age, g)
            {
                this.phoneNumber = phoneNumber;
                this.officeLocation = officeLocation;
            }
            public override string ToString()
            {
                return "Person's name: " + firstName + " " + lastName + ", age: " + age + ", gender: " + g + ", phone number: " + phoneNumber + ", office location: " + officeLocation;
            }
        }
        static void Main(string[] args)
        {
            Manager m = new Manager("Donald", "Duck", 43, Person.Gender.Male, "18418", "qelrngjv");
            Console.WriteLine(m);
            Console.ReadKey();
        }
    }
}
