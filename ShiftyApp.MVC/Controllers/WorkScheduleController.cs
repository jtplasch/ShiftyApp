using Shifty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShiftyApp.MVC.Controllers
{
    [Authorize]
    public class WorkScheduleController : Controller
    {
        // GET: WorkSchedule
        public ActionResult Index()
        {
            var model = new WorkScheduleListItem[0];
            return View(model);
        }

        //Get: WorkSchedule/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkScheduleCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}