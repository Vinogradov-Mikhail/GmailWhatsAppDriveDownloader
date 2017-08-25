using GmailDownloader;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GmailViewer.GmailDownloader
{
    class ApiDownloader : IGmailDownloader
    {
        /// <summary>
        /// OAuth 2 creditional
        /// </summary>
        private UserCredential credential;

        /// <summary>
        /// gmail api service
        /// </summary>
        private GmailService service;

        /// <summary>
        /// get message request
        /// </summary>
        private UsersResource.MessagesResource.ListRequest request;

        /// <summary>
        /// show users message
        /// </summary>
        /// <param name="service"></param>
        /// <param name="request"></param>
        public List<Email> ShowUserMessage(GmailService service, string emailFolder, UsersResource.MessagesResource.ListRequest request, int amount)
        {
            request.LabelIds = emailFolder;
            request.MaxResults = amount;         
            IList<Message> messages = request.Execute().Messages;
            List<Email> emailList = new List<Email>();
            if (messages != null && messages.Count > 0)
            {
                Parallel.ForEach(messages, (sms) =>
                {
                    var message = ApiClient.GetMessage(service, "me", sms.Id);
                    var email = new ApiEmail(message);
                    emailList.Add(email);
                    //ApiClient.GetAttachments(service, message, "me", sms.Id, true);
                });
            }
            return emailList;
        }
        public void Connect(string login, string password)
        {
            credential = GoogleAuth.AuthenticateJsonFile();
            service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GmailDownload",
            });
            request = service.Users.Messages.List("me");
        }

        public List<Email> GetEmails(string emailfolder, int amount)
        {
            return ShowUserMessage(service, emailfolder, request, amount);
        }

        public void SaveAsType(FolderType emailFolder, int[] ids, string folderPath, string type)
        {
            request.LabelIds = emailFolder.ToString("f").ToUpper();
            request.MaxResults = ids[ids.Length - 1] + 1;
            IList<Message> messages = request.Execute().Messages;
            if (messages != null && messages.Count > 0)
            {
                int j = 0;
                Parallel.For(0, messages.Count, i => 
                {
                    if (i == ids[j])
                    {
                        ++j;
                        var message = ApiClient.GetMessage(service, "me", messages[i].Id);
                        var email = new ApiEmail(message);
                        var attac = ApiClient.GetAttachments(service, message, "me", messages[i].Id, false);
                        switch (type)
                        {
                            case ".eml":
                                ApiClient.ConverteToEml(email, attac, folderPath);
                                break;
                            case ".msg":
                                ApiClient.ConverteToMsg(email, attac, folderPath);
                                break;
                        }
                    }
                });
            }
        }

        public void SaveAsType(FolderType emailFolder, int amount, string folderPath, string type)
        {
            request.LabelIds = emailFolder.ToString("f").ToUpper();
            request.MaxResults = amount;
            IList<Message> messages = request.Execute().Messages;
            if (messages != null && messages.Count > 0)
            {
                Parallel.ForEach(messages, (sms) =>
                {
                    var message = ApiClient.GetMessage(service, "me", sms.Id);
                    var email = new ApiEmail(message);
                    var attac = ApiClient.GetAttachments(service, message, "me", sms.Id, false);
                    switch (type)
                    {
                        case ".eml":
                            ApiClient.ConverteToEml(email, attac, folderPath);
                            break;
                        case ".msg":
                            ApiClient.ConverteToMsg(email, attac, folderPath);
                            break;
                    }                    
                });
            }
        }

        public void SaveAsEml(FolderType emailFolder, int[] ids, string folderPath)
        {
            SaveAsType(emailFolder, ids, folderPath, ".eml");
        }

        public void SaveAsMsg(FolderType emailFolder, int amount, string folderPath)
        {
            SaveAsType(emailFolder, amount, folderPath, ".msg");
        }

        public void SaveAsEml(FolderType emailFolder, int amount, string folderPath)
        {
            SaveAsType(emailFolder, amount, folderPath, ".eml");
        }

        public void SaveAsMsg(FolderType emailFolder, int[] ids, string folderPath)
        {
            SaveAsType(emailFolder, ids, folderPath, ".msg");
        }

        public void ReConnect()
        {
            credential.RevokeTokenAsync(CancellationToken.None);
            Connect("", "");
        }

        public List<Email> GetEmails(FolderType emailFolder, int amount)
        {
            return ShowUserMessage(service, emailFolder.ToString().ToUpper(), request, amount);
        }
    }
}