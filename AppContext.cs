using KimaiHelper.Forms;
using KimaiHelper.Kimai;
using KimaiHelper.Kimai.Model;
using KimaiHelper.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace KimaiHelper
{
    public enum TimesheetStatus
    {
        Unknown,
        Started,
        StartPending,
        Stopped,
        StopPending
    }

    public class AppContext : ApplicationContext
    {
        private TrayForm trayForm;
        private SettingsForm settingsForm;
        private SummaryForm summaryForm;
        private System.Timers.Timer fetchTimer;

        private ApiClient apiClient;
        private int fetchInterval = 3000;

        public Activity Activity { get; private set; }
        public Project Project { get; private set; }
        public Timesheet ActiveTimesheet { get; private set; }
        public TimesheetStatus TimesheetStatus { get; private set; } = TimesheetStatus.Unknown;

        public event EventHandler TimesheetStatusChanged;

        public AppContext()
        {
            trayForm = new TrayForm(this);
            settingsForm = new SettingsForm(this);
            summaryForm = new SummaryForm(this);

            InitApiClient();
            FetchActiveTimesheet();
        }

        public void InitApiClient()
        {
            string apiUrl = Settings.Default.ApiUrl;
            string apiUser = Settings.Default.ApiUser;
            string apiKey = Settings.Default.ApiKey;

            apiClient = new ApiClient(apiUrl, apiUser, apiKey, 100000);
            fetchTimer = new System.Timers.Timer(fetchInterval);
            fetchTimer.Elapsed += OnFetch;
            fetchTimer.AutoReset = true;
            fetchTimer.Enabled = true;

            Activity = new Activity(Settings.Default.ActivityId) { Name = Settings.Default.ActivityName };
            Project = new Project(Settings.Default.ProjectId) { Name = Settings.Default.ProjectName };
        }

        private async void FetchActiveTimesheet()
        {
            List<Timesheet> activeTimesheets = await apiClient.GetActiveTimesheets();
            ActiveTimesheet = activeTimesheets.Count > 0 ? activeTimesheets[0] : null;
            UpdateTimesheetStatus();
        }

        public async Task StartTimesheet()
        {
            UpdateTimesheetStatus(TimesheetStatus.StartPending);
            FetchActiveTimesheet();
            if (ActiveTimesheet == null)
            {
                ActiveTimesheet = await apiClient.StartTimesheet(Project, Activity);
            }
            UpdateTimesheetStatus();
        }

        public async Task StopActiveTimesheet()
        {
            UpdateTimesheetStatus(TimesheetStatus.StopPending);
            FetchActiveTimesheet();
            if (ActiveTimesheet != null)
            {
                await apiClient.StopTimesheet(ActiveTimesheet);
                ActiveTimesheet = null;
            }
            UpdateTimesheetStatus();
        }

        public async Task ToggleTimesheet()
        {
            if (ActiveTimesheet != null)
            {
                await StopActiveTimesheet();
            }
            else
            {
                await StartTimesheet();
            }
        }

        private void UpdateTimesheetStatus(TimesheetStatus? manualStatus = null)
        {
            TimesheetStatus currentStatus = TimesheetStatus;
            if (manualStatus != null) {
                TimesheetStatus = (TimesheetStatus)manualStatus;
            } else
            {
                TimesheetStatus = ActiveTimesheet != null ? TimesheetStatus.Started : TimesheetStatus.Stopped;
            }
            if (currentStatus != TimesheetStatus)
            {
                InvokeEvent(TimesheetStatusChanged, new EventArgs());
            }
            
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

        protected virtual void InvokeEvent(EventHandler handler, EventArgs args)
        {
            handler?.Invoke(this, args);
        }

        private void OnFetch(Object source, ElapsedEventArgs e)
        {
            FetchActiveTimesheet();
        }

        public void OnExit()
        {
            Settings.Default.Save();
        }
    }
}
