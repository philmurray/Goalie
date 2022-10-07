using GoalieWeb.CustomAuthentication;
using GoalieWeb.Models;
using GoalieWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoalieWeb.Controllers
{
    [CustomAuthorize]
    public class HomeController : Controller
    {
        private IGoalieApiService _service;

        public HomeController(IGoalieApiService goalieService)
        {
            _service = goalieService;
        }

        public ActionResult Index()
        {
            CustomPrincipal user = (CustomPrincipal)User;

            HomeView model = new HomeView
            {
                Goals = _service.GetGoalsByUserId(user.UserId)
            };

            return View(model);
        }
    }
}