using Microsoft.AspNet.Identity;
using Shifty.Models;
using Shifty.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShiftyApp.MVC.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View(CreateEmployeeService().GetEmployees());
        }

        //GET Employee/Create
        public ActionResult Create()
        {
            ViewBag.Title = "New Employee";
            return View();
        }

        //POST Employee Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreate model)
        {
            if (!ModelState.IsValid) return View(model);                       

            if (CreateEmployeeService().CreateEmployee(model))
            {
                TempData["Save Result"] = "Employee was created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Employee couldn't be added.");
           
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var employee = CreateEmployeeService().GetEmployeeDetailById(id);
            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            var employee = CreateEmployeeService().GetEmployeeDetailById(id);
            return View(new EmployeeEdit
            {
                EmployeeId = employee.EmployeeId,
                FullName = employee.FullName,
                Position = employee.Position                
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.EmployeeId != id)
            {
                ModelState.AddModelError("", "Employee ID Error");
                return View(model);
            }

            if (CreateEmployeeService().UpdateEmployee(model))
            {
                TempData["SaveResult"] = "Employee Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "errorMessage editing Employee");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeDetailById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEmployee(int id)
        {
            var service = CreateEmployeeService();
            service.DeleteEmployee(id);
            TempData["SaveResult"] = "Employee Deleted";
            return RedirectToAction("Index");
        }



        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);
            return service;
        }

    }
}