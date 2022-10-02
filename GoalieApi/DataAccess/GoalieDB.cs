using GoalieModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoalieApi.DataAccess
{
    public class GoalieDb : DbContext
    {
        public GoalieDb()
            : base("GoalieDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goal>()
                .HasRequired(g => g.User);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Goal> Goals { get; set; }
    }
}