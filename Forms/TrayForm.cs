using KimaiHelper.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KimaiHelper.Forms
{
    public partial class TrayForm : Form
    {
        AppContext appContext;

        public TrayForm(AppContext appContext)
        {
            this.appContext = appContext;

            InitializeComponent();

            trayIcon.ContextMenuStrip = trayMenu;

            appContext.TimesheetStatusChanged += OnTimesheetStatusChanged;

            UpdateForm();
        }

        private void UpdateForm()
        {
            if (InvokeRequired)
            {
                Invoke(UpdateForm);
                return;
            }

            switch (appContext.TimesheetStatus)
            {
                case TimesheetStatus.Unknown:
                    trayIcon.Icon = Resource.IconUnknown;
                    trayItemToggle.Text = "Connecting..";
                    trayItemToggle.Enabled = false;
                    break;
                case TimesheetStatus.Started:
                    trayIcon.Icon = Resource.IconStart;
                    trayItemToggle.Text = "Stop";
                    trayItemToggle.Enabled = true;
                    break;
                case TimesheetStatus.StartPending:
                    trayIcon.Icon = Resource.IconStart;
                    trayItemToggle.Text = "Starting..";
                    trayItemToggle.Enabled = false;
                    break;
                case TimesheetStatus.Stopped:
                    trayIcon.Icon = Resource.IconPause;
                    trayItemToggle.Text = "Start";
                    trayItemToggle.Enabled = true;
                    break;
                case TimesheetStatus.StopPending:
                    trayIcon.Icon = Resource.IconPause;
                    trayItemToggle.Text = "Stopping..";
                    trayItemToggle.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void OnTimesheetStatusChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void trayItemExit_Click(object sender, EventArgs e)
        {
            appContext.Exit();
        }

        private void trayItemSettings_Click(object sender, EventArgs e)
        {
            appContext.ShowSettingsForm();
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            appContext.ShowSummaryForm();
        }

        private async void trayItemToggle_Click(object sender, EventArgs e)
        {
            await appContext.ToggleTimesheet();
        }
    }
}
