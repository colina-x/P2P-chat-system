namespace UI
{
    partial class Login
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
            this.AccountLable = new System.Windows.Forms.Label();
            this.AccountTextbox = new System.Windows.Forms.TextBox();
            this.PasswordLable = new System.Windows.Forms.Label();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.Textbox_Ip = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AccountLable
            // 
            this.AccountLable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountLable.AutoSize = true;
            this.AccountLable.BackColor = System.Drawing.Color.Gainsboro;
            this.AccountLable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AccountLable.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AccountLable.ForeColor = System.Drawing.SystemColors.InfoText;
            this.AccountLable.Location = new System.Drawing.Point(227, 107);
            this.AccountLable.Margin = new System.Windows.Forms.Padding(0);
            this.AccountLable.Name = "AccountLable";
            this.AccountLable.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AccountLable.Size = new System.Drawing.Size(47, 22);
            this.AccountLable.TabIndex = 0;
            this.AccountLable.Text = "账号";
            this.AccountLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AccountTextbox
            // 
            this.AccountTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountTextbox.BackColor = System.Drawing.Color.White;
            this.AccountTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AccountTextbox.Location = new System.Drawing.Point(309, 104);
            this.AccountTextbox.Name = "AccountTextbox";
            this.AccountTextbox.Size = new System.Drawing.Size(227, 27);
            this.AccountTextbox.TabIndex = 1;
            this.AccountTextbox.Tag = "";
            // 
            // PasswordLable
            // 
            this.PasswordLable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordLable.AutoSize = true;
            this.PasswordLable.BackColor = System.Drawing.Color.Gainsboro;
            this.PasswordLable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PasswordLable.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PasswordLable.ForeColor = System.Drawing.SystemColors.InfoText;
            this.PasswordLable.Location = new System.Drawing.Point(227, 169);
            this.PasswordLable.Margin = new System.Windows.Forms.Padding(0);
            this.PasswordLable.Name = "PasswordLable";
            this.PasswordLable.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PasswordLable.Size = new System.Drawing.Size(47, 22);
            this.PasswordLable.TabIndex = 0;
            this.PasswordLable.Text = "密码";
            this.PasswordLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTextbox.BackColor = System.Drawing.Color.White;
            this.PasswordTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextbox.Location = new System.Drawing.Point(309, 164);
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.PasswordChar = '*';
            this.PasswordTextbox.Size = new System.Drawing.Size(227, 27);
            this.PasswordTextbox.TabIndex = 2;
            this.PasswordTextbox.Tag = "";
            // 
            // LoginButton
            // 
            this.LoginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.LoginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginButton.Location = new System.Drawing.Point(204, 309);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(100, 35);
            this.LoginButton.TabIndex = 3;
            this.LoginButton.Text = "登录";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RegisterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RegisterButton.Location = new System.Drawing.Point(489, 309);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(100, 35);
            this.RegisterButton.TabIndex = 4;
            this.RegisterButton.Text = "注册";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // Textbox_Ip
            // 
            this.Textbox_Ip.BackColor = System.Drawing.Color.LightGray;
            this.Textbox_Ip.Location = new System.Drawing.Point(610, 417);
            this.Textbox_Ip.Margin = new System.Windows.Forms.Padding(0);
            this.Textbox_Ip.Name = "Textbox_Ip";
            this.Textbox_Ip.Size = new System.Drawing.Size(163, 27);
            this.Textbox_Ip.TabIndex = 5;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(782, 453);
            this.Controls.Add(this.Textbox_Ip);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordTextbox);
            this.Controls.Add(this.AccountTextbox);
            this.Controls.Add(this.PasswordLable);
            this.Controls.Add(this.AccountLable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录界面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label AccountLable;
        private TextBox AccountTextbox;
        private Label PasswordLable;
        private TextBox PasswordTextbox;
        private Button LoginButton;
        private Button RegisterButton;
        private TextBox Textbox_Ip;
    }
}