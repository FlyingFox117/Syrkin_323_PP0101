
namespace Ponyville_School
{
    partial class form_Task
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Task));
            this.box_Theory = new System.Windows.Forms.RichTextBox();
            this.bt_Continue = new System.Windows.Forms.Button();
            this.video_Theory = new AxWMPLib.AxWindowsMediaPlayer();
            this.lb_TaskQuestion = new System.Windows.Forms.Label();
            this.panel_Practice = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.video_Theory)).BeginInit();
            this.panel_Practice.SuspendLayout();
            this.SuspendLayout();
            // 
            // box_Theory
            // 
            this.box_Theory.Location = new System.Drawing.Point(66, 52);
            this.box_Theory.Margin = new System.Windows.Forms.Padding(6);
            this.box_Theory.Name = "box_Theory";
            this.box_Theory.ReadOnly = true;
            this.box_Theory.Size = new System.Drawing.Size(730, 394);
            this.box_Theory.TabIndex = 1;
            this.box_Theory.Text = "";
            this.box_Theory.Visible = false;
            // 
            // bt_Continue
            // 
            this.bt_Continue.Enabled = false;
            this.bt_Continue.Location = new System.Drawing.Point(640, 472);
            this.bt_Continue.Margin = new System.Windows.Forms.Padding(6);
            this.bt_Continue.Name = "bt_Continue";
            this.bt_Continue.Size = new System.Drawing.Size(211, 47);
            this.bt_Continue.TabIndex = 2;
            this.bt_Continue.Text = "Дальше";
            this.bt_Continue.UseVisualStyleBackColor = true;
            this.bt_Continue.Click += new System.EventHandler(this.bt_Continue_Click);
            // 
            // video_Theory
            // 
            this.video_Theory.Enabled = true;
            this.video_Theory.Location = new System.Drawing.Point(66, 52);
            this.video_Theory.Name = "video_Theory";
            this.video_Theory.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("video_Theory.OcxState")));
            this.video_Theory.Size = new System.Drawing.Size(730, 405);
            this.video_Theory.TabIndex = 5;
            this.video_Theory.Visible = false;
            // 
            // lb_TaskQuestion
            // 
            this.lb_TaskQuestion.AutoSize = true;
            this.lb_TaskQuestion.Location = new System.Drawing.Point(117, 21);
            this.lb_TaskQuestion.Name = "lb_TaskQuestion";
            this.lb_TaskQuestion.Size = new System.Drawing.Size(621, 25);
            this.lb_TaskQuestion.TabIndex = 6;
            this.lb_TaskQuestion.Text = "Просмотри видео и выполни тестовую часть на следующей странице";
            // 
            // panel_Practice
            // 
            this.panel_Practice.AutoScroll = true;
            this.panel_Practice.Controls.Add(this.label1);
            this.panel_Practice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Practice.Location = new System.Drawing.Point(0, 0);
            this.panel_Practice.Name = "panel_Practice";
            this.panel_Practice.Size = new System.Drawing.Size(866, 528);
            this.panel_Practice.TabIndex = 7;
            this.panel_Practice.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Дай ответ на вопросы ниже";
            // 
            // form_Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 528);
            this.Controls.Add(this.panel_Practice);
            this.Controls.Add(this.lb_TaskQuestion);
            this.Controls.Add(this.video_Theory);
            this.Controls.Add(this.bt_Continue);
            this.Controls.Add(this.box_Theory);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "form_Task";
            this.Text = "Выполнение задания";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_Task_FormClosing);
            this.Load += new System.EventHandler(this.form_Task_Load);
            ((System.ComponentModel.ISupportInitialize)(this.video_Theory)).EndInit();
            this.panel_Practice.ResumeLayout(false);
            this.panel_Practice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox box_Theory;
        private System.Windows.Forms.Button bt_Continue;
        private AxWMPLib.AxWindowsMediaPlayer video_Theory;
        private System.Windows.Forms.Label lb_TaskQuestion;
        private System.Windows.Forms.Panel panel_Practice;
        private System.Windows.Forms.Label label1;
    }
}