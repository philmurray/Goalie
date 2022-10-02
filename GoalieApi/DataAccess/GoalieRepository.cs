using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoalieApi.DataAccess
{
    public interface IGoalieRepository
    {
        bool ValidateUser(string userName, string password);
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

            var user = (from us in db.Users
                        where string.Compare(userName, us.Username, StringComparison.OrdinalIgnoreCase) == 0
                        && string.Compare(password, us.Password, StringComparison.OrdinalIgnoreCase) == 0
                        && us.IsActive == true
                        select us).FirstOrDefault();

            return (user != null) ? true : false;
        }

    }
}