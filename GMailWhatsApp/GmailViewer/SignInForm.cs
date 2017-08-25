using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GmailViewer
{
    public partial class SignInForm : Form
    {
        private readonly Dictionary<string, AuthType> stringToAuthType = new Dictionary<string, AuthType>()
        {
            { "Gmail API", AuthType.Api },
            { "IMAP", AuthType.Imap },
            { "Google Whatsapp", AuthType.GDrive }
        };

        private GmailViewerForm mainForm;

        public SignInForm(GmailViewerForm form)
        {
            InitializeComponent();

            mainForm = form;
            authTypeComboBox.Items.AddRange(stringToAuthType.Keys.ToArray());
            this.authTypeComboBox.SelectedIndex = 0;
        }

        private void SignInFormClosing(object sender, FormClosingEventArgs e)
        {
            mainForm.Show();
            e.Cancel = true;
            Hide();
        }

        private void SignInButtonClick(object sender, EventArgs e)
        {
            authTypeComboBox.Focus();
            Hide();
            mainForm.Show();
            mainForm.TrySignIn(loginTextBox.Text, passwordTextBox.Text, stringToAuthType[authTypeComboBox.SelectedItem.ToString()]);
        }

        private void LoginTextBoxEnter(object sender, EventArgs e)
        {
            loginTextBox.SelectAll();
        }

        private void PasswordTextBoxEnter(object sender, EventArgs e)
        {
            passwordTextBox.SelectAll();
        }

        private void AuthTypeComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (stringToAuthType[authTypeComboBox.Text])
            {
                case AuthType.Api:
                    loginTextBox.Enabled = false;
                    passwordTextBox.Enabled = false;
                    break;
                case AuthType.Imap:
                    loginTextBox.Enabled = true;
                    passwordTextBox.Enabled = true;
                    break;
                case AuthType.GDrive:
                    loginTextBox.Enabled = true;
                    passwordTextBox.Enabled = true;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void AuthTypeComboBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                return;
            }

            switch (stringToAuthType[authTypeComboBox.Text])
            {
                case AuthType.Api:
                    SignInButtonClick(sender, new EventArgs());
                    break;
                case AuthType.Imap:
                    SendKeys.Send("{TAB}");
                    break;
                case AuthType.GDrive:
                    SendKeys.Send("{TAB}");
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void LoginTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                return;
            }
        }

        private void PasswordTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SignInButtonClick(sender, new EventArgs());
                return;
            }
        }
    }
}
