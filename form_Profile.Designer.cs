namespace Ponyville_School
{
    partial class form_Profile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Profile));
            this.panel_Upper = new System.Windows.Forms.Panel();
            this.lb_Progress = new System.Windows.Forms.Label();
            this.bt_Back = new System.Windows.Forms.Button();
            this.panel_Results = new System.Windows.Forms.Panel();
            this.bt_Exit = new System.Windows.Forms.Button();
            this.lb_Name = new System.Windows.Forms.Label();
            this.lb_Total = new System.Windows.Forms.Label();
            this.lb_Email = new System.Windows.Forms.Label();
            this.bt_ChangeName = new System.Windows.Forms.Button();
            this.lb_ID = new System.Windows.Forms.Label();
            this.pb_PFP = new System.Windows.Forms.PictureBox();
            this.panel_Upper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_PFP)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Upper
            // 
            this.panel_Upper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Upper.Controls.Add(this.lb_Progress);
            this.panel_Upper.Controls.Add(this.bt_Back);
            this.panel_Upper.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Upper.Location = new System.Drawing.Point(0, 0);
            this.panel_Upper.Name = "panel_Upper";
            this.panel_Upper.Size = new System.Drawing.Size(869, 65);
            this.panel_Upper.TabIndex = 0;
            // 
            // lb_Progress
            // 
            this.lb_Progress.AutoSize = true;
            this.lb_Progress.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Progress.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lb_Progress.Location = new System.Drawing.Point(573, 20);
            this.lb_Progress.Name = "lb_Progress";
            this.lb_Progress.Size = new System.Drawing.Size(251, 23);
            this.lb_Progress.TabIndex = 1;
            this.lb_Progress.Text = "Выполненные задания:";
            // 
            // bt_Back
            // 
            this.bt_Back.Location = new System.Drawing.Point(12, 12);
            this.bt_Back.Name = "bt_Back";
            this.bt_Back.Size = new System.Drawing.Size(90, 39);
            this.bt_Back.TabIndex = 0;
            this.bt_Back.Text = "Назад";
            this.bt_Back.UseVisualStyleBackColor = true;
            this.bt_Back.Click += new System.EventHandler(this.bt_Back_Click);
            // 
            // panel_Results
            // 
            this.panel_Results.AutoScroll = true;
            this.panel_Results.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Results.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_Results.Location = new System.Drawing.Point(530, 65);
            this.panel_Results.Name = "panel_Results";
            this.panel_Results.Size = new System.Drawing.Size(339, 452);
            this.panel_Results.TabIndex = 1;
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(8, 465);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(165, 40);
            this.bt_Exit.TabIndex = 3;
            this.bt_Exit.Text = "Выйти";
            this.bt_Exit.UseVisualStyleBackColor = true;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // lb_Name
            // 
            this.lb_Name.AutoSize = true;
            this.lb_Name.Font = new System.Drawing.Font("Georgia", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Name.Location = new System.Drawing.Point(159, 109);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(84, 34);
            this.lb_Name.TabIndex = 4;
            this.lb_Name.Text = "Имя";
            // 
            // lb_Total
            // 
            this.lb_Total.AutoSize = true;
            this.lb_Total.Location = new System.Drawing.Point(161, 189);
            this.lb_Total.Name = "lb_Total";
            this.lb_Total.Size = new System.Drawing.Size(168, 23);
            this.lb_Total.TabIndex = 5;
            this.lb_Total.Text = "Общий прогресс: ";
            // 
            // lb_Email
            // 
            this.lb_Email.AutoSize = true;
            this.lb_Email.Location = new System.Drawing.Point(161, 149);
            this.lb_Email.Name = "lb_Email";
            this.lb_Email.Size = new System.Drawing.Size(61, 23);
            this.lb_Email.TabIndex = 6;
            this.lb_Email.Text = "почта";
            // 
            // bt_ChangeName
            // 
            this.bt_ChangeName.Location = new System.Drawing.Point(179, 465);
            this.bt_ChangeName.Name = "bt_ChangeName";
            this.bt_ChangeName.Size = new System.Drawing.Size(165, 40);
            this.bt_ChangeName.TabIndex = 7;
            this.bt_ChangeName.Text = "Сменить пароль";
            this.bt_ChangeName.UseVisualStyleBackColor = true;
            // 
            // lb_ID
            // 
            this.lb_ID.AutoSize = true;
            this.lb_ID.Location = new System.Drawing.Point(161, 86);
            this.lb_ID.Name = "lb_ID";
            this.lb_ID.Size = new System.Drawing.Size(37, 23);
            this.lb_ID.TabIndex = 8;
            this.lb_ID.Text = "ID:";
            // 
            // pb_PFP
            // 
            this.pb_PFP.BackgroundImage = global::Ponyville_School.Properties.Resources.AJ_PFP;
            this.pb_PFP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_PFP.Location = new System.Drawing.Point(13, 86);
            this.pb_PFP.Name = "pb_PFP";
            this.pb_PFP.Size = new System.Drawing.Size(130, 130);
            this.pb_PFP.TabIndex = 2;
            this.pb_PFP.TabStop = false;
            // 
            // form_Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(869, 517);
            this.Controls.Add(this.lb_ID);
            this.Controls.Add(this.bt_ChangeName);
            this.Controls.Add(this.lb_Email);
            this.Controls.Add(this.lb_Total);
            this.Controls.Add(this.lb_Name);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.pb_PFP);
            this.Controls.Add(this.panel_Results);
            this.Controls.Add(this.panel_Upper);
            this.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "form_Profile";
            this.Text = "Профиль";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.form_Profile_FormClosed);
            this.Load += new System.EventHandler(this.form_Profile_Load);
            this.panel_Upper.ResumeLayout(false);
            this.panel_Upper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_PFP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Upper;
        private System.Windows.Forms.Button bt_Back;
        private System.Windows.Forms.Panel panel_Results;
        private System.Windows.Forms.PictureBox pb_PFP;
        private System.Windows.Forms.Button bt_Exit;
        private System.Windows.Forms.Label lb_Progress;
        private System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.Label lb_Total;
        private System.Windows.Forms.Label lb_Email;
        private System.Windows.Forms.Button bt_ChangeName;
        private System.Windows.Forms.Label lb_ID;
    }
}