using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailViewer
{
    public enum FolderType
    {
        All,
        Inbox,
        Trash,
        Drafts,
        Flagged,
        Important,
        Junk,
        Sent
    }


    public interface IGmailDownloader
    {
        void Connect(string login, string password);
        void ReConnect();
        List<Email> GetEmails(FolderType emailFolder, int amount);
        void SaveAsEml(FolderType emailFolder, int amount, string folderPath);
        void SaveAsMsg(FolderType emailFolder, int amount, string folderPath);
        void SaveAsEml(FolderType emailFolder, int[] ids, string folderPath);
        void SaveAsMsg(FolderType emailFolder, int[] ids, string folderPath);
    }
}
