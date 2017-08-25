using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GmailViewer;

namespace GmailViewer
{
    public class MailView : ListView
    {
        private List<Email> emailsList = new List<Email>();

        public int CountEmails
        {
            get
            {
                return emailsList.Count;
            }
        }

        public MailView()
        {
        }

        public void Add(Email email)
        {
            emailsList.Add(email);

            Items.Add(new ListViewItem(new[] {
                email.Sender.ToString(),
                email.Subject,
                CreateRecipientString(email.Recipient),
                email.Message,
                email.Html,
                email.Date.ToString(),
                email.State.ToString()
                }));
        }

        public void DisplayHtml(int index)
        {
            if (index >= emailsList.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Номер письма вне границ допустимого диапозона");
            }

            Email email = emailsList[index];
            (new EmailInfoForm(email.Sender.ToString(), CreateRecipientString(email.Recipient), email.Message, email.Html)).Show();
        }

        private string CreateRecipientString(List<User> recipientList)
        {
            StringBuilder answer = new StringBuilder();

            for (int i = 0; i < recipientList.Count; i++)
            {
                answer.Append(recipientList[i].ToString());
                if (i < recipientList.Count - 1)
                {
                    answer.Append(", ");
                }
            }

            return answer.ToString();
        }

        public void ClearEmails()
        {
            emailsList.Clear();
            Items.Clear();
        }
    }
}
