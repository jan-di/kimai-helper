namespace KimaiHelper
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.labelStart = new System.Windows.Forms.Label();
            this.labelDuration = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxActivityId = new System.Windows.Forms.TextBox();
            this.textBoxProjectId = new System.Windows.Forms.TextBox();
            this.textBoxApiUrl = new System.Windows.Forms.TextBox();
            this.textBoxApiUser = new System.Windows.Forms.TextBox();
            this.textBoxApiKey = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 226);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(713, 294);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(74, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(205, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(367, 181);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelStart
            // 
            this.labelStart.AutoSize = true;
            this.labelStart.Location = new System.Drawing.Point(74, 60);
            this.labelStart.Name = "labelStart";
            this.labelStart.Size = new System.Drawing.Size(38, 15);
            this.labelStart.TabIndex = 4;
            this.labelStart.Text = "label1";
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Location = new System.Drawing.Point(74, 103);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(38, 15);
            this.labelDuration.TabIndex = 4;
            this.labelDuration.Text = "label1";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(74, 24);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(38, 15);
            this.labelId.TabIndex = 4;
            this.labelId.Text = "label1";
            // 
            // textBoxActivityId
            // 
            this.textBoxActivityId.Location = new System.Drawing.Point(205, 142);
            this.textBoxActivityId.Name = "textBoxActivityId";
            this.textBoxActivityId.Size = new System.Drawing.Size(75, 23);
            this.textBoxActivityId.TabIndex = 5;
            this.textBoxActivityId.Text = "2";
            // 
            // textBoxProjectId
            // 
            this.textBoxProjectId.Location = new System.Drawing.Point(205, 103);
            this.textBoxProjectId.Name = "textBoxProjectId";
            this.textBoxProjectId.Size = new System.Drawing.Size(75, 23);
            this.textBoxProjectId.TabIndex = 5;
            this.textBoxProjectId.Text = "2";
            // 
            // textBoxApiUrl
            // 
            this.textBoxApiUrl.Location = new System.Drawing.Point(319, 16);
            this.textBoxApiUrl.Name = "textBoxApiUrl";
            this.textBoxApiUrl.Size = new System.Drawing.Size(423, 23);
            this.textBoxApiUrl.TabIndex = 6;
            // 
            // textBoxApiUser
            // 
            this.textBoxApiUser.Location = new System.Drawing.Point(319, 52);
            this.textBoxApiUser.Name = "textBoxApiUser";
            this.textBoxApiUser.Size = new System.Drawing.Size(100, 23);
            this.textBoxApiUser.TabIndex = 7;
            // 
            // textBoxApiKey
            // 
            this.textBoxApiKey.Location = new System.Drawing.Point(438, 52);
            this.textBoxApiKey.Name = "textBoxApiKey";
            this.textBoxApiKey.Size = new System.Drawing.Size(304, 23);
            this.textBoxApiKey.TabIndex = 8;
            this.textBoxApiKey.UseSystemPasswordChar = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.textBoxApiKey);
            this.Controls.Add(this.textBoxApiUser);
            this.Controls.Add(this.textBoxApiUrl);
            this.Controls.Add(this.textBoxProjectId);
            this.Controls.Add(this.textBoxActivityId);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.labelStart);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labelStart;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxActivityId;
        private System.Windows.Forms.TextBox textBoxProjectId;
        private System.Windows.Forms.TextBox textBoxApiUrl;
        private System.Windows.Forms.TextBox textBoxApiUser;
        private System.Windows.Forms.TextBox textBoxApiKey;
        private System.Windows.Forms.Timer timer1;
    }
}

