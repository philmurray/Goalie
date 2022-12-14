using GoalieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoalieApi.DataAccess
{
    public interface IGoalieRepository
    {
        bool ValidateUser(string userName, string password);
        User GetUser(string username);
        string GetUserNameByEmail(string email);
        IList<Goal> GetGoals(int userId, bool includeCompleted = false);
        Goal GetGoal(int goalId);
        void UpdateGoal(Goal goal);
    }

    public class GoalieRepository : IGoalieRepository
    {
        private GoalieDb db = new GoalieDb();

        public bool ValidateUser(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            var user = (from us in db.User
                        where string.Compare(userName, us.Username, StringComparison.OrdinalIgnoreCase) == 0
                        && string.Compare(password, us.Password, StringComparison.OrdinalIgnoreCase) == 0
                        && us.IsActive == true
                        select us).FirstOrDefault();

            return (user != null) ? true : false;
        }
        
        public User GetUser(string username)
        {
            var user = (from us in db.User
                        where string.Compare(username, us.Username, StringComparison.OrdinalIgnoreCase) == 0
                        select us).FirstOrDefault();

            return user;
        }

        public string GetUserNameByEmail(string email)
        {
            string username = (from u in db.User
                                where string.Compare(email, u.Email) == 0
                                select u.Username).FirstOrDefault();

            return !string.IsNullOrEmpty(username) ? username : string.Empty;
        }

        public IList<Goal> GetGoals(int userId, bool includeCompleted = false)
        {
            var goals = from g in db.Goal
                        where g.User.UserId == userId && (!g.Completed || includeCompleted)
                        select g;

            return goals.ToList();
        }

        public Goal GetGoal(int goalId)
        {
            var goal = from g in db.Goal where g.GoalId == goalId select g;
            return goal.FirstOrDefault();
        }

        public void UpdateGoal(Goal goal)
        {
            var existingGoal = GetGoal(goal.GoalId);
            if (existingGoal == null)
            {
                goal.CreatedDate = DateTime.Now;
                db.Goal.Add(goal);
            }
            else
            {
                if (goal.Completed && !existingGoal.Completed)
                {
                    existingGoal.CompletedDate = DateTime.Now;
                }
                existingGoal.Details = goal.Details;
                existingGoal.Title = goal.Title;
                existingGoal.Completed = goal.Completed;
            }
            db.SaveChanges();
        }
    }
}