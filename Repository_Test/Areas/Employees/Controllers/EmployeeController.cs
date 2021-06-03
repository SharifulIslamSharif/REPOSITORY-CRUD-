using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository_Test.Areas.Employees.Models;
using Repository_Test.Areas.Employees.Models.ViewModels;
using Repository_Test.Service.Interface;

namespace Repository_Test.Areas.Employees.Controllers
{
    [Area("Employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployee employee;

        public EmployeeController(IEmployee employee)
        {
            this.employee = employee;
        }

        // GET: 
        public async Task<IActionResult> Index()
        {
            EmployeeViewModels model = new EmployeeViewModels
            {
                employees = await employee.GetEmployee(),
            };


            return View(model);
        }

        // POST: Degree/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] EmployeeViewModels model)
        {
            ////return Json(model);
            //if (!ModelState.IsValid)
            //{
            //    model.employees = await employee.GetEmployee();
            //    return View(model);
            //}

            Employee data = new Employee
            {
                EmpId = model.EmpId,
                EmpName = model.EmpName,
                EmpDesignation = model.EmpDesignation,
                EmpSalary = model.EmpSalary,
            };

            await employee.SaveEmployee(data);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<JsonResult> DeleteEmployeeById(int Id)
        {
            await employee.DeleteEmployeeById(Id);
            return Json(true);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            await employee.DeleteEmployeeById(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}