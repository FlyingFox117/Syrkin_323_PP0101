
namespace Ponyville_School
{
    partial class form_Login
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Login));
            this.bt_Enter = new System.Windows.Forms.Button();
            this.box_Login = new System.Windows.Forms.TextBox();
            this.box_Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.password_show = new System.Windows.Forms.PictureBox();
            this.bt_Reg = new System.Windows.Forms.Button();
            this.panel_Registration = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.box_RegRPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.box_RegPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.box_RegName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.box_RegLogin = new System.Windows.Forms.TextBox();
            this.bt_CreateUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.password_show)).BeginInit();
            this.panel_Registration.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_Enter
            // 
            this.bt_Enter.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bt_Enter.Location = new System.Drawing.Point(225, 198);
            this.bt_Enter.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Enter.Name = "bt_Enter";
            this.bt_Enter.Size = new System.Drawing.Size(195, 38);
            this.bt_Enter.TabIndex = 3;
            this.bt_Enter.Text = "Войти";
            this.bt_Enter.UseVisualStyleBackColor = true;
            this.bt_Enter.Click += new System.EventHandler(this.bt_Enter_Click);
            // 
            // box_Login
            // 
            this.box_Login.Location = new System.Drawing.Point(179, 91);
            this.box_Login.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.box_Login.MaxLength = 50;
            this.box_Login.Name = "box_Login";
            this.box_Login.Size = new System.Drawing.Size(293, 29);
            this.box_Login.TabIndex = 1;
            // 
            // box_Password
            // 
            this.box_Password.Location = new System.Drawing.Point(179, 146);
            this.box_Password.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.box_Password.MaxLength = 30;
            this.box_Password.Name = "box_Password";
            this.box_Password.PasswordChar = '*';
            this.box_Password.Size = new System.Drawing.Size(293, 29);
            this.box_Password.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пароль";
            // 
            // password_show
            // 
            this.password_show.BackgroundImage = global::Ponyville_School.Properties.Resources.Без_пароля;
            this.password_show.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.password_show.Location = new System.Drawing.Point(435, 196);
            this.password_show.Name = "password_show";
            this.password_show.Size = new System.Drawing.Size(193, 168);
            this.password_show.TabIndex = 5;
            this.password_show.TabStop = false;
            this.password_show.MouseLeave += new System.EventHandler(this.password_show_MouseLeave);
            this.password_show.MouseHover += new System.EventHandler(this.password_show_MouseHover);
            // 
            // bt_Reg
            // 
            this.bt_Reg.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Reg.Location = new System.Drawing.Point(225, 258);
            this.bt_Reg.Name = "bt_Reg";
            this.bt_Reg.Size = new System.Drawing.Size(195, 38);
            this.bt_Reg.TabIndex = 4;
            this.bt_Reg.Text = "Создать аккаунт";
            this.bt_Reg.UseVisualStyleBackColor = true;
            this.bt_Reg.Click += new System.EventHandler(this.bt_Reg_Click);
            // 
            // panel_Registration
            // 
            this.panel_Registration.Controls.Add(this.label7);
            this.panel_Registration.Controls.Add(this.bt_Cancel);
            this.panel_Registration.Controls.Add(this.label6);
            this.panel_Registration.Controls.Add(this.box_RegRPass);
            this.panel_Registration.Controls.Add(this.label5);
            this.panel_Registration.Controls.Add(this.box_RegPass);
            this.panel_Registration.Controls.Add(this.label4);
            this.panel_Registration.Controls.Add(this.box_RegName);
            this.panel_Registration.Controls.Add(this.label3);
            this.panel_Registration.Controls.Add(this.box_RegLogin);
            this.panel_Registration.Controls.Add(this.bt_CreateUser);
            this.panel_Registration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Registration.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel_Registration.Location = new System.Drawing.Point(0, 0);
            this.panel_Registration.Name = "panel_Registration";
            this.panel_Registration.Size = new System.Drawing.Size(629, 363);
            this.panel_Registration.TabIndex = 7;
            this.panel_Registration.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 23);
            this.label7.TabIndex = 9;
            this.label7.Text = "Это версия 1.3.1!";
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Location = new System.Drawing.Point(250, 300);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(138, 40);
            this.bt_Cancel.TabIndex = 6;
            this.bt_Cancel.Text = "Назад";
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(80, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 52);
            this.label6.TabIndex = 8;
            this.label6.Text = "Повтори пароль";
            // 
            // box_RegRPass
            // 
            this.box_RegRPass.Location = new System.Drawing.Point(180, 197);
            this.box_RegRPass.MaxLength = 30;
            this.box_RegRPass.Name = "box_RegRPass";
            this.box_RegRPass.Size = new System.Drawing.Size(293, 29);
            this.box_RegRPass.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Пароль";
            // 
            // box_RegPass
            // 
            this.box_RegPass.Location = new System.Drawing.Point(179, 148);
            this.box_RegPass.MaxLength = 30;
            this.box_RegPass.Name = "box_RegPass";
            this.box_RegPass.Size = new System.Drawing.Size(294, 29);
            this.box_RegPass.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Имя";
            // 
            // box_RegName
            // 
            this.box_RegName.Location = new System.Drawing.Point(179, 106);
            this.box_RegName.MaxLength = 30;
            this.box_RegName.Name = "box_RegName";
            this.box_RegName.Size = new System.Drawing.Size(294, 29);
            this.box_RegName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Почта";
            // 
            // box_RegLogin
            // 
            this.box_RegLogin.Location = new System.Drawing.Point(179, 65);
            this.box_RegLogin.MaxLength = 50;
            this.box_RegLogin.Name = "box_RegLogin";
            this.box_RegLogin.Size = new System.Drawing.Size(294, 29);
            this.box_RegLogin.TabIndex = 1;
            // 
            // bt_CreateUser
            // 
            this.bt_CreateUser.Location = new System.Drawing.Point(250, 243);
            this.bt_CreateUser.Name = "bt_CreateUser";
            this.bt_CreateUser.Size = new System.Drawing.Size(138, 42);
            this.bt_CreateUser.TabIndex = 5;
            this.bt_CreateUser.Text = "Регистрация";
            this.bt_CreateUser.UseVisualStyleBackColor = true;
            this.bt_CreateUser.Click += new System.EventHandler(this.bt_CreateUser_Click);
            // 
            // form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 363);
            this.Controls.Add(this.panel_Registration);
            this.Controls.Add(this.bt_Reg);
            this.Controls.Add(this.password_show);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.box_Password);
            this.Controls.Add(this.box_Login);
            this.Controls.Add(this.bt_Enter);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "form_Login";
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.form_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.password_show)).EndInit();
            this.panel_Registration.ResumeLayout(false);
            this.panel_Registration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_Enter;
        private System.Windows.Forms.TextBox box_Login;
        private System.Windows.Forms.TextBox box_Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox password_show;
        private System.Windows.Forms.Button bt_Reg;
        private System.Windows.Forms.Panel panel_Registration;
        private System.Windows.Forms.Button bt_CreateUser;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox box_RegRPass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox box_RegPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox box_RegName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox box_RegLogin;
        private System.Windows.Forms.Label label7;
    }
}

