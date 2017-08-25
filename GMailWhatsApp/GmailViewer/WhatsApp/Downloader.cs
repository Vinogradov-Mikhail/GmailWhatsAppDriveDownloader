using DankMemes.GPSOAuthSharp;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GmailViewer.WhatsAppBackupDownloader
{
    public class WhatsAppDownloader
    {
        private string email;
        private string password;
        public string bearer = "";

        public WhatsAppDownloader(string email, string password)
        {
            this.email = email;
            this.password = password;
            bearer = AccessTokenGetter.GetBearer(email, password);
        }               
        
        private Dictionary<string, string> GDriveFileMap()
        {
            var data = RawGoogleDriveRequest(bearer, "https://www.googleapis.com/drive/v2/files");
            var jres = JObject.Parse(data);

            var items = jres["items"];
            var backups = new Dictionary<string, string>();
            foreach (var result in items)
            {
                if (result["title"].ToString() == "gdrive_file_map")
                {
                    backups.Add(result["description"].ToString(), RawGoogleDriveRequest(bearer, result["downloadUrl"].ToString()));
                }
            }
            return backups;
        }
       
        private string RawGoogleDriveRequest(string bearer, string url)
        {
            var nvc = new NameValueCollection
            {
                { "Authorization", "Bearer " + bearer }
            };
            using (WebClient client = new WebClient())
            {
                client.Headers.Add(nvc);
                byte[] response = client.DownloadData(url);
                return Encoding.UTF8.GetString(response);
            }
        }

        public List<string> Sync()
        {            
            var drives = GDriveFileMap();
            int i = 0;
            var folder = "WhatsApp";
            var folders = new List<string>(drives.Count);
            foreach (var drive in drives)
            {                
                if (drives.Count > 1)
                {
                    folder = "WhatsApp-" + i;
                }
                folders.Add(Path.GetFullPath(folder));
                GetMultipleFiles(drive.Value, folder); 
                i++;
            }
            return folders;
        }

        private void GetMultipleFiles(string data, string folder)
        {
            var jres = JToken.Parse(data);          
            foreach (var entries in jres)
            {
                var local = folder + Path.DirectorySeparatorChar + entries["f"].ToString().Replace('/', Path.DirectorySeparatorChar);
                DownloadFileGoogleDrive($"https://www.googleapis.com/drive/v2/files/{entries["r"].ToString()}?alt=media", local);
            }
        }

        private void DownloadFileGoogleDrive(string url, string local)
        {
            var dir = Path.GetDirectoryName(local);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            if (File.Exists(local))
            {
                File.Delete(local);
            }
            var header = new NameValueCollection
            {
                { "Authorization", "Bearer " + bearer}
            };
            using (var client = new WebClient())
            {
                client.Headers.Add(header);
                client.DownloadFile(url, local);
            }

        }        
    }
}
