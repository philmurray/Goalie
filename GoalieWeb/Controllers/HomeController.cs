using GoalieModels;
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

        public ActionResult AddGoal()
        {
            return PartialView("_EditGoal", new GoalView());
        }
        public ActionResult EditGoal(int goalId)
        {
            var goal = _service.GetGoal(goalId);
            var model = new GoalView
            {
                GoalId = goal.GoalId,
                Title = goal.Title,
                Details = goal.Details,
                Completed = goal.Completed
            };
            return PartialView("_EditGoal", model);
        }
        public ActionResult CompleteGoal(int goalId)
        {
            var goal = _service.GetGoal(goalId);
            var model = new GoalView
            {
                GoalId = goal.GoalId,
                Title = goal.Title,
                Details = goal.Details,
                Completed = goal.Completed
            };
            return PartialView("_CompleteGoal", model);
        }
        public ActionResult AddOrUpdateGoal (GoalView goal)
        {
            Goal g = new Goal
            {
                GoalId = goal.GoalId,
                Title = goal.Title,
                Details = goal.Details,
                Completed = goal.Completed
            };
            if (goal.GoalId == 0)
            {
                CustomPrincipal user = (CustomPrincipal)User;
                g.UserId = user.UserId;
            }
            _service.UpdateGoal(g);

            return RedirectToAction("Index", "Home");
        }
    }
}