using GoalieModels;
using log4net;
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
        Goal GetGoal(int goalId);
        void UpdateGoal(Goal goal);
    }

    public class GoalieApiService : IGoalieApiService
    {
        protected static readonly ILog _log = LogManager.GetLogger(typeof(GoalieApiService));

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
            try
            {
                var responseTask = HttpClient.GetAsync($"Goal/GetByUserId?id={id}");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Goal>>();
                    readTask.Wait();

                    return readTask.Result;
                }
                else
                {
                    throw new Exception($"Got status code {result.StatusCode} from call to GetGoalsByUserId.  {result.ReasonPhrase}");
                }
            }
            catch (Exception e)
            {
                _log.Error(e);
                throw new Exception("Call to api failed");
            }
        }
        public Goal GetGoal(int goalId)
        {
            try
            {
                var responseTask = HttpClient.GetAsync($"Goal/GetByGoalId?id={goalId}");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Goal>();
                    readTask.Wait();

                    return readTask.Result;
                }
                else
                {
                    throw new Exception($"Got status code {result.StatusCode} from call to GetByGoalId.  {result.ReasonPhrase}");
                }
            }
            catch (Exception e)
            {
                _log.Error(e);
                throw new Exception("Call to api failed");
            }
        }

        public void UpdateGoal(Goal goal)
        {
            try
            {
                var responseTask = HttpClient.PostAsJsonAsync<Goal>("Goal/Update", goal);
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception($"Got status code {result.StatusCode} from call to Update.  {result.ReasonPhrase}");
                }
            }
            catch (Exception e)
            {
                _log.Error(e);
                throw new Exception("Call to api failed");
            }
        }

        public User GetUser(string username)
        {
            try
            {
                var responseTask = HttpClient.GetAsync($"User/GetUser?username={username}");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<User>();
                    readTask.Wait();

                    return readTask.Result;
                }
                else
                {
                    throw new Exception($"Got status code {result.StatusCode} from call to GetUser.  {result.ReasonPhrase}");
                }
            }
            catch (Exception e)
            {
                _log.Error(e);
                throw new Exception("Call to api failed");
            }
        }

        public string GetUserNameByEmail(string email)
        {
            string userName = "";

            try
            {
                var responseTask = HttpClient.GetAsync($"User/GetUserNameByEmail?email={email}");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    userName = readTask.Result;
                }
                else
                {
                    throw new Exception($"Got status code {result.StatusCode} from call to GetUserNameByEmail.  {result.ReasonPhrase}");
                }
            }
            catch (Exception e)
            {
                _log.Error(e);
                throw new Exception("Call to api failed");
            }
            return userName;
        }

        public bool ValidateUser(string userName, string password)
        {
            bool validated = false;

            try
            {
                var responseTask = HttpClient.GetAsync($"User/ValidateUser?userName={userName}&password={password}");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    validated = bool.Parse(readTask.Result);
                }
                else
                {
                    throw new Exception($"Got status code {result.StatusCode} from call to ValidateUser.  {result.ReasonPhrase}");
                }
            }
            catch (Exception e)
            {
                _log.Error(e);
                throw new Exception("Call to api failed");
            }
            return validated;
        }
    }
}