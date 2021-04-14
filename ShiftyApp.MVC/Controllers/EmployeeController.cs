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
            var service = new EmployeeService();
            var model = new EmployeeListItem[0];
            return View(model);
        }

        //GET Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreate model)
        {
            if (!ModelState.IsValid) return View(model);            

            var service = new EmployeeService();

            if (service.CreateEmployee(model))
            {
                TempData["Save Result"] = "Employee was created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Employee couldn't be added.");
           
            return View(model);
        }
            
    }
}