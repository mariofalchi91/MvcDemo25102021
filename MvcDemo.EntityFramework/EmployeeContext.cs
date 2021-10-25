using Microsoft.EntityFrameworkCore;
using MvcDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemo.EntityFramework
{
    public class EmployeeContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var employeeEntity = builder.Entity<Employee>();
            employeeEntity.HasKey(e => e.Id);
            employeeEntity.Property(e => e.EmployeeCode).IsRequired().HasMaxLength(5);
            employeeEntity.Property(e => e.FirstName).IsRequired().HasMaxLength(40);
            employeeEntity.Property(e => e.LastName).IsRequired().HasMaxLength(40);
            employeeEntity.Property(e => e.BirthDate);
            employeeEntity.HasData(
                    new Employee
                    {
                        Id = 1,
                        FirstName="Mario",
                        LastName="Rossi",
                        EmployeeCode="ABC12",
                        BirthDate=new DateTime(1980,1,1)
                    },
                    new Employee
                    {
                        Id = 2,
                        FirstName = "Matteo",
                        LastName = "Mattei",
                        EmployeeCode="ABC34",
                        BirthDate = new DateTime(1990, 2, 2)
                    }
                );

        }
    }
}
