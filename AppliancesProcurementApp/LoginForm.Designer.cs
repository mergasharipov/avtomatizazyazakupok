using System.Drawing;
using System.Windows.Forms;

namespace AppliancesProcurement
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblTitle;
        private Label lblLogin;
        private Label lblPassword;

        /// <summary>
        /// Освобождение всех используемых ресурсов.
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
            this.txtLogin = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.lblTitle = new Label();
            this.lblLogin = new Label();
            this.lblPassword = new Label();
            this.SuspendLayout();

            // 
            // lblTitle
            // 
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(64, 64, 64);
            this.lblTitle.Location = new Point(0, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(320, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ВХОД В СИСТЕМУ";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new Font("Segoe UI", 9F);
            this.lblLogin.Location = new Point(40, 55);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new Size(44, 15);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Логин:";

            // 
            // txtLogin
            // 
            this.txtLogin.Font = new Font("Segoe UI", 11F);
            this.txtLogin.Location = new Point(40, 75);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new Size(240, 27);
            this.txtLogin.TabIndex = 2;

            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new Font("Segoe UI", 9F);
            this.lblPassword.Location = new Point(40, 110);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(52, 15);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Пароль:";

            // 
            // txtPassword
            // 
            this.txtPassword.Font = new Font("Segoe UI", 11F);
            this.txtPassword.Location = new Point(40, 130);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new Size(240, 27);
            this.txtPassword.TabIndex = 4;

            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = Color.FromArgb(0, 122, 204);
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.Location = new Point(40, 175);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new Size(240, 40);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "ВОЙТИ";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);

            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(320, 250);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}