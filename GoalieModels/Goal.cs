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
        public int UserId { get; set; }

        public string Title { get; set; }
        public string Details { get; set; }
        public bool Completed { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<GoalProgress> GoalProgress { get; set; }
    }
}
