using Shifty.Models;
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
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}