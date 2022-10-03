using GoalieApi.DataAccess;
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


    }
}
