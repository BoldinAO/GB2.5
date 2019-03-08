using System;
using System.Collections;
using System.Collections.Generic;

namespace MyCompany.Company
{
    class Departments : IEnumerable
    {
        //Список департаментов
        public List<Department> Departs { get; }

        public Departments()
        {
            Departs = new List<Department>();
        }

        //Добавить новый департамент
        public void AddDepartment(string department)
        {
            Departs.Add(new Department(department));
            RefreshDepartment(this.Departs);
        }

        //Удалить департамент из списка
        public void DisposeDepartament(Department department)
        {
            if (Departs.Contains(department)) Departs.Remove(department);
            else throw new DepartmentNotExist($"Департамент {department.Name} не существует");
        }

        public static void RefreshDepartment(List<Department> departments)
        {
            foreach (Department department in departments)
            {
                AnyDepartmentDo($"{department.Name}");
            }
        }

        public IEnumerator GetEnumerator()
        {
            return Departs.GetEnumerator();
        }

        private int AddTo(string s)
        {
            return AnyDepartmentDo(s);
        }

        static public event Func<string, int> AnyDepartmentDo;
    }

    class Department
    {
        //Наименование департамента
        public string Name { get; private set; }

        public Department(string depertmentName)
        {
            Name = depertmentName;
        }
    }
}
