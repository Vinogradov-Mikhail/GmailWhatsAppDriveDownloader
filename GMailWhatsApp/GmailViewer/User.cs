using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailViewer
{
    public struct User
    {
        public readonly string Name;
        public readonly string EmailAddress;

        public User(string name, string emailAddress)
        {
            Name = name;
            EmailAddress = emailAddress;
        }

        public override string ToString()
        {
            if (Name == string.Empty)
            {
                return EmailAddress;
            }
            else
            {
                return string.Format("{0} <{1}>", Name, EmailAddress);
            }
        }
    }
}
