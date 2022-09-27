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
    public class DepartmentsRepo : IDepartments
    {
        private EfDbContext _context;
        public DepartmentsRepo(EfDbContext context)
        {
            _context = context;
        }

        public void DeleteDepartment(Department department)
        {
            _context.Departments.Remove(department);
            _context.SaveChanges();
        }

        public IEnumerable<Department> GetAllDepartments(bool includeEmployees = false)
        {
            if (includeEmployees)
                return _context.Departments.Include(x => x.Employees).AsNoTracking().ToList();
            else
                return _context.Departments.ToList();
        }

        public Department GetDepartmentById(int departmentId, bool includeEmployees = false)
        {
            if (includeEmployees)
                return _context.Departments.Where(d => d.Id == departmentId).Include(d => d.Employees).AsNoTracking()
                    .FirstOrDefault() ?? new Department();
            else
                return _context.Departments.Where(d=>d.Id==departmentId).FirstOrDefault() ?? new Department();
        }

        public void SaveDepartment(Department department)
        {
            if (department.Id == 0)
                _context.Departments.Add(department);
            else
                _context.Entry(department).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
