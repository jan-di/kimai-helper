namespace KimaiHelper.Forms
{
    partial class SettingsForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxApiVersion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxActivities = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxProjects = new System.Windows.Forms.ComboBox();
            this.buttonTestApi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxApiKey = new System.Windows.Forms.TextBox();
            this.textBoxApiUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxApiUrl = new System.Windows.Forms.TextBox();
            this.appContextBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.appContextBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appContextBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appContextBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxApiVersion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBoxActivities);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxProjects);
            this.groupBox1.Controls.Add(this.buttonTestApi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxApiKey);
            this.groupBox1.Controls.Add(this.textBoxApiUser);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxApiUrl);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 248);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kimai-Server";
            // 
            // textBoxApiVersion
            // 
            this.textBoxApiVersion.Location = new System.Drawing.Point(574, 27);
            this.textBoxApiVersion.Name = "textBoxApiVersion";
            this.textBoxApiVersion.ReadOnly = true;
            this.textBoxApiVersion.Size = new System.Drawing.Size(120, 23);
            this.textBoxApiVersion.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Default Activity";
            // 
            // comboBoxActivities
            // 
            this.comboBoxActivities.DisplayMember = "Name";
            this.comboBoxActivities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxActivities.FormattingEnabled = true;
            this.comboBoxActivities.Location = new System.Drawing.Point(105, 163);
            this.comboBoxActivities.Name = "comboBoxActivities";
            this.comboBoxActivities.Size = new System.Drawing.Size(204, 23);
            this.comboBoxActivities.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Default Project";
            // 
            // comboBoxProjects
            // 
            this.comboBoxProjects.DisplayMember = "Name";
            this.comboBoxProjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProjects.FormattingEnabled = true;
            this.comboBoxProjects.Location = new System.Drawing.Point(105, 134);
            this.comboBoxProjects.Name = "comboBoxProjects";
            this.comboBoxProjects.Size = new System.Drawing.Size(204, 23);
            this.comboBoxProjects.TabIndex = 8;
            // 
            // buttonTestApi
            // 
            this.buttonTestApi.Location = new System.Drawing.Point(572, 110);
            this.buttonTestApi.Name = "buttonTestApi";
            this.buttonTestApi.Size = new System.Drawing.Size(122, 23);
            this.buttonTestApi.TabIndex = 7;
            this.buttonTestApi.Text = "Test Connection";
            this.buttonTestApi.UseVisualStyleBackColor = true;
            this.buttonTestApi.Click += new System.EventHandler(this.buttonTestApi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(315, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "API-Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username:";
            // 
            // textBoxApiKey
            // 
            this.textBoxApiKey.Location = new System.Drawing.Point(373, 56);
            this.textBoxApiKey.Name = "textBoxApiKey";
            this.textBoxApiKey.Size = new System.Drawing.Size(321, 23);
            this.textBoxApiKey.TabIndex = 4;
            this.textBoxApiKey.UseSystemPasswordChar = true;
            // 
            // textBoxApiUser
            // 
            this.textBoxApiUser.Location = new System.Drawing.Point(105, 56);
            this.textBoxApiUser.Name = "textBoxApiUser";
            this.textBoxApiUser.Size = new System.Drawing.Size(204, 23);
            this.textBoxApiUser.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server URL:";
            // 
            // textBoxApiUrl
            // 
            this.textBoxApiUrl.Location = new System.Drawing.Point(105, 27);
            this.textBoxApiUrl.Name = "textBoxApiUrl";
            this.textBoxApiUrl.Size = new System.Drawing.Size(463, 23);
            this.textBoxApiUrl.TabIndex = 1;
            // 
            // appContextBindingSource
            // 
            this.appContextBindingSource.DataSource = typeof(KimaiHelper.AppContext);
            // 
            // appContextBindingSource1
            // 
            this.appContextBindingSource1.DataSource = typeof(KimaiHelper.AppContext);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.SettingsForm_VisibleChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.appContextBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appContextBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxApiKey;
        private System.Windows.Forms.TextBox textBoxApiUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxApiUrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxActivities;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxProjects;
        private System.Windows.Forms.Button buttonTestApi;
        private System.Windows.Forms.BindingSource appContextBindingSource;
        private System.Windows.Forms.BindingSource appContextBindingSource1;
        private System.Windows.Forms.TextBox textBoxApiVersion;
    }
}