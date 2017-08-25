using DankMemes.GPSOAuthSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GmailViewer.WhatsAppBackupDownloader
{
    internal class AccessTokenGetter
    {
        private static string email;
        private static string password;
        private static string deviceId = "0000000000000000";

        public static string GetBearer(string email, string password)
        {
            AccessTokenGetter.email = email;
            AccessTokenGetter.password = password;
            return GetTokenFromUrl(GetDriveToken());
        }

        private static string GetTokenFromUrl(string url)
        {
            return Regex.Match(url, @"Auth=([\w|\W]+)\nissueAdvice").Groups[1].Value;
        }

        private static string PostToGoogle(string url, NameValueCollection postData)
        {

            using (WebClient client = new WebClient())
            {
                byte[] response = client.UploadValues(url, postData);
                return Encoding.UTF8.GetString(response);
            }
        }

        private static string GetMasterToken()
        {
            var client = new GPSOAuthClient(email, password);
            var googleClient = client.PerformMasterLogin();
            var key = "";
            if (googleClient != null)
            {
                key = googleClient["Token"];
            }
            return key;
        }

        private static string GetDriveToken()
        {
            var token = GetMasterToken();
            var postData = new NameValueCollection
            {
                {"Token", token },
                {"app", "com.whatsapp" },
                {"client_sig", "38a0f7d505fe18fec64fbf343ecaaaf310dbd799" },
                {"device", deviceId },
                {"google_play_services_version", "9877000" },
                {"service", "oauth2:https://www.googleapis.com/auth/drive.appdata https://www.googleapis.com/auth/drive.file" },
                {"has_permission", "1" }
            };
            return PostToGoogle("https://android.clients.google.com/auth", postData);
        }
    }
}
