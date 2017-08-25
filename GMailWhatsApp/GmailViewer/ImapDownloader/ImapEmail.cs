using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GmailViewer.ImapDownloader
{
    public class ImapEmail : Email
    {
        private readonly ImapX.Message _msg;
        private readonly bool _isAtachments;

        public ImapEmail(ImapX.Message msg, bool isAtachments)
        {
            _msg = msg;
            _isAtachments = isAtachments;
            FillContent();
        }

        private void FillContent()
        {
            if(_msg.From != null)
            Sender = new User(_msg.From.DisplayName, _msg.From.Address);
            // TODO: 
            // add more To, Bcc, Cc      
            Recipient = new List<User>();
            if(_msg.To.Count > 0)
                for (int i = 0; i < _msg.To.Count; i++)
                {
                    if(_msg.To[i] != null)
                    Recipient.Add(new User(_msg.To[i].DisplayName, _msg.To[i].Address));
                }            
            Subject = _msg.Subject;
            Message = _msg.Body.Text;
            Html = _msg.Body.Html;
            Date = _msg.Date;
            State = _msg.Seen ? MessageState.Read : MessageState.Unread;
            if (_isAtachments)
            {
                var n = _msg.Attachments.Length;
                Atachments = new List<FileStream>(n);
                for (int i = 0; i < n; i++)
                {
                    _msg.Attachments[i].Download();
                    var folder = Path.GetTempPath();
                    var fileName = _msg.Attachments[i].FileName;
                    var path = Path.Combine(folder, fileName);
                    if (!File.Exists(path))
                        _msg.Attachments[i].Save(folder, fileName);
                    Atachments.Add(File.Open(path, FileMode.Open, FileAccess.Read));
                } 
            }
        }

        public void AtachmentsDispose()
        {
            foreach (var atach in Atachments)
            {
                atach.Dispose();
            }
        }
    }
}
