using KimaiHelper.Kimai;
using KimaiHelper.Kimai.Model;
using KimaiHelper.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            comboBoxActivities.DataSource = Activities;
            comboBoxProjects.DataSource = Projects;
        }

        public string ApiUrl { get => propApiUrl; set => SetProperty(ref propApiUrl, value); }
        public string ApiUser { get => propApiUser; set => SetProperty(ref propApiUser, value); }
        public string ApiKey { get => propApiKey; set => SetProperty(ref propApiKey, value); }
        public BindingList<Activity> Activities { get; } = new BindingList<Activity>();
        public BindingList<Project> Projects { get; } = new BindingList<Project>();

        public async Task TestConnection(int timeout = 10000, bool silentError = false)
        {
            ApiClient apiClient = new ApiClient(ApiUrl, ApiUser, ApiKey, timeout);

            buttonTestApi.Enabled = false;
            textBoxApiUrl.Enabled = false;
            textBoxApiUser.Enabled = false;
            textBoxApiKey.Enabled = false;
            comboBoxActivities.Enabled = false;
            comboBoxProjects.Enabled = false;

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

                Activity selectedActivity = comboBoxActivities.SelectedItem as Activity;
                Activities.Clear();
                activities.ForEach(activity => Activities.Add(activity));
                if (selectedActivity != null)
                {
                    if (Activities.Where(activity => activity.Id == selectedActivity.Id).FirstOrDefault() is Activity newActivity)
                    {
                        comboBoxActivities.SelectedItem = newActivity;
                    }
                }
                
                
                Project selectedProject = comboBoxProjects.SelectedItem as Project;
                Projects.Clear();
                projects.ForEach(project => Projects.Add(project));
                if (selectedProject != null)
                {
                    if (Projects.Where(project => project.Id == selectedProject.Id).FirstOrDefault() is Project newProject)
                    {
                        comboBoxProjects.SelectedItem = newProject;
                    }
                }
                
            }
            catch (RequestException e)
            {
                if (!silentError)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            finally
            {
                buttonTestApi.Enabled = true;
                textBoxApiUrl.Enabled = true;
                textBoxApiUser.Enabled = true;
                textBoxApiKey.Enabled = true;
                comboBoxActivities.Enabled = true;
                comboBoxProjects.Enabled = true;
            }
        }

        private void LoadSettings()
        {
            ApiUrl = Settings.Default.ApiUrl;
            ApiUser = Settings.Default.ApiUser;
            ApiKey = Settings.Default.ApiKey;

            Activities.Clear();
            Activities.Add(new Activity(Settings.Default.ActivityId) { Name = Settings.Default.ActivityName });

            Projects.Clear();
            Projects.Add(new Project(Settings.Default.ProjectId) { Name = Settings.Default.ProjectName });

            comboBoxActivities.Enabled = false;
            comboBoxProjects.Enabled = false;
        }

        private void PersistSettings()
        {
            Settings.Default.ApiUrl = ApiUrl;
            Settings.Default.ApiUser = ApiUser;
            Settings.Default.ApiKey = ApiKey;

            if (comboBoxActivities.SelectedItem is Activity activity)
            {
                Settings.Default.ActivityId = activity.Id;
                Settings.Default.ActivityName = activity.Name;
            }

            if (comboBoxProjects.SelectedItem is Project project)
            {
                Settings.Default.ProjectId = project.Id;
                Settings.Default.ProjectName = project.Name;
            }
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

        private async void SettingsForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                LoadSettings();
                await TestConnection(2000, true);
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
