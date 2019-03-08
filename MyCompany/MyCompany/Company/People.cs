using System;
using System.Collections;
using System.Collections.Generic;

namespace MyCompany.Company
{
    class People : IEnumerable
    {
        //Список сотрудников
        public List<Employee> Peoples { get; }

        public People()
        {
            Peoples = new List<Employee>();
        }

        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        /// <param name="firstName">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="lastName">Отчество</param>
        /// <param name="birthDate">Дата рождения</param>
        /// <param name="department">Департамент</param>
        /// <param name="sex">Пол</param>
        public void AddEmployee(int id, string firstName, string name, string lastName, DateTime birthDate, Department department, string sex)
        {
            Peoples.Add(new Employee(id, firstName, name, lastName, birthDate, department, sex));
            Refresh(this.Peoples);
        }

        /// <summary>
        /// Удалить сотрудника
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        public void DisposeEmployee(Employee employee)
        {
            if (Peoples.Contains(employee)) Peoples.Remove(employee);
            else throw new DepartmentNotExist($"Сотрудник {employee.FirstName} {employee.Name} {employee.LastName} не существует");
            Refresh(this.Peoples);
        }


        public void ChangeEmployeeData(int id, params object[] info)
        {
            Peoples[id].FirstName = info[0]?.ToString();
            Peoples[id].Name = info[1]?.ToString();
            Peoples[id].LastName = info[2]?.ToString();
            Peoples[id].BirthDate = DateTime.Parse(info[3].ToString());
            Peoples[id].Department = (Department)info[4];
            Peoples[id].Sex = info[5]?.ToString();
            Refresh(this.Peoples);
        }

        
        public static void Refresh(List<Employee> people)
        {
            foreach (Employee employee in people)
            {
                AnyEmployeeDo($"{employee.FirstName} {employee.Name} {employee.LastName} {employee.Department.Name} {employee.Sex}");
            }
        }

        public IEnumerator GetEnumerator()
        {
            return Peoples.GetEnumerator();
        }

        private int AddTo(string s)
        {
            return AnyEmployeeDo(s);
        }

        static public event Func<string, int> AnyEmployeeDo; 
    }
}
