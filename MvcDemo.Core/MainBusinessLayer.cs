using MvcDemo.Core.Interfaces;
using MvcDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcDemo.Core
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        private readonly IRepositoryEmployee repoEmp;
        public MainBusinessLayer(IRepositoryEmployee repositoryEmployee)
        {
            repoEmp = repositoryEmployee;
        }
        public IEnumerable<Employee> FetchEmployees(Func<Employee, bool> filter = null)
        {
            return repoEmp.Fetch(filter);
        }

        public Employee GetEmployeeByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return null;
            return repoEmp.GetEmployeeByCode(code);
        }

        public Employee GetEmployeeById(int id)
        {
            if (id <= 0)
                return null;
            return repoEmp.GetById(id);
        }
    }
}
