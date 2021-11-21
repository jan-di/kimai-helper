using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KimaiHelper.Kimai;
using KimaiHelper.Properties;

namespace KimaiHelper.Forms
{
    public partial class SettingsForm : Form, INotifyPropertyChanged
    {
        private AppContext appContext;

        private string propApiUrl;
        private string propApiUser;
        private string propApiKey;

        public SettingsForm(AppContext appContext)
        {
            this.appContext = appContext;

            InitializeComponent();

            textBoxApiUrl.DataBindings.Add("Text", this, "ApiUrl");
            textBoxApiUser.DataBindings.Add("Text", this, "ApiUser");
            textBoxApiKey.DataBindings.Add("Text", this, "ApiKey");
        }

        public string ApiUrl { get => propApiUrl; set => SetProperty(ref propApiUrl, value); }
        public string ApiUser { get => propApiUser; set => SetProperty(ref propApiUser, value); }
        public string ApiKey { get => propApiKey; set => SetProperty(ref propApiKey, value); }

        public async Task TestConnection()
        {
            ApiClient apiClient = new ApiClient(ApiUrl, ApiUser, ApiKey);

            buttonTestApi.Enabled = false;

            try
            {
                var serverVersionTask = apiClient.GetServerVersion();
                var projectsTask = apiClient.GetProjects();
                var activitiesTask = apiClient.GetActivities();

                await Task.WhenAll(serverVersionTask, projectsTask, activitiesTask);

                var serverVersion = await serverVersionTask;
                var projects = await projectsTask;
                var activities = await activitiesTask;

                textBoxApiVersion.Text = serverVersion.Semver;
                comboBoxProjects.DataSource = projects;
                comboBoxActivities.DataSource = activities;
            }
            catch (RequestException e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                buttonTestApi.Enabled = true;
            }
        }

        private void LoadSettings()
        {
            ApiUrl = Settings.Default.ApiUrl;
            ApiUser = Settings.Default.ApiUser;
            ApiKey = Settings.Default.ApiKey;
        }

        private void PersistSettings()
        {
            Settings.Default.ApiUrl = ApiUrl;
            Settings.Default.ApiUser = ApiUser;
            Settings.Default.ApiKey = ApiKey;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                PersistSettings();
                appContext.InitApiClient();

                e.Cancel = true;
                Hide();
            }
        }

        private void SettingsForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                LoadSettings();
            }
        }

        private async void buttonTestApi_Click(object sender, EventArgs e)
        {
            await TestConnection();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}
