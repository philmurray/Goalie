using GoalieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoalieWeb.Models
{
    public class HomeView
    {
        public IList<Goal> Goals { get; set; }
    }
}