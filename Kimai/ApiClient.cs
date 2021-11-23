using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Serializers.NewtonsoftJson;
using KimaiHelper.Kimai.Model;
using Newtonsoft.Json;

namespace KimaiHelper.Kimai
{
    internal class ApiClient
    {
        public IRestClient restClient;

        public ApiClient(string url, string user, string key, int timeout)
        {
            restClient = CreateRestClient(url, user, key, timeout);
        }

        public async Task<ServerVersion> GetServerVersion()
        {
            IRestRequest request = new RestRequest("version", Method.GET, DataFormat.Json);

            IRestResponse response = await restClient.ExecuteAsync(request);
            HandleResponseErrors(response);

            return JsonConvert.DeserializeObject<ServerVersion>(response.Content);
        }

        public async Task<List<Project>> GetProjects()
        {
            IRestRequest request = new RestRequest("projects");
            return await SendRequestWithResponse<List<Project>>(request);
        }

        public async Task<List<Activity>> GetActivities()
        {
            IRestRequest request = new RestRequest("activities");
            return await SendRequestWithResponse<List<Activity>>(request);
        }

        public async Task<List<Timesheet>> GetActiveTimesheets()
        {
            IRestRequest request = new RestRequest("timesheets/active");
            return await SendRequestWithResponse<List<Timesheet>>(request);
        }

        public async Task<Timesheet> StartTimesheet(Project project, Activity activity)
        {
            IRestRequest request = new RestRequest("timesheets", Method.POST)
            .AddJsonBody(new
            {
                begin = DateTime.Now,
                project = project.Id,
                activity = activity.Id
            });

            return await SendRequestWithResponse<Timesheet>(request);
        }

        public async Task<Timesheet> StopTimesheet(Timesheet timesheet)
        {
            IRestRequest request = new RestRequest("timesheets/{id}/stop", Method.PATCH)
                .AddUrlSegment("id", timesheet.Id);

            return await SendRequestWithResponse<Timesheet>(request);
        }

        private async Task<T> SendRequestWithResponse<T>(IRestRequest request) 
        {
            IRestResponse response = await restClient.ExecuteAsync(request);
            HandleResponseErrors(response);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        private IRestClient CreateRestClient(string url, string user, string key, int timeout)
        {
            IRestClient restClient = new RestClient(url);
            restClient.UseNewtonsoftJson();
            restClient.AddDefaultHeader("X-AUTH-USER", user);
            restClient.AddDefaultHeader("X-AUTH-TOKEN", key);
            restClient.Timeout = timeout;

            return restClient;
        }

        private void HandleResponseErrors(IRestResponse response)
        {
            switch (response.ResponseStatus)
            {
                case ResponseStatus.None:
                    break;
                case ResponseStatus.Error:
                    throw new RequestException(response.ErrorMessage);
                case ResponseStatus.TimedOut:
                    throw new RequestException("Request has timed out!");
                case ResponseStatus.Aborted:
                    throw new RequestException("Request was aborted!");
                case ResponseStatus.Completed:
                    int statusCode = (int)response.StatusCode;

                    if (statusCode > 400)
                    {
                        Error error = JsonConvert.DeserializeObject<Error>(response.Content);
                        string message = $"{statusCode} {response.StatusCode}{Environment.NewLine}{Environment.NewLine}{error.Message}";
                        throw new RequestException(message);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
