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
        public readonly IRestClient restClient;

        public ApiClient(string url, string user, string key)
        {
            restClient = new RestClient(url);
            restClient.UseNewtonsoftJson();
            restClient.AddDefaultHeader("X-AUTH-USER", user);
            restClient.AddDefaultHeader("X-AUTH-TOKEN", key);
        }

        public List<Project> GetProjects()
        {
            IRestRequest request = new RestRequest("projects", DataFormat.Json);

            var resp = restClient.Get(request);

            return JsonConvert.DeserializeObject<List<Project>>(resp.Content);
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
    }
}
