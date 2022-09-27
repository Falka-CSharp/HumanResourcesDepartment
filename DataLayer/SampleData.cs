using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal class SampleData
    {
        public static void InitData(EfDbContext context)
        {
            if (!context.Departments.Any())
            {
                context.Departments.Add(new Department()
                {
                    Name = "Developers department"
                });
                context.Departments.Add(new Department()
                {
                    Name = "Designers department"
                });
                context.SaveChanges();

                if (!context.Employees.Any())
                {
                    context.Employees.Add(new Employee()
                    {
                        Name="Vladyslav",
                        Position= "Senior  ASP.NET developer",
                        DepartmentId = context.Departments.Where(d => d.Name == "Developers department")?.FirstOrDefault()?.Id ?? 0
                    });

                    context.Employees.Add(new Employee()
                    {
                        Name = "Anna",
                        Position = "Designer",
                        DepartmentId = context.Departments.Where(d => d.Name == "Designers department")?.FirstOrDefault()?.Id ?? 0
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
