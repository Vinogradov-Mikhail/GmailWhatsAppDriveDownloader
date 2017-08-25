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
    public partial class EmailInfoForm : Form
    {
        public EmailInfoForm(string from, string to, string message, string html)
        {
            if (from == null || to == null || message == null || html == null)
            {
                throw new ArgumentNullException();
            }

            InitializeComponent();
            webBrowser.Navigate("about:blank");
            if (webBrowser.Document != null)
            {
                webBrowser.Document.Write(string.Empty);
            }

            webBrowser.DocumentText = html;
            emailTextBox.Text = message;
            fromTextBox.Text = from;
            toTextBox.Text = to;
        }
    }
}