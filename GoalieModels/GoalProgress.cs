using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalieModels
{
    public class GoalProgress
    {
        public int GoalProgressId { get; set; }
        public int GoalId { get; set; }

        public int MinutesOfProgress { get; set; }
        public DateTime ProgressDate { get; set; }
    }
}
