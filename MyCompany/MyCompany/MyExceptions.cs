using System;

namespace MyCompany
{
    class DepartmentNotExist : Exception
    {
        public DepartmentNotExist(string mes) : base(mes) { }
    }
}
