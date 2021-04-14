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
            var service = new RequestsService();
            var model = new RequestsListItem[0];
            return View(model);
        }

        //GET Requests/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RequestsCreate model)
        {
            if (!ModelState.IsValid) return View(model);
                        
            var service = new RequestsService();

            if (service.CreateRequests(model))
            {
                TempData["Save Result"] = "Request was created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Request couldn't be added.");

            return View(model);
            
        }
    }
}