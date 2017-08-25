namespace GmailViewer
{
    partial class SignInForm
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
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.loginLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.signInBotton = new System.Windows.Forms.Button();
            this.authTypeComboBox = new System.Windows.Forms.ComboBox();
            this.authTypeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginTextBox
            // 
            this.loginTextBox.Location = new System.Drawing.Point(75, 44);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(149, 20);
            this.loginTextBox.TabIndex = 1;
            this.loginTextBox.Enter += new System.EventHandler(this.LoginTextBoxEnter);
            this.loginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginTextBoxKeyPress);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(13, 47);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(33, 13);
            this.loginLabel.TabIndex = 1;
            this.loginLabel.Text = "Login";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(12, 70);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(75, 67);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(149, 20);
            this.passwordTextBox.TabIndex = 2;
            this.passwordTextBox.Enter += new System.EventHandler(this.PasswordTextBoxEnter);
            this.passwordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordTextBoxKeyPress);
            // 
            // signInBotton
            // 
            this.signInBotton.Location = new System.Drawing.Point(12, 93);
            this.signInBotton.Name = "signInBotton";
            this.signInBotton.Size = new System.Drawing.Size(212, 46);
            this.signInBotton.TabIndex = 3;
            this.signInBotton.Text = "Sign In";
            this.signInBotton.UseVisualStyleBackColor = true;
            this.signInBotton.Click += new System.EventHandler(this.SignInButtonClick);
            // 
            // authTypeComboBox
            // 
            this.authTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.authTypeComboBox.FormattingEnabled = true;
            this.authTypeComboBox.Location = new System.Drawing.Point(75, 17);
            this.authTypeComboBox.Name = "authTypeComboBox";
            this.authTypeComboBox.Size = new System.Drawing.Size(149, 21);
            this.authTypeComboBox.TabIndex = 0;
            this.authTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.AuthTypeComboBoxSelectedIndexChanged);
            this.authTypeComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AuthTypeComboBoxKeyDown);
            // 
            // authTypeLabel
            // 
            this.authTypeLabel.AutoSize = true;
            this.authTypeLabel.Location = new System.Drawing.Point(13, 20);
            this.authTypeLabel.Name = "authTypeLabel";
            this.authTypeLabel.Size = new System.Drawing.Size(52, 13);
            this.authTypeLabel.TabIndex = 6;
            this.authTypeLabel.Text = "Auth type";
            // 
            // SignInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 146);
            this.Controls.Add(this.authTypeLabel);
            this.Controls.Add(this.authTypeComboBox);
            this.Controls.Add(this.signInBotton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.loginTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign in";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SignInFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button signInBotton;
        private System.Windows.Forms.ComboBox authTypeComboBox;
        private System.Windows.Forms.Label authTypeLabel;
    }
}