using KimaiHelper.Forms;
using KimaiHelper.Kimai;
using KimaiHelper.Kimai.Model;
using KimaiHelper.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KimaiHelper
{
    public class AppContext : ApplicationContext
    {
        private TrayForm trayForm;
        private SettingsForm settingsForm;
        private SummaryForm summaryForm;
        private ApiClient apiClient;

        public ServerVersion ServerVersion { get; private set; }
        public List<Project> Projects { get; private set; }
        public List<Activity> Activities { get; private set; }

        public AppContext()
        {
            trayForm = new TrayForm(this);
            settingsForm = new SettingsForm(this);
            summaryForm = new SummaryForm(this);

            InitApiClient();
        }

        public void InitApiClient()
        {
            string apiUrl = Settings.Default.ApiUrl;
            string apiUser = Settings.Default.ApiUser;
            string apiKey = Settings.Default.ApiKey;

            apiClient = new ApiClient(apiUrl, apiUser, apiKey, 100000);
        }

        public void ShowSummaryForm()
        {
            summaryForm.Show();
            summaryForm.Activate();
        }

        public void ShowSettingsForm()
        {
            settingsForm.Show();
            settingsForm.Activate();
        }

        public void Exit()
        {
            settingsForm.Close();
            summaryForm.Close();
            trayForm.Close();

            ExitThread();
        }

        public void OnExit()
        {
            Settings.Default.Save();
        }
    }
}
