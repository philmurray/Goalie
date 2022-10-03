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

            modelBuilder.Entity<Goal>()
                .HasMany(g => g.GoalProgress);
        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Goal> Goal { get; set; }
        public virtual DbSet<GoalProgress> GoalProgress {get;set; }
    }
}