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
    public partial class SummaryForm : Form
    {
        AppContext appContext;

        public SummaryForm(AppContext appContext)
        {
            this.appContext = appContext;

            InitializeComponent();
        }

        private void SummaryForm_Deactivate(object sender, EventArgs e)
        {
            Hide();
        }

        private void SummaryForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                Top = Screen.PrimaryScreen.WorkingArea.Bottom - Height;
                Left = Screen.PrimaryScreen.WorkingArea.Right - Width;
            }
        }
    }
}
