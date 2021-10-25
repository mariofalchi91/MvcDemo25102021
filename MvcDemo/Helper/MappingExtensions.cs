using MvcDemo.Core.Models;
using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDemo.Helper
{
    public static class MappingExtensions
    {
        public static EmployeeViewModel ToViewModel(this Employee employee)
        {
            return new EmployeeViewModel
            {
                EmployeeCode = employee.EmployeeCode,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate
            };
        }

        public static IEnumerable<EmployeeViewModel> ToViewModel(this IEnumerable<Employee> employees)
        {
            return employees.Select(e => e.ToViewModel());
        }
    }
}
