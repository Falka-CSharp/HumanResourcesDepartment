using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    internal interface IEmployees
    {
        IEnumerable<Employee> GetAllEmployees(bool includeDepartments = false);
        Employee GetEmployeeById(int employeeId, bool includeDepartments = false);
        void SaveEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
