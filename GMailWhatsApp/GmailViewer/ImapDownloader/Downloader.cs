using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GmailViewer.ImapDownloader
{
    class Downloader : IGmailDownloader
    {
        private readonly ImapClient _client;

        public Downloader()
        {
            _client = new ImapClient("imap.gmail.com", true);
        }

        public void Connect(string login, string password)
        {
            _client.Connect(login, password);
        }

        public List<Email> GetEmails(FolderType folder, int amount)
        {
            return _client.GetEmails(folder, amount, ImapX.Enums.MessageFetchMode.Tiny);
        }        

        public void SaveAsEml(FolderType emailFolder, int amount, string folderPath)
        {
            _client.SaveAllInEml(emailFolder, amount, folderPath, ImapX.Enums.MessageFetchMode.Full);
        }

        public void SaveAsEml(FolderType emailFolder, int[] ids, string folderPath)
        {
            _client.SaveIdsInEml(emailFolder, ids, folderPath, ImapX.Enums.MessageFetchMode.Full);
        }

        public void SaveAsMsg(FolderType emailFolder, int amount, string folderPath)
        {
            var messages = _client.GetEmails(emailFolder, amount, ImapX.Enums.MessageFetchMode.Full);
            SaveAsMsg(folderPath, messages);
        }

        private static void SaveAsMsg(string folderPath, List<Email> messages)
        {
            foreach (var msg in messages)
            {
                var email = new MsgKit.Email(new MsgKit.Sender(msg.Sender.EmailAddress, msg.Sender.Name), msg.Subject)
                {
                    BodyHtml = msg.Html,
                    BodyText = msg.Message,
                    SentOn = msg.Date,
                };
                User rec;
                for (int i = 0; i < msg.Recipient.Count; i++)
                {
                    rec = msg.Recipient[i];
                    email.Recipients.AddTo(rec.EmailAddress, rec.Name);
                }

                switch (msg.State)
                {
                    case MessageState.Read:
                        email.IconIndex = MsgKit.Enums.MessageIconIndex.ReadMail;
                        break;
                    case MessageState.Unread:
                        email.IconIndex = MsgKit.Enums.MessageIconIndex.NewMail;
                        break;
                    case MessageState.Send:
                        email.IconIndex = MsgKit.Enums.MessageIconIndex.ForwardedMail;
                        break;
                    case MessageState.None:
                        break;
                }
                string filePath;
                foreach (var msgAtachment in msg.Atachments)
                {
                    filePath = msgAtachment.Name;
                    email.Attachments.Add(msgAtachment, Path.GetFileName(filePath));
                }
                using (var file = File.Open(Path.Combine(folderPath, Path.GetRandomFileName() + ".msg"), FileMode.CreateNew, FileAccess.Write))
                    email.Save(file);
            }
        }

        public void SaveAsMsg(FolderType emailFolder, int[] ids, string folderPath)
        {
            var messages = _client.GetEmails(emailFolder, ids[ids.Length - 1] + 1, ImapX.Enums.MessageFetchMode.Full);
            var n = ids.Length;
            var filteredMessages = new List<Email>(n);
            foreach (int i in ids)
            {
                filteredMessages.Add(messages[i]);
            }

            SaveAsMsg(folderPath, filteredMessages);
        }

        public void ReConnect()
        {            
        }
    }
}
