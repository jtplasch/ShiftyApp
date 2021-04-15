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
    public class RequestsController : Controller
    {        
        // GET: Requests
        public ActionResult Index()
        {
            return View(CreateRequestsService().GetRequests());
        }

        //GET Requests/Create
        public ActionResult Create()
        {
            ViewBag.Title = "New Request";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RequestsCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateRequestsService().CreateRequests(model))
            {
                TempData["Save Result"] = "Request was created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Request couldn't be added.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var requests = CreateRequestsService().GetRequestsDetailById(id);
            return View(requests);
        }

        public ActionResult Edit(int id)
        {
            var requests = CreateRequestsService().GetRequestsDetailById(id);
            return View(new RequestsEdit {             
                RequestId = requests.RequestId,                
                TypeOfRequest = requests.TypeOfRequest,
                Reason = requests.Reason,
                Date = requests.Date,
                EmployeeId = requests.EmployeeId,
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RequestsEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RequestId != id)
            {
                ModelState.AddModelError("", "Request ID Error");
                return View(model);
            }

            if (CreateRequestsService().UpdateRequests(model))
            {
                TempData["SaveResult"] = "Request Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "errorMessage editing Request");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRequestsService();
            var model = svc.GetRequestsDetailById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRequest(int id)
        {
            var service = CreateRequestsService();
            service.DeleteRequests(id);
            TempData["SaveResult"] = "Request Deleted";
            return RedirectToAction("Index");
        }
        private RequestsService CreateRequestsService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RequestsService(userId);
            return service;
        }

    }
}