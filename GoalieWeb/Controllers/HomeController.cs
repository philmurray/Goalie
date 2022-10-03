using GoalieWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoalieWeb.Controllers
{
    public class HomeController : Controller
    {
        private IGoalieApiService _service;

        public HomeController(IGoalieApiService goalieService)
        {
            _service = goalieService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}