using KimaiHelper.Kimai;
using KimaiHelper.Kimai.Model;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KimaiHelper
{
    public partial class FormMain : Form
    {
        private ApiClient client;
        private Timesheet activeTimesheet;

        public FormMain()
        {
            InitializeComponent();

            UpdateForm();

            string apiUrl = Properties.Settings.Default.ApiUrl;
            string apiUser = Properties.Settings.Default.ApiUser;
            string apiKey = Properties.Settings.Default.ApiKey;

            client = new ApiClient(apiUrl, apiUser, apiKey, 10000);

            this.WindowState = FormWindowState.Minimized;
        }

        private void FetchActiveTimesheet()
        {
            List<Timesheet> activeTimesheets = client.GetActiveTimesheets();
            activeTimesheet = activeTimesheets.Count > 0 ? activeTimesheets[0] : null;

            UpdateForm();
        }

        private void StartTimesheet(Project project, Activity activity)
        {
            FetchActiveTimesheet();
            if (activeTimesheet == null)
            {
                client.StartTimesheet(project, activity);
            }
            FetchActiveTimesheet();
            UpdateForm();
        }

        private void StopActiveTimesheet()
        {
            FetchActiveTimesheet();
            if (activeTimesheet != null)
            {
                client.StopTimesheet(activeTimesheet);
            }
            FetchActiveTimesheet();
            UpdateForm();
        }

        private void ToggleTimesheet(Project project, Activity activity)
        {
            if (activeTimesheet != null)
            {
                StopActiveTimesheet();
            }
            else
            {
                StartTimesheet(project, activity);
            }
        }

        private void UpdateForm()
        {
            labelId.Text = activeTimesheet?.Id.ToString();
            labelStart.Text = activeTimesheet?.Begin.ToString();

            notifyIconMain.Icon = activeTimesheet != null ? Properties.Resource.IconStart : Properties.Resource.IconPause;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FetchActiveTimesheet();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Project project = new Project(int.Parse(textBoxProjectId.Text));
            Activity activity = new Activity(int.Parse(textBoxActivityId.Text));

            StartTimesheet(project, activity);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StopActiveTimesheet();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (activeTimesheet != null)
            {
                TimeSpan diff = DateTime.Now.Subtract(activeTimesheet.Begin);
                labelDuration.Text = diff.ToString();
            }
            else
            {
                labelDuration.Text = "";
            }
        }

        private void notifyIconMain_MouseClick(object sender, MouseEventArgs e)
        {
            Project project = new Project(int.Parse(textBoxProjectId.Text));
            Activity activity = new Activity(int.Parse(textBoxActivityId.Text));

            ToggleTimesheet(project, activity);
        }

        private void notifyIconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Show();
            //Activate();
            //Top = Screen.PrimaryScreen.WorkingArea.Bottom - Height;
            //Left = Screen.PrimaryScreen.WorkingArea.Right - Width;
        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            //Hide();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            //Application.Exit();
        }
    }
}
