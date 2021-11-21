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

            trayIcon.Icon = SystemIcons.Asterisk;
            trayIcon.ContextMenuStrip = trayMenu;
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
    }
}
