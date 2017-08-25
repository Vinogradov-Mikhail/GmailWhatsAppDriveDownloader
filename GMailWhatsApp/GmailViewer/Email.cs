using System;
using System.Collections.Generic;
using System.IO;

namespace GmailViewer
{
    public enum MessageState
    {
        Read,
        Unread,
        Send,
        None
    };

    public abstract class Email
    {
        public User Sender { get; protected set; }
        public List<User> Recipient { get; protected set; }
        public string Subject { get; protected set; }
        public string Message { get; protected set; }
        public string Html { get; protected set; }
        public DateTime? Date { get; protected set; }
        public MessageState State { get; protected set; }
        public List<FileStream> Atachments { get; protected set; }
    }
}