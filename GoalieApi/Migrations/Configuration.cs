namespace GoalieApi.Migrations
{
    using GoalieModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GoalieApi.DataAccess.GoalieDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GoalieApi.DataAccess.GoalieDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var u = new GoalieModels.User
            {
                Username = "pmurray",
                FirstName = "Phil",
                LastName = "Murray",
                Email = "test@example.com",
                IsActive = true,
                Password = "password"
            };

            context.User.AddOrUpdate(u);

            context.Goal.AddOrUpdate(new GoalieModels.Goal
            {
                Title = "Some Goal",
                Details = "Some Details about the goal",
                Completed = false,
                CreatedDate = new DateTime(2022, 9, 1),
                User = u,
                GoalProgress = new List<GoalProgress> {
                    new GoalProgress { MinutesOfProgress = 12, ProgressDate = new DateTime (2022, 10, 1) },
                    new GoalProgress { MinutesOfProgress = 56, ProgressDate = new DateTime (2022, 10, 2) },
                    new GoalProgress { MinutesOfProgress = 60, ProgressDate = new DateTime (2022, 10, 3) },
                    new GoalProgress { MinutesOfProgress = 3, ProgressDate = new DateTime (2022, 10, 4) }
                }
            });
            context.Goal.AddOrUpdate(new GoalieModels.Goal
            {
                Title = "Some Other Goal",
                Details = "Some Other Details about the goal",
                Completed = false,
                CreatedDate = new DateTime(2022, 9, 2),
                User = u,
                GoalProgress = new List<GoalProgress> {
                    new GoalProgress { MinutesOfProgress = 45, ProgressDate = new DateTime (2022, 9, 7) },
                    new GoalProgress { MinutesOfProgress = 30, ProgressDate = new DateTime (2022, 9, 7) },
                    new GoalProgress { MinutesOfProgress = 15, ProgressDate = new DateTime (2022, 9, 9) },
                    new GoalProgress { MinutesOfProgress = 10, ProgressDate = new DateTime (2022, 9, 13) }
                }
            });
            context.Goal.AddOrUpdate(new GoalieModels.Goal
            {
                Title = "Some Goal without progress",
                Details = "Some Other Details about the goal without progress",
                Completed = false,
                CreatedDate = new DateTime(2022, 9, 3),
                User = u
            });
            context.Goal.AddOrUpdate(new GoalieModels.Goal
            {
                Title = "Some Completed Goal",
                Details = "Some Details about the completed goal",
                Completed = true,
                CreatedDate = new DateTime(2022, 9, 15),
                CompletedDate = new DateTime(2022, 10, 2),
                User = u,
                GoalProgress = new List<GoalProgress> {
                    new GoalProgress { MinutesOfProgress = 99, ProgressDate = new DateTime (2022, 9, 20) },
                    new GoalProgress { MinutesOfProgress = 88, ProgressDate = new DateTime (2022, 10, 2) }
                }
            });

            context.SaveChanges();
        }
    }
}
