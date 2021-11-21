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

        public ApiClient(string url, string user, string key)
        {
            SetApi(url, user, key);
        }

        public void SetApi(string url, string user, string key)
        {
            restClient = CreateRestClient(url, user, key);
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
            IRestRequest request = new RestRequest("projects", Method.GET, DataFormat.Json);

            IRestResponse response = await restClient.ExecuteAsync(request);
            HandleResponseErrors(response);

            return JsonConvert.DeserializeObject<List<Project>>(response.Content);
        }

        public async Task<List<Activity>> GetActivities()
        {
            IRestRequest request = new RestRequest("activities", Method.GET, DataFormat.Json);

            IRestResponse response = await restClient.ExecuteAsync(request);
            HandleResponseErrors(response);

            return JsonConvert.DeserializeObject<List<Activity>>(response.Content);
        }

        public List<Timesheet> GetActiveTimesheets()
        {
            IRestRequest request = new RestRequest("timesheets/active", DataFormat.Json);

            var resp = restClient.Get(request);

            return JsonConvert.DeserializeObject<List<Timesheet>>(resp.Content);
        }

        public void StartTimesheet(Project project, Activity activity, DateTime? begin = null)
        {
            begin = begin ?? DateTime.Now;

            IRestRequest request = new RestRequest("timesheets", DataFormat.Json)
            .AddJsonBody(new
            {
                begin = begin,
                project = project.Id,
                activity = activity.Id
            });

            restClient.Post(request);
        }

        public void StopTimesheet(Timesheet timesheet)
        {
            IRestRequest request = new RestRequest("timesheets/{id}/stop", DataFormat.Json)
                .AddUrlSegment("id", timesheet.Id);

            restClient.Patch(request);
        }

        private IRestClient CreateRestClient(string url, string user, string key)
        {
            IRestClient restClient = new RestClient(url);
            restClient.UseNewtonsoftJson();
            restClient.AddDefaultHeader("X-AUTH-USER", user);
            restClient.AddDefaultHeader("X-AUTH-TOKEN", key);
            restClient.Timeout = 10000;

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
