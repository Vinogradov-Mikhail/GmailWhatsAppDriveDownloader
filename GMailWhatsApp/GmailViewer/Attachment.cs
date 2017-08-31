using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailViewer.GoogleApiDownloader
{
    class Attachment
    {
        public string namestr;

        public byte[] name;

        public string mimeType;

        public string path;

        public Attachment(string names, string pathTo, byte[] name, string type)
        {
            this.namestr = names;
            this.name = name;
            this.mimeType = type;
            this.path = pathTo;
        }
    }
}
