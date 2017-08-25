using Google.Apis.Gmail.v1;
using LumiSoft.Net.Mime;
using LumiSoft.Net;
using System;
using System.Text;
using GmailViewer.GmailDownloader;
using Google.Apis.Gmail.v1.Data;
using System.Collections.Generic;
using System.IO;
using GmailViewer.GoogleApiDownloader;
using GmailViewer.ImapDownloader;
using GmailViewer;

namespace GmailDownloader
{
    class ApiClient
    {
        public static Message GetMessage(GmailService service, String userId, String messageId)
        {
            try
            {
                return service.Users.Messages.Get(userId, messageId).Execute();
            }
            catch (Exception e)
            {
                throw new DownloadException("An error occurred: " + e.Message);
            }
        }

        public static MessagePartBody GetAttachment(GmailService service, String userId, String messageId, string attId)
        {
            try
            {
                return service.Users.Messages.Attachments.Get(userId, messageId, attId).Execute(); 
            }
            catch (Exception e)
            {
                throw new DownloadException("An error occurred: " + e.Message);
            }
        }

        /// <summary>
        /// get information from headers in message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetEmailMetadata(Message message, string type)
        {
            var headers = message.Payload.Headers;
            for (int i = 0; i < headers.Count; ++i)
            {
                if (headers[i].Name == type)
                {
                    return headers[i].Value;
                }
            }
            return "";
        }

        public static byte[] ConverteBase64Google(string bcs)
        {
            var converteText = bcs.Replace("-", "+").Replace("_", "/");
            return Convert.FromBase64String(converteText);
        }

        /// <summary>
        /// converete Bsc64 to Utf8
        /// </summary>
        /// <param name="bcs"></param>
        /// <returns></returns>
        public static string ConverteToUTFGoogle(string bcs)
        {
            return Encoding.UTF8.GetString(ConverteBase64Google(bcs));
        }

        /// <summary>
        /// get html part of message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string GetEmailHtmlBody(Message message)
        {
            string mimeType = message.Payload.MimeType;
            string html = "";
            switch (mimeType)
            {
                case "multipart/alternative":
                    var parts = message.Payload.Parts;
                    foreach (var part in parts)
                    {
                        if (part.MimeType == "text/html")
                        {
                            html = ConverteToUTFGoogle(part.Body.Data);
                        }
                    }
                    break;
                case "text/html":
                    html = ConverteToUTFGoogle(message.Payload.Body.Data);                  
                    break;
                case "multipart/mixed":
                    var partss = message.Payload.Parts;
                    foreach (var part in partss)
                    {
                        if (part.MimeType == "text/html" && part.Body.Data != null)
                        {
                            html = ConverteToUTFGoogle(part.Body.Data);
                        }
                        else
                        {
                            if (part.MimeType == "multipart/alternative")
                            {
                                html = ConverteToUTFGoogle(part.Parts[0].Body.Data);
                            }
                        }
                    }
                    break;
                default :
                    html = "";
                    break;
            }
            return html;
        }

        /// <summary>
        /// get body of our message
        /// </summary>
        /// <param name="service"></param>
        /// <param name="request"></param>
        public static string GetEmailBodyText(Message message)
        {
            string mimeType = message.Payload.MimeType;
            string meesageText = "";
            switch (mimeType)
            {
                case "text/plain":
                    meesageText = ConverteToUTFGoogle(message.Payload.Body.Data);
                    break;
                case "multipart/alternative":
                    var parts = message.Payload.Parts;
                    foreach (var part in parts)
                    {
                        if (part.MimeType != "text/html")
                        {
                            meesageText = ConverteToUTFGoogle(part.Body.Data);
                        }
                    }                    
                    break;
                case "multipart/mixed":
                    meesageText = "Click to open mixed";
                    break;
                case "text/html":
                    meesageText = "Click to open";                 
                    break;
            }
            return meesageText;
        }

        /// <summary>
        /// get information about message labels
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool GetLabelsInfo(Message message, string type)
        {
            foreach (var label in message.LabelIds)
            {
                if (label == type)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// get attachments from message
        /// </summary>
        /// <param name="service"></param>
        /// <param name="userId"></param>
        /// <param name="messageId"></param>
        /// <param name="outputDir"></param>
        public static List<Attachment> GetAttachments(GmailService service, Message message, String userId, String messageId, bool save)
        {
            List<Attachment> attac = new List<Attachment>();
            IList<MessagePart> parts = message.Payload.Parts;
            if (parts != null)
            {
                foreach (MessagePart part in parts)
                {
                    if (!String.IsNullOrEmpty(part.Filename))
                    {
                        String attId = part.Body.AttachmentId;
                        MessagePartBody attachPart = service.Users.Messages.Attachments.Get(userId, messageId, attId).Execute();
                        var converte = ConverteBase64Google(attachPart.Data);
                        if (save)
                        {
                            File.WriteAllBytes(Path.Combine("C:\\GmailViewer", part.Filename), converte);
                        }
                        var attachment = new Attachment(part.Filename, converte, part.MimeType);
                        attac.Add(attachment);
                    }
                }
            }
            return attac;
        }

        /// <summary>
        /// converte message to eml format
        /// </summary>
        /// <param name="email"></param>
        public static void ConverteToEml(ApiEmail email, List<Attachment> attac, string folderPath)
        {
            Mime emlmes = new Mime();
            MimeEntity mainEntity = emlmes.MainEntity;
            mainEntity.From = new AddressList();
            mainEntity.From.Add(new MailboxAddress(email.Sender.Name, email.Sender.EmailAddress));
            mainEntity.To = new AddressList();
            mainEntity.To.Add(new MailboxAddress(email.Recipient[0].Name, email.Recipient[0].EmailAddress));
            mainEntity.Subject = email.Subject;
            mainEntity.ContentType = MediaType_enum.Multipart_mixed;
            mainEntity.ContentTransferEncoding = ContentTransferEncoding_enum.QuotedPrintable; 

            MimeEntity textEntity = mainEntity.ChildEntities.Add();
            textEntity.ContentType = MediaType_enum.Text_plain;
            textEntity.ContentTransferEncoding = ContentTransferEncoding_enum.QuotedPrintable;
            textEntity.DataText = email.Message;

            MimeEntity htmlEntity = mainEntity.ChildEntities.Add();
            htmlEntity.ContentType = MediaType_enum.Text_html;
            htmlEntity.ContentTransferEncoding = ContentTransferEncoding_enum.QuotedPrintable;
            htmlEntity.DataText = email.Html;

            mainEntity.Date = email.Date.Value;
            mainEntity.MessageID = GetEmailMetadata(email.message, "Message-ID");
            mainEntity.MimeVersion = GetEmailMetadata(email.message, "MIME-Version");
            if (attac.Count != 0)
            {
                MimeEntity attachmentEntity = mainEntity.ChildEntities.Add();
                attachmentEntity.ContentTypeString = attac[0].mimeType;
                attachmentEntity.ContentTransferEncoding = ContentTransferEncoding_enum.QuotedPrintable;
                attachmentEntity.Data = attac[0].name;
            }
            emlmes.ToFile(folderPath + "\\" + email.message.Id + ".eml");
        }

        public static void ConverteToMsg(ApiEmail emails, List<Attachment> attac, string folderPath)
        {
            var email = new MsgKit.Email(new MsgKit.Sender(emails.Sender.EmailAddress, emails.Sender.Name), emails.Subject)
            {
                BodyHtml = emails.Html,
                BodyText = emails.Message,
                SentOn = emails.Date,
            };
            User rec;
            for (int i = 0; i < emails.Recipient.Count; i++)
            {
                rec = emails.Recipient[i];
                email.Recipients.AddTo(rec.EmailAddress, rec.Name);
            }

            switch (emails.State)
            {
                case MessageState.Read:
                    email.IconIndex = MsgKit.Enums.MessageIconIndex.ReadMail;
                    break;
                case MessageState.Unread:
                    email.IconIndex = MsgKit.Enums.MessageIconIndex.NewMail;
                    break;
                case MessageState.Send:
                    email.IconIndex = MsgKit.Enums.MessageIconIndex.ForwardedMail;
                    break;
                case MessageState.None:
                    break;
            }
            //string filePath;
            //foreach (var msgAtachment in attac)
            //{
            //    filePath = msgAtachment.name;
            //    email.Attachments.Add(msgAtachment.namestr, Path.GetFileName(filePath));
            //}
            using (var file = File.Open(Path.Combine(folderPath, Path.GetRandomFileName() + ".msg"), FileMode.CreateNew, FileAccess.Write))
                email.Save(file);
        }
    }
}
