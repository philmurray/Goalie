using GoalieApi.DataAccess;
using GoalieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoalieApi.Controllers
{
    public class UserController : ApiController
    {
        private IGoalieRepository goalieRepository;

        public UserController(IGoalieRepository repository)
        {
            this.goalieRepository = repository;
        }

        [HttpGet]
        public bool ValidateUser(string userName, string password)
        {
            return this.goalieRepository.ValidateUser(userName, password);
        }

        public User GetUser(string username)
        {
            return this.goalieRepository.GetUser(username);
        }

        public string GetUserNameByEmail(string email)
        {
            return this.goalieRepository.GetUserNameByEmail(email);
        }

    }
}
