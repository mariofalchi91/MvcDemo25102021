using Microsoft.AspNetCore.Mvc;
using MvcDemo.Core.Interfaces;
using MvcDemo.Helper;
using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDemo.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IMainBusinessLayer mainBL;
        public EmployeesController(IMainBusinessLayer bL)
        {
            mainBL = bL;
        }
        public IActionResult Index()
        {
            var result = mainBL.FetchEmployees();

            //var resultMapping = new List<EmployeeViewModel>();
            //foreach (var item in result)
            //{
            //    resultMapping.Add(new EmployeeViewModel
            //    {
            //        EmployeeCode = item.EmployeeCode,
            //        FirstName = item.FirstName,
            //        LastName = item.LastName,
            //        BirthDate = item.BirthDate
            //    });
            //}

            var resultMapping = result.ToViewModel();
            return View(resultMapping);
        }

        //GET Employees/Details/[code]
        public IActionResult Detail(string code)
        {
            if (string.IsNullOrEmpty(code))
                return View("NotFound");
            var employee = mainBL.GetEmployeeByCode(code);
            if (employee == null)
                return View("NotFound");
            var resultMapped = employee.ToViewModel();
            return View(resultMapped);
        }
    }
}
