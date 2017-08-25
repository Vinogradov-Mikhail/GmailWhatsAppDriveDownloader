using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Gmail.v1.Data;
using GmailDownloader;

namespace GmailViewer.GmailDownloader
{
    class ApiEmail : GmailViewer.Email
    {
        public Message message;

        public ApiEmail(Message message)
        {
            this.message = message;
            FillContent();
        }

        private void FillContent()
        {
            var senderParam = new string[3];
            var sender = ApiClient.GetEmailMetadata(message, "From");
            if (sender.Contains("<"))
            {
                senderParam = sender.Split('<');
                Sender = new GmailViewer.User(senderParam[0], senderParam[1]);
            }
            else
            {
                Sender = new GmailViewer.User("", sender);
            }
            List<User> to = new List<User>();
            var tostr = ApiClient.GetEmailMetadata(message, "To");
            var toParam = new string[3];
            if (tostr.Contains("<"))
            {
                toParam = tostr.Split('<');
                to.Add(new GmailViewer.User(toParam[0], toParam[1]));
            }
            else
            {
                to.Add(new GmailViewer.User("", tostr));
            }
            Recipient = to;
            Subject = ApiClient.GetEmailMetadata(message, "Subject");
            Message = ApiClient.GetEmailBodyText(message);
            Html = ApiClient.GetEmailHtmlBody(message);
            var date = ApiClient.GetEmailMetadata(message, "Date");
            var dateFormat = date.Split('(');
            Date = DateTime.Parse(dateFormat[0]);
            if (ApiClient.GetLabelsInfo(message, "UNREAD"))
            {
                State = GmailViewer.MessageState.Unread;
            }
            else
            {
                State = GmailViewer.MessageState.Read;
            }
        }
    }
}
