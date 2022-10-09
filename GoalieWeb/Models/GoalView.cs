using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoalieWeb.Models
{
    public class GoalView
    {
        public int GoalId { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }
        public bool Completed { get; set; }
    }
}