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
    public class GoalController : ApiController
    {
        private IGoalieRepository goalieRepository;


        public GoalController(IGoalieRepository repository)
        {
            this.goalieRepository = repository;
        }
        
        public IList<Goal> GetByUserId(int id)
        {
            return this.goalieRepository.GetGoals(id);
        }
    }
}
