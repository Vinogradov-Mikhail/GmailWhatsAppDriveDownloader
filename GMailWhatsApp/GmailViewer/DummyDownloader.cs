using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GmailViewer;

namespace GmailViewer
{
    public class DummyDownloader : IGmailDownloader
    {
        private readonly bool connectionEnable;

        public DummyDownloader(bool connectionEnable = true)
        {
            this.connectionEnable = connectionEnable;
        }

        public void Connect(string login, string password)
        {
            if (!connectionEnable)
            {
                throw new Exception();
            }
        }

        public List<Email> GetEmails(string folder, int amount)
        {
            return new List<Email>();
        }

        public void SaveAsMsg(FolderType emailFolder, int amount, string folderPath)
        {
        }

        public void SaveAsEml(FolderType emailFolder, int amount, string folderPath)
        {
        }

        public void SaveAsEml(FolderType emailFolder, int[] ids, string folderPath)
        {
        }

        public void SaveAsMsg(FolderType emailFolder, int[] ids, string folderPath)
        {
        }

        public void ReConnect()
        {
        }

        public List<Email> GetEmails(FolderType emailFolder, int amount)
        {
            return new List<Email>();
        }
    }
}
