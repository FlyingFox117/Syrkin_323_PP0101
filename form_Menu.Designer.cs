
namespace Ponyville_School
{
    partial class form_Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Menu));
            this.panel_Course = new System.Windows.Forms.Panel();
            this.lbl_Description = new System.Windows.Forms.Label();
            this.panel_Carousel = new System.Windows.Forms.Panel();
            this.bt_ReturnToMenu = new System.Windows.Forms.Button();
            this.bt_Right = new System.Windows.Forms.Button();
            this.bt_Left = new System.Windows.Forms.Button();
            this.lb_TaskName = new System.Windows.Forms.Label();
            this.pb_Task = new System.Windows.Forms.PictureBox();
            this.bt_Start = new System.Windows.Forms.Button();
            this.bt_Magic = new System.Windows.Forms.PictureBox();
            this.bt_Laughter = new System.Windows.Forms.PictureBox();
            this.bt_Kindness = new System.Windows.Forms.PictureBox();
            this.bt_Loyalty = new System.Windows.Forms.PictureBox();
            this.bt_Generosity = new System.Windows.Forms.PictureBox();
            this.bt_Honesty = new System.Windows.Forms.PictureBox();
            this.panel_Course.SuspendLayout();
            this.panel_Carousel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Task)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_Magic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_Laughter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_Kindness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_Loyalty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_Generosity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_Honesty)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Course
            // 
            this.panel_Course.Controls.Add(this.lbl_Description);
            this.panel_Course.Location = new System.Drawing.Point(273, 487);
            this.panel_Course.Name = "panel_Course";
            this.panel_Course.Size = new System.Drawing.Size(316, 71);
            this.panel_Course.TabIndex = 6;
            this.panel_Course.Visible = false;
            // 
            // lbl_Description
            // 
            this.lbl_Description.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Description.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_Description.Location = new System.Drawing.Point(3, 3);
            this.lbl_Description.Name = "lbl_Description";
            this.lbl_Description.Size = new System.Drawing.Size(310, 63);
            this.lbl_Description.TabIndex = 0;
            this.lbl_Description.Text = "Описание";
            this.lbl_Description.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel_Carousel
            // 
            this.panel_Carousel.Controls.Add(this.bt_ReturnToMenu);
            this.panel_Carousel.Controls.Add(this.bt_Right);
            this.panel_Carousel.Controls.Add(this.bt_Left);
            this.panel_Carousel.Controls.Add(this.lb_TaskName);
            this.panel_Carousel.Controls.Add(this.pb_Task);
            this.panel_Carousel.Controls.Add(this.bt_Start);
            this.panel_Carousel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Carousel.Location = new System.Drawing.Point(0, 0);
            this.panel_Carousel.Name = "panel_Carousel";
            this.panel_Carousel.Size = new System.Drawing.Size(887, 562);
            this.panel_Carousel.TabIndex = 7;
            this.panel_Carousel.Visible = false;
            // 
            // bt_ReturnToMenu
            // 
            this.bt_ReturnToMenu.Location = new System.Drawing.Point(11, 12);
            this.bt_ReturnToMenu.Name = "bt_ReturnToMenu";
            this.bt_ReturnToMenu.Size = new System.Drawing.Size(75, 47);
            this.bt_ReturnToMenu.TabIndex = 5;
            this.bt_ReturnToMenu.Text = "Назад";
            this.bt_ReturnToMenu.UseVisualStyleBackColor = true;
            this.bt_ReturnToMenu.Click += new System.EventHandler(this.bt_ReturnToMenu_Click);
            // 
            // bt_Right
            // 
            this.bt_Right.Location = new System.Drawing.Point(656, 235);
            this.bt_Right.Name = "bt_Right";
            this.bt_Right.Size = new System.Drawing.Size(75, 68);
            this.bt_Right.TabIndex = 4;
            this.bt_Right.Text = ">>>";
            this.bt_Right.UseVisualStyleBackColor = true;
            this.bt_Right.Click += new System.EventHandler(this.bt_Right_Click);
            // 
            // bt_Left
            // 
            this.bt_Left.Location = new System.Drawing.Point(138, 235);
            this.bt_Left.Name = "bt_Left";
            this.bt_Left.Size = new System.Drawing.Size(75, 68);
            this.bt_Left.TabIndex = 3;
            this.bt_Left.Text = "<<<";
            this.bt_Left.UseVisualStyleBackColor = true;
            this.bt_Left.Click += new System.EventHandler(this.bt_Left_Click);
            // 
            // lb_TaskName
            // 
            this.lb_TaskName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_TaskName.Location = new System.Drawing.Point(250, 50);
            this.lb_TaskName.Name = "lb_TaskName";
            this.lb_TaskName.Size = new System.Drawing.Size(364, 52);
            this.lb_TaskName.TabIndex = 2;
            this.lb_TaskName.Text = "Задание";
            this.lb_TaskName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_Task
            // 
            this.pb_Task.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Task.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Task.Location = new System.Drawing.Point(250, 143);
            this.pb_Task.Name = "pb_Task";
            this.pb_Task.Size = new System.Drawing.Size(364, 227);
            this.pb_Task.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Task.TabIndex = 1;
            this.pb_Task.TabStop = false;
            // 
            // bt_Start
            // 
            this.bt_Start.Location = new System.Drawing.Point(321, 406);
            this.bt_Start.Name = "bt_Start";
            this.bt_Start.Size = new System.Drawing.Size(223, 77);
            this.bt_Start.TabIndex = 0;
            this.bt_Start.Text = "Начать";
            this.bt_Start.UseVisualStyleBackColor = true;
            this.bt_Start.Click += new System.EventHandler(this.bt_Start_Click);
            // 
            // bt_Magic
            // 
            this.bt_Magic.Image = ((System.Drawing.Image)(resources.GetObject("bt_Magic.Image")));
            this.bt_Magic.Location = new System.Drawing.Point(572, 290);
            this.bt_Magic.Name = "bt_Magic";
            this.bt_Magic.Size = new System.Drawing.Size(270, 167);
            this.bt_Magic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bt_Magic.TabIndex = 5;
            this.bt_Magic.TabStop = false;
            // 
            // bt_Laughter
            // 
            this.bt_Laughter.Image = global::Ponyville_School.Properties.Resources.bt_laughter;
            this.bt_Laughter.Location = new System.Drawing.Point(292, 290);
            this.bt_Laughter.Name = "bt_Laughter";
            this.bt_Laughter.Size = new System.Drawing.Size(270, 167);
            this.bt_Laughter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bt_Laughter.TabIndex = 4;
            this.bt_Laughter.TabStop = false;
            // 
            // bt_Kindness
            // 
            this.bt_Kindness.Image = ((System.Drawing.Image)(resources.GetObject("bt_Kindness.Image")));
            this.bt_Kindness.Location = new System.Drawing.Point(12, 290);
            this.bt_Kindness.Name = "bt_Kindness";
            this.bt_Kindness.Size = new System.Drawing.Size(270, 167);
            this.bt_Kindness.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bt_Kindness.TabIndex = 3;
            this.bt_Kindness.TabStop = false;
            // 
            // bt_Loyalty
            // 
            this.bt_Loyalty.Image = global::Ponyville_School.Properties.Resources.bt_loyalty;
            this.bt_Loyalty.Location = new System.Drawing.Point(572, 78);
            this.bt_Loyalty.Name = "bt_Loyalty";
            this.bt_Loyalty.Size = new System.Drawing.Size(270, 167);
            this.bt_Loyalty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bt_Loyalty.TabIndex = 2;
            this.bt_Loyalty.TabStop = false;
            // 
            // bt_Generosity
            // 
            this.bt_Generosity.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_Generosity.Image = global::Ponyville_School.Properties.Resources.bt_generosity;
            this.bt_Generosity.Location = new System.Drawing.Point(292, 78);
            this.bt_Generosity.Name = "bt_Generosity";
            this.bt_Generosity.Size = new System.Drawing.Size(270, 167);
            this.bt_Generosity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bt_Generosity.TabIndex = 1;
            this.bt_Generosity.TabStop = false;
            // 
            // bt_Honesty
            // 
            this.bt_Honesty.Image = global::Ponyville_School.Properties.Resources.bt_honesty;
            this.bt_Honesty.Location = new System.Drawing.Point(12, 78);
            this.bt_Honesty.Name = "bt_Honesty";
            this.bt_Honesty.Size = new System.Drawing.Size(270, 167);
            this.bt_Honesty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bt_Honesty.TabIndex = 0;
            this.bt_Honesty.TabStop = false;
            // 
            // form_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(887, 562);
            this.Controls.Add(this.panel_Carousel);
            this.Controls.Add(this.panel_Course);
            this.Controls.Add(this.bt_Magic);
            this.Controls.Add(this.bt_Laughter);
            this.Controls.Add(this.bt_Kindness);
            this.Controls.Add(this.bt_Loyalty);
            this.Controls.Add(this.bt_Generosity);
            this.Controls.Add(this.bt_Honesty);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "form_Menu";
            this.Text = "Курсы";
            this.Load += new System.EventHandler(this.form_Menu_Load);
            this.panel_Course.ResumeLayout(false);
            this.panel_Carousel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Task)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_Magic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_Laughter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_Kindness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_Loyalty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_Generosity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_Honesty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bt_Honesty;
        private System.Windows.Forms.PictureBox bt_Generosity;
        private System.Windows.Forms.PictureBox bt_Loyalty;
        private System.Windows.Forms.PictureBox bt_Kindness;
        private System.Windows.Forms.PictureBox bt_Laughter;
        private System.Windows.Forms.PictureBox bt_Magic;
        private System.Windows.Forms.Panel panel_Course;
        private System.Windows.Forms.Label lbl_Description;
        private System.Windows.Forms.Panel panel_Carousel;
        private System.Windows.Forms.Button bt_Right;
        private System.Windows.Forms.Button bt_Left;
        private System.Windows.Forms.Label lb_TaskName;
        private System.Windows.Forms.PictureBox pb_Task;
        private System.Windows.Forms.Button bt_Start;
        private System.Windows.Forms.Button bt_ReturnToMenu;
    }
}