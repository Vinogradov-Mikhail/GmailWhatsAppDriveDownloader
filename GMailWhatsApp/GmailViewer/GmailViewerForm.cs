using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GmailViewer.ImapDownloader;
using GmailViewer.GmailDownloader;
using GmailViewer.WhatsAppBackupDownloader;
using System.IO;

namespace GmailViewer
{
    internal enum AuthType
    {
        Api,
        Imap,
        GDrive
    }

    public partial class GmailViewerForm : Form
    {
        private readonly Dictionary<string, FolderType> stringToFolderType = new Dictionary<string, FolderType>()
        {
            { "Inbox", FolderType.Inbox },
            { "Trash", FolderType.Trash },
            { "All", FolderType.All },
            { "Drafts", FolderType.Drafts },
            { "Flagged", FolderType.Flagged },
            { "Important", FolderType.Important },
            { "Junk", FolderType.Junk },
            { "Sent", FolderType.Sent }
        };

        private IGmailDownloader gmail = new DummyDownloader();
        private SignInForm signInForm;
        private WhatsAppDownloader whatsapp;

        public GmailViewerForm()
        {
            InitializeComponent();
            signInForm = new SignInForm(this);
            folderComboBox.Items.AddRange(stringToFolderType.Keys.ToArray());
            folderComboBox.SelectedIndex = 0;
            emailAmountComboBox.SelectedIndex = 0;
            this.folderComboBox.SelectedIndexChanged += new System.EventHandler(this.FolderComboBoxSelectedIndexChanged);
            this.emailAmountComboBox.SelectedIndexChanged += new System.EventHandler(this.AmountEmailsComboBoxSelectedIndexChanged);
        }

        private void ShowEmails()
        {
            mailView.Focus();
            mailView.ClearEmails();
            try
            {
                List<Email> emailList = gmail.GetEmails(stringToFolderType[folderComboBox.Text], GetEmailsAmount());

                if (emailList == null)
                {
                    return;
                }
                foreach (Email email in emailList)
                {
                    mailView.Add(email);
                }
            }
            catch
            {
                connectionStatusTextBox.ForeColor = Color.Red;
                connectionStatusTextBox.Text = "can not download emals. maybe there is no internet connection";
            }
            downloadAllButton.Enabled = mailView.CountEmails > 0;
        }

        private void SignInButtonClick(object sender, EventArgs e)
        {
            Hide();
            signInForm.Show();
        }

        internal void TrySignIn(string login, string password, AuthType authType)
        {
            mailView.ClearEmails();

            try
            {
                switch (authType)
                {
                    case AuthType.Imap:
                        gmail = new Downloader();
                        break;
                    case AuthType.Api:
                        gmail = new ApiDownloader();
                        break;
                    case AuthType.GDrive:
                        whatsapp = new WhatsAppDownloader(login, password);
                        break;
                    default:
                        gmail = new DummyDownloader();
                        break;
                }

                loginTextBox.Text = login;
                downloadAllButton.Enabled = true;
                if (whatsapp == null)
                {
                    gmail.Connect(login, password);
                }
                connectionStatusTextBox.ForeColor = Color.Green;
                connectionStatusTextBox.Text = "Authentication success";
                signoutButton.Enabled = true;
            }
            catch (Exception exc)
            {
                connectionStatusTextBox.ForeColor = Color.Red;
                connectionStatusTextBox.Text = exc.Message;
                return;
            }
            if (whatsapp == null)
            {
                ShowEmails();
            }
            else
            {
                ShowBackups();
            }
        }

        private void MailViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            mailView.DisplayHtml(mailView.FocusedItem.Index);
        }

        private void MailView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SaveMenu.Show(mailView, e.Location);
            }
        }

        private void EMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMessage((ids, path) =>
                {
                    gmail.SaveAsEml(stringToFolderType[folderComboBox.Text], ids, path);
                });
        }

        private void SaveMessage(Action<int[], string> p)
        {
            var items = mailView.SelectedItems;
            var n = items.Count;
            var ids = new int[n];
            for (int i = 0; i < n; i++)
            {
                ids[i] = items[i].Index;
            }
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                p.Invoke(ids, dialog.SelectedPath);
            }
        }

        private void MSGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMessage((ids, path) =>
            {
                gmail.SaveAsMsg(stringToFolderType[folderComboBox.Text], ids, path);
            });
        }

        private void AmountEmailsComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            ShowEmails();
        }

        private void SignoutButton_Click(object sender, EventArgs e)
        {
            gmail.ReConnect();
            signoutButton.Enabled = false;
            mailView.ClearEmails();
            connectionStatusTextBox.Text = "";
            downloadAllButton.Enabled = false;
        }


        //TODO: 
        //Fix download atachment
        private void DownloadAllButton_Click(object sender, EventArgs e)
        {
            if (gmail == null)
                return;

            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                gmail.SaveAsEml(stringToFolderType[folderComboBox.Text], GetEmailsAmount(), dialog.SelectedPath);
            }
        }

        private int GetEmailsAmount()
        {
            return int.Parse(emailAmountComboBox.Text);
        }

        private void FolderComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            ShowEmails();
        }

        private void ShowBackups()
        {
            var files = whatsapp.Sync();
            foreach (var file in files)
            {
                GetItems(file);
            }
        }

        private void GetItems(String path)
        {
            if (System.IO.Directory.Exists(path))
            {
                string[] folders = System.IO.Directory.GetDirectories(path);
                string[] files = System.IO.Directory.GetFiles(path);
                foreach (string folder in folders)
                {
                    GetItems(folder);
                }
                foreach (string file in files)
                {
                    string[] ss = file.Split(new char[] { '\\' });
                    var atribute = new FileInfo(file);
                    var size = atribute.Length / 1024;
                    mailView.Items.Add(new ListViewItem(new[] { ss[ss.Length - 1], size.ToString() + " Kb", path }));
                }
            }
        }
    }
}
