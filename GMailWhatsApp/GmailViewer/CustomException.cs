using System;
using System.Runtime.Serialization;

namespace GmailViewer.ImapDownloader
{
    internal class ConnectionException : Exception
    {
        public ConnectionException()
        {
        }

        public ConnectionException(string message) : base(message)
        {
        }

        public ConnectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ConnectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    internal class AuthenticationException : Exception
    {

        public AuthenticationException()
        {
        }

        public AuthenticationException(string message) : base(message)
        {
        }

        public AuthenticationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AuthenticationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    internal class DownloadException : Exception
    {
        public DownloadException()
        {
        }

        public DownloadException(string message) : base(message)
        {
        }

        public DownloadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DownloadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
    internal class SaveException : Exception
    {
        public SaveException()
        {
        }

        public SaveException(string message) : base(message)
        {
        }

        public SaveException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SaveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
