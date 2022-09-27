using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class EmployeesRepo : IEmployees
    {
        private EfDbContext _context;
        public EmployeesRepo(EfDbContext context)
        {
            _context = context;
        }
        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public IEnumerable<Employee> GetAllEmployees(bool includeDepartments = false)
        {
            if (includeDepartments)
                return _context.Employees.Include(e => e.Department).AsNoTracking().ToList();
            else
                return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int employeeId, bool includeDepartments = false)
        {
            if (includeDepartments)
                return _context.Employees.Include(e => e.DepartmentId).AsNoTracking()
                    .FirstOrDefault(e => e.Id == employeeId) ?? new Employee();
            else
                return _context.Employees.FirstOrDefault(e => e.Id == employeeId) ?? new Employee();
        }

        public void SaveEmployee(Employee employee)
        {
            if (employee.Id == 0)
                _context.Employees.Add(employee);
            else
                _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
