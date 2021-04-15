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
    public class WorkScheduleController : Controller
    {
        // GET: WorkSchedule
        public ActionResult Index()
        {
            return View(CreateWorkScheduleService().GetWorkSchedule());
        }

        //Get: WorkSchedule/Create
        public ActionResult Create()
        {
            ViewBag.Title = "New Work Schedule";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkScheduleCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateWorkScheduleService().CreateWorkSchedule(model))
            {
                TempData["Save Result"] = "Schedule was created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Schedule couldn't be added.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var requests = CreateWorkScheduleService().GetWorkScheduleDetailById(id);
            return View(requests);
        }

        public ActionResult Edit(int id)
        {
            var workSchedule = CreateWorkScheduleService().GetWorkScheduleDetailById(id);
            return View(new WorkScheduleEdit
            {
                ScheduledId = workSchedule.ScheduledId,                
                Date = workSchedule.Date,
                EmployeeId = workSchedule.EmployeeId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, WorkScheduleEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ScheduledId != id)
            {
                ModelState.AddModelError("", "Schedule ID Error");
                return View(model);
            }

            if (CreateWorkScheduleService().UpdateWorkSchedule(model))
            {
                TempData["SaveResult"] = "Schedule Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "errorMessage editing Schedule");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateWorkScheduleService();
            var model = svc.GetWorkScheduleDetailById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteWorkSchedule(int id)
        {
            var service = CreateWorkScheduleService();
            service.DeleteWorkSchedule(id);
            TempData["SaveResult"] = "Schedule Deleted";
            return RedirectToAction("Index");
        }

        private WorkScheduleService CreateWorkScheduleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new WorkScheduleService(userId);
            return service;
        }
    }
}