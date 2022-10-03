using GoalieModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GoalieWeb.Services
{
    public interface IGoalieApiService
    {
        bool ValidateUser(string userName, string password);
        User GetUser(string username);
        string GetUserNameByEmail(string email);

        IList<Goal> GetGoalsByUserId(int id);
    }

    public class GoalieApiService : IGoalieApiService
    {
        private static HttpClient _httpClient;
        private static HttpClient HttpClient {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient();
                    _httpClient.BaseAddress = new Uri( ConfigurationManager.AppSettings["GoalieApiUrl"] );
                }
                return _httpClient;
            }
        }


        public IList<Goal> GetGoalsByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUser(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}