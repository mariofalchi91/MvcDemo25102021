using MvcDemo.Core.Interfaces;
using MvcDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemo.EntityFramework.Repositories
{
    public class RepositoryEmployeeEF : IRepositoryEmployee
    {
        private readonly EmployeeContext c;
        public RepositoryEmployeeEF(EmployeeContext context)
        {
            c = context;
        }
        public IEnumerable<Employee> Fetch(Func<Employee, bool> filter = null)
        {
            if (filter != null)
                return c.Employees.Where(filter);
            return c.Employees;
        }

        public Employee GetById(int id)
        {
            if (id <= 0)
                return null;
            return c.Employees.Find(id);
        }

        public Employee GetEmployeeByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return null;
            return c.Employees.FirstOrDefault(e => e.EmployeeCode.Equals(code));
        }
    }
}
