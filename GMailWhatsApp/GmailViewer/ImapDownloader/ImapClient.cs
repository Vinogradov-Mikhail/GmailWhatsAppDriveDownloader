using System;
using System.Collections.Generic;
using System.IO;
using ImapX;

namespace GmailViewer.ImapDownloader
{
    class ImapClient
    {
        //public enum FolderName
        //{
        //    INBOX,
        //    TRASH
        //}

        private readonly ImapX.ImapClient _client;
        //public FolderName CurrentFolder { get; set; }

        public ImapClient(string host, bool useSsl)
        {
            _client = new ImapX.ImapClient(host, useSsl);
            if (!_client.Connect())
            {
                // connection not successful
                throw new ConnectionException("Connection not succeessful");
            }
        }

        internal List<Email> GetEmails(FolderType folder, long amount, ImapX.Enums.MessageFetchMode mode)
        {
            
            var messages = DownloadMessages(folder, ref amount, mode);
            var emails = new List<Email>();
            for (int i = 0; i < amount; i++)
            {
                emails.Add(GetEmail(messages, i, mode));
            }
            return emails;
        }



        internal void SaveIdsInEml(FolderType emailFolder, int[] ids, string folderPath, ImapX.Enums.MessageFetchMode mode)
        {
            var id = (long)ids[ids.Length - 1];
            var messages = DownloadMessages(emailFolder, ref id, mode);
            Directory.CreateDirectory(folderPath);
            foreach (var i in ids)
            {
                var filePath = Path.Combine(folderPath, Path.GetRandomFileName() + ".eml");
                SaveInEml(messages, i, filePath, mode);
            }
        }

        internal void SaveAllInEml(FolderType emailFolder, long amount, string folderPath, ImapX.Enums.MessageFetchMode mode)
        {
            var messages = DownloadMessages(emailFolder, ref amount, mode);
            Directory.CreateDirectory(folderPath);
            //foreach (var msg in messages)
            //{
            //    var filePath = Path.Combine(folderPath, Path.GetRandomFileName() + ".eml");
            //    msg.Save(folderPath);
            //}
            for (int i = 0; i < amount; i++)
            {
                var filePath = Path.Combine(folderPath, Path.GetRandomFileName() + ".eml");
                SaveInEml(messages, i, filePath, mode);
            }
        }

        private ImapX.Collections.MessageCollection DownloadMessages(FolderType emailFolder, ref long amount, ImapX.Enums.MessageFetchMode mode)
        {
            ImapX.Folder folder;
            switch (emailFolder)
            {
                case FolderType.All:
                    folder = _client.Folders.All;
                    break;
                case FolderType.Inbox:
                    folder = _client.Folders.Inbox;
                    break;
                case FolderType.Trash:
                    folder = _client.Folders.Trash;
                    break;
                case FolderType.Drafts:
                    folder = _client.Folders.Drafts;
                    break;
                case FolderType.Flagged:
                    folder = _client.Folders.Flagged;
                    break;
                case FolderType.Important:
                    folder = _client.Folders.Important;
                    break;
                case FolderType.Junk:
                    folder = _client.Folders.Junk;
                    break;
                case FolderType.Sent:
                    folder = _client.Folders.Sent;
                    break;
                default:
                    throw new DownloadException("Download failed.");
            }
            var messages = folder.Messages;            
            var n = folder.Exists;
            if (n < amount)
            {
                messages.Download("ALL", mode);
                amount = n;
            }
            else if(amount < Int32.MaxValue)
                messages.Download("ALL", mode, (int)amount);            
            return messages;
        }

        private static void SaveInEml(ImapX.Collections.MessageCollection messages, int id, string filePath, ImapX.Enums.MessageFetchMode mode)
        {
            GetMessage(messages, id, mode).Save(filePath);
        }

        public void Connect(string login, string password)
        {
            if (_client.IsConnected)
            {
                // connection successful
                if (!_client.Login(login, password))
                {
                    // login not successful
                    throw new AuthenticationException("Invalid login or password");                    
                }                
            }
            else
            {
                // connection not successful
                throw new ConnectionException("Connection is lost");
            }
        }

        
        
        internal Email GetEmail(ImapX.Collections.MessageCollection messages, int id, ImapX.Enums.MessageFetchMode mode)
        {            
            var email = new ImapEmail(GetMessage(messages, id, mode), mode == ImapX.Enums.MessageFetchMode.Full ? true : false);                
            
            return email;
        }

        //private Email GetEmail(Message msg)
        //{
        //    if (!msg.Download())
        //        throw new DownloadException("Incorrect message id");
        //    return new ImapEmail(msg, mode == ImapX.Enums.MessageFetchMode.Full ? true : false);
        //}


        private static ImapX.Message GetMessage(ImapX.Collections.MessageCollection messages, int id, ImapX.Enums.MessageFetchMode mode)
        {                        
            var msg = messages[id];            
            if (!msg.Download(mode))
                throw new DownloadException("Incorrect message id");
            return msg;
        }
    }
}
