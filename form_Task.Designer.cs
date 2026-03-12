
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Task));
            this.box_Theory = new System.Windows.Forms.RichTextBox();
            this.bt_Continue = new System.Windows.Forms.Button();
            this.video_Theory = new AxWMPLib.AxWindowsMediaPlayer();
            this.lb_TaskQuestion = new System.Windows.Forms.Label();
            this.panel_Practice = new System.Windows.Forms.Panel();
            this.panel_Task = new System.Windows.Forms.Panel();
            this.lb_Timer = new System.Windows.Forms.Label();
            this.timer_Practice = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.video_Theory)).BeginInit();
            this.panel_Task.SuspendLayout();
            this.SuspendLayout();
            // 
            // box_Theory
            // 
            this.box_Theory.Location = new System.Drawing.Point(66, 48);
            this.box_Theory.Margin = new System.Windows.Forms.Padding(6);
            this.box_Theory.Name = "box_Theory";
            this.box_Theory.ReadOnly = true;
            this.box_Theory.Size = new System.Drawing.Size(730, 363);
            this.box_Theory.TabIndex = 1;
            this.box_Theory.Text = "";
            this.box_Theory.Visible = false;
            // 
            // bt_Continue
            // 
            this.bt_Continue.Enabled = false;
            this.bt_Continue.Location = new System.Drawing.Point(640, 462);
            this.bt_Continue.Margin = new System.Windows.Forms.Padding(6);
            this.bt_Continue.Name = "bt_Continue";
            this.bt_Continue.Size = new System.Drawing.Size(211, 43);
            this.bt_Continue.TabIndex = 2;
            this.bt_Continue.Text = "Дальше";
            this.bt_Continue.UseVisualStyleBackColor = true;
            this.bt_Continue.Click += new System.EventHandler(this.bt_Continue_Click);
            // 
            // video_Theory
            // 
            this.video_Theory.Enabled = true;
            this.video_Theory.Location = new System.Drawing.Point(66, 48);
            this.video_Theory.Name = "video_Theory";
            this.video_Theory.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("video_Theory.OcxState")));
            this.video_Theory.Size = new System.Drawing.Size(730, 405);
            this.video_Theory.TabIndex = 5;
            this.video_Theory.Visible = false;
            // 
            // lb_TaskQuestion
            // 
            this.lb_TaskQuestion.AutoSize = true;
            this.lb_TaskQuestion.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_TaskQuestion.Location = new System.Drawing.Point(12, 17);
            this.lb_TaskQuestion.Name = "lb_TaskQuestion";
            this.lb_TaskQuestion.Size = new System.Drawing.Size(629, 23);
            this.lb_TaskQuestion.TabIndex = 6;
            this.lb_TaskQuestion.Text = "Просмотри видео и выполни тестовую часть на следующей странице";
            // 
            // panel_Practice
            // 
            this.panel_Practice.AutoScroll = true;
            this.panel_Practice.BackColor = System.Drawing.Color.LightGray;
            this.panel_Practice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Practice.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.panel_Practice.Location = new System.Drawing.Point(0, 0);
            this.panel_Practice.Name = "panel_Practice";
            this.panel_Practice.Size = new System.Drawing.Size(866, 518);
            this.panel_Practice.TabIndex = 7;
            this.panel_Practice.Visible = false;
            // 
            // panel_Task
            // 
            this.panel_Task.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Task.Controls.Add(this.lb_Timer);
            this.panel_Task.Controls.Add(this.lb_TaskQuestion);
            this.panel_Task.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Task.Location = new System.Drawing.Point(0, 0);
            this.panel_Task.Name = "panel_Task";
            this.panel_Task.Size = new System.Drawing.Size(866, 53);
            this.panel_Task.TabIndex = 8;
            // 
            // lb_Timer
            // 
            this.lb_Timer.AutoSize = true;
            this.lb_Timer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lb_Timer.Location = new System.Drawing.Point(784, 16);
            this.lb_Timer.Name = "lb_Timer";
            this.lb_Timer.Size = new System.Drawing.Size(0, 23);
            this.lb_Timer.TabIndex = 7;
            // 
            // timer_Practice
            // 
            this.timer_Practice.Interval = 1000;
            this.timer_Practice.Tick += new System.EventHandler(this.timer_Practice_Tick);
            // 
            // form_Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(866, 518);
            this.Controls.Add(this.panel_Task);
            this.Controls.Add(this.panel_Practice);
            this.Controls.Add(this.video_Theory);
            this.Controls.Add(this.bt_Continue);
            this.Controls.Add(this.box_Theory);
            this.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "form_Task";
            this.Text = "Выполнение задания";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_Task_FormClosing);
            this.Load += new System.EventHandler(this.form_Task_Load);
            ((System.ComponentModel.ISupportInitialize)(this.video_Theory)).EndInit();
            this.panel_Task.ResumeLayout(false);
            this.panel_Task.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox box_Theory;
        private System.Windows.Forms.Button bt_Continue;
        private AxWMPLib.AxWindowsMediaPlayer video_Theory;
        private System.Windows.Forms.Label lb_TaskQuestion;
        private System.Windows.Forms.Panel panel_Practice;
        private System.Windows.Forms.Panel panel_Task;
        private System.Windows.Forms.Label lb_Timer;
        private System.Windows.Forms.Timer timer_Practice;
    }
}