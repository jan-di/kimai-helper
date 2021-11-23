namespace KimaiHelper.Forms
{
    partial class TrayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayItemToggle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.trayItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.trayItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.Text = "trayIcon";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayItemToggle,
            this.toolStripSeparator1,
            this.trayItemSettings,
            this.toolStripSeparator2,
            this.trayItemExit});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(118, 82);
            // 
            // trayItemToggle
            // 
            this.trayItemToggle.Name = "trayItemToggle";
            this.trayItemToggle.Size = new System.Drawing.Size(117, 22);
            this.trayItemToggle.Text = "(Toggle)";
            this.trayItemToggle.Click += new System.EventHandler(this.trayItemToggle_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(114, 6);
            // 
            // trayItemSettings
            // 
            this.trayItemSettings.Name = "trayItemSettings";
            this.trayItemSettings.Size = new System.Drawing.Size(117, 22);
            this.trayItemSettings.Text = "Settings";
            this.trayItemSettings.Click += new System.EventHandler(this.trayItemSettings_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(114, 6);
            // 
            // trayItemExit
            // 
            this.trayItemExit.Name = "trayItemExit";
            this.trayItemExit.Size = new System.Drawing.Size(117, 22);
            this.trayItemExit.Text = "Exit";
            this.trayItemExit.Click += new System.EventHandler(this.trayItemExit_Click);
            // 
            // TrayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 314);
            this.Name = "TrayForm";
            this.Text = "TrayForm";
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem trayItemExit;
        private System.Windows.Forms.ToolStripMenuItem trayItemSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem trayItemToggle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}