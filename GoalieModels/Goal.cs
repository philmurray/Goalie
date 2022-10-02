using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalieModels
{
    public class Goal
    {
        public int GoalId { get; set; }

        public DateTime Created { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public bool Completed { get; set; }

        public User User { get; set; }
    }
}
