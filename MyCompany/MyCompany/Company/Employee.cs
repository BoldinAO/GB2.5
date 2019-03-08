using System;

namespace MyCompany.Company
{
    class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; }
        public string Sex { get; set; }

        public Employee(int id, string firstName, string name, string lastName, DateTime birthDate, Department department, string sex)
        {
            Id = id;
            FirstName = firstName;
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Department = department;
            Sex = sex;
        }
    }
}
