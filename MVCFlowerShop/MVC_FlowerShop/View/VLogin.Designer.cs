namespace MVC_FlowerShop.View
{
    partial class VLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VLogin));
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.labelFlowerShop = new System.Windows.Forms.Label();
            this.labelSelectLanguage = new System.Windows.Forms.Label();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.Font = new System.Drawing.Font("Segoe Script", 20.25F, System.Drawing.FontStyle.Bold);
            this.labelUsername.Location = new System.Drawing.Point(422, 475);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(331, 90);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username:";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.Font = new System.Drawing.Font("Segoe Script", 20.25F, System.Drawing.FontStyle.Bold);
            this.labelPassword.Location = new System.Drawing.Point(430, 598);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(323, 90);
            this.labelPassword.TabIndex = 1;
            this.labelPassword.Text = "Password:";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.textBoxUsername.Location = new System.Drawing.Point(853, 489);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(680, 61);
            this.textBoxUsername.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBoxPassword.Location = new System.Drawing.Point(853, 638);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(680, 28);
            this.textBoxPassword.TabIndex = 3;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(173)))), ((int)(((byte)(97)))));
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Segoe Script", 20.25F, System.Drawing.FontStyle.Bold);
            this.buttonLogin.Location = new System.Drawing.Point(837, 738);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(335, 87);
            this.buttonLogin.TabIndex = 4;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            // 
            // labelFlowerShop
            // 
            this.labelFlowerShop.AutoSize = true;
            this.labelFlowerShop.BackColor = System.Drawing.Color.Transparent;
            this.labelFlowerShop.Font = new System.Drawing.Font("Segoe Script", 40F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelFlowerShop.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelFlowerShop.Location = new System.Drawing.Point(602, 152);
            this.labelFlowerShop.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelFlowerShop.Name = "labelFlowerShop";
            this.labelFlowerShop.Size = new System.Drawing.Size(776, 177);
            this.labelFlowerShop.TabIndex = 5;
            this.labelFlowerShop.Text = "Flower Shop";
            // 
            // labelSelectLanguage
            // 
            this.labelSelectLanguage.AutoSize = true;
            this.labelSelectLanguage.BackColor = System.Drawing.Color.Transparent;
            this.labelSelectLanguage.Font = new System.Drawing.Font("Segoe Script", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectLanguage.Location = new System.Drawing.Point(455, 377);
            this.labelSelectLanguage.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelSelectLanguage.Name = "labelSelectLanguage";
            this.labelSelectLanguage.Size = new System.Drawing.Size(298, 53);
            this.labelSelectLanguage.TabIndex = 6;
            this.labelSelectLanguage.Text = "Select language:";
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "English",
            "French",
            "Italian"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(816, 391);
            this.comboBoxLanguage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(430, 33);
            this.comboBoxLanguage.TabIndex = 7;
            // 
            // VLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MVC_FlowerShop.Properties.Resources.loginBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1986, 1225);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.labelSelectLanguage);
            this.Controls.Add(this.labelFlowerShop);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "VLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - FlowerShop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label labelFlowerShop;
        private System.Windows.Forms.Label labelSelectLanguage;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
    }
}