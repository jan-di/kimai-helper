﻿namespace KimaiHelper.Forms
{
    partial class SummaryForm
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
            this.labelTimesheetStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTimesheetStatus
            // 
            this.labelTimesheetStatus.AutoSize = true;
            this.labelTimesheetStatus.Location = new System.Drawing.Point(356, 86);
            this.labelTimesheetStatus.Name = "labelTimesheetStatus";
            this.labelTimesheetStatus.Size = new System.Drawing.Size(118, 15);
            this.labelTimesheetStatus.TabIndex = 0;
            this.labelTimesheetStatus.Text = "labelTimesheetStatus";
            // 
            // SummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTimesheetStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SummaryForm";
            this.ShowInTaskbar = false;
            this.Text = "SummaryForm";
            this.Deactivate += new System.EventHandler(this.SummaryForm_Deactivate);
            this.VisibleChanged += new System.EventHandler(this.SummaryForm_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTimesheetStatus;
    }
}