using MvcDemo.Core.Models;
using System;
using System.Collections.Generic;

namespace MvcDemo.Core.Interfaces
{
    public interface IMainBusinessLayer
    {
        IEnumerable<Employee> FetchEmployees(Func<Employee, bool> filter = null);
        Employee GetEmployeeById(int id);
        Employee GetEmployeeByCode(string code);
    }
}
