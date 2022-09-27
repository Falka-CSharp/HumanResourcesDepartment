using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions options)
            : base(options) 
        { }
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Department> Departments => Set<Department>();
    }
    
    public class EfDbContextFactory : IDesignTimeDbContextFactory<EfDbContext>
    {
        public EfDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EfDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HRD_db;Trusted_Connection=True;MultipleActiveResultSets=true;",
                b => b.MigrationsAssembly("DataLayer"));
            return new EfDbContext(optionsBuilder.Options);
        }
    }
}
