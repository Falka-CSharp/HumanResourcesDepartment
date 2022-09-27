using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IDepartments
    {
        IEnumerable<Department> GetAllDepartments(bool includeEmployees = false);
        Department GetDepartmentById(int departmentId, bool includeEmployees = false);
        void SaveDepartment(Department department);
        void DeleteDepartment(Department department);

    }
}
