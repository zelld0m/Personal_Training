using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mail;
using System.IO;

namespace ElectronicInvoicing
{
    class EmailUtility
    {
        private Utility u = new Utility();
        private string strLogFileName = Environment.CurrentDirectory + "\\LogFile_" + DateTime.Now.ToString("MMddyyyy") + ".txt";

        #region SendEmail
        /// <summary>
        /// Send Email
        /// </summary>
        /// <param name="EmailFrom">Sender</param>
        /// <param name="EmailTo">Recepient</param>
        /// <param name="strSubject">Subject</param>
        /// <param name="strBody">Body Message</param>
        /// <param name="strAttachmentDirectory">Path where attachement located if not single attachedment</param>
        /// <param name="strLogFileName">Log filename</param>
        public void SendMail(string EmailFrom, string EmailTo, string EmailCC, string EmailBCC, string strSubject, string strBody, string strAttachmentDirectory, string strLogFileName, bool blnSingleAttachment)
        {
            try
            {
                Console.Write("Sending..." + "\r\n");
                u.CreateStreamWriterFile(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + "\t" + "\t" + "Sending...", strLogFileName);

                
                MailMessage Mailer = new MailMessage();
                Mailer.From = EmailFrom;
                Mailer.To = EmailTo;
                if (EmailCC.Length > 0)
                {
                    Mailer.Cc = EmailCC;
                }

                if (EmailBCC.Length > 0)
                {
                    Mailer.Bcc = EmailBCC;
                }

                Mailer.Subject = strSubject;
                Mailer.Body = strBody.ToString();
                Mailer.BodyFormat = MailFormat.Text;
                Mailer.Priority = MailPriority.High;
                Mailer.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

                if (strAttachmentDirectory.Length > 0)
                {
                    if (!blnSingleAttachment)
                    {
                        DirectoryInfo dir = new DirectoryInfo(strAttachmentDirectory);
                        FileInfo[] filesInDir = dir.GetFiles();

                        foreach (FileInfo file in filesInDir)
                        {
               //origin   //Mailer.Attachments.Add(new System.Web.Mail.MailAttachment(strAttachmentDirectory + file.Name));
                            Mailer.Attachments.Add(new System.Net.Mail.Attachment(strAttachmentDirectory + file.Name));
                            Console.Write("Attachment File...." + "\t" + "\t" + strAttachmentDirectory + file.Name + "\r\n");
                            u.CreateStreamWriterFile(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + "\t" + "\t" + "Attachment File...." + "\t" + "\t" + strAttachmentDirectory + file.Name, strLogFileName);
                        }
                    }
                    else
                    {
             //origin //Mailer.Attachments.Add(new System.Web.Mail.MailAttachment(strAttachmentDirectory));
                        Mailer.Attachments.Add(new System.Net.Mail.Attachment(strAttachmentDirectory));
                        Console.Write("Attachment File...." + "\t" + "\t" + strAttachmentDirectory + "\r\n");
                        u.CreateStreamWriterFile(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + "\t" + "\t" + "Attachment File...." + "\t" + "\t" + strAttachmentDirectory, strLogFileName);
                    }
                }

                SmtpMail.SmtpServer = "Mailrelay.cc-inc.com";
                SmtpMail.Send(Mailer);
                Console.Write("Email with attachement successfully sent...." + "\r\n");
                u.CreateStreamWriterFile(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + "\t" + "\t" + "Email with attachement successfully sent...", strLogFileName);
            }

            catch (System.SystemException exp)
            {
                u.CreateStreamWriterFile(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + "\t" + "\t" + exp.Message.ToString(), strLogFileName);
            }
        }

        public void SendErrorMail(string EmailFrom, string EmailTo, string EmailCC, string EmailBCC, string strSubject, string strBody, string strAttachmentDirectory, string strLogFileName, bool blnSingleAttachment)
        {
            try
            {
                //added by Gilbert 3/21/2011
                string strCompany = System.Configuration.ConfigurationManager.AppSettings["companyName"].ToString();
                string url = System.Configuration.ConfigurationManager.AppSettings["PostURL"].ToString();
                if (strBody.Contains("503") || strBody.Contains("Unable to connect"))
                {
                    string str = string.Format("Cannot connect to {0}'s listening URL for electronic invoicing" + Environment.NewLine +
                    "{1}. Please notify {0}." + Environment.NewLine + Environment.NewLine + "Stack Trace:" + Environment.NewLine + strBody.ToString(), strCompany, url);
                    strBody = str;
                }
                //end add
                Console.Write("Sending Application Error..." + "\r\n");
                u.CreateStreamWriterFile(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + "\t" + "\t" + "Sending Application Error...", strLogFileName);

                MailMessage Mailer = new MailMessage();
                Mailer.From = EmailFrom;
                Mailer.To = EmailTo;
                if (EmailCC.Length > 0)
                {
                    Mailer.Cc = EmailCC;
                }

                if (EmailBCC.Length > 0)
                {
                    Mailer.Bcc = EmailBCC;
                }

                Mailer.Subject = strSubject;
                Mailer.Body = strBody.ToString();
                Mailer.BodyFormat = MailFormat.Text;
                Mailer.Priority = MailPriority.High;
                Mailer.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

                if (strAttachmentDirectory.Length > 0)
                {
                    if (!blnSingleAttachment)
                    {
                        DirectoryInfo dir = new DirectoryInfo(strAttachmentDirectory);
                        FileInfo[] filesInDir = dir.GetFiles();

                        foreach (FileInfo file in filesInDir)
                        {
              //Origin //   Mailer.Attachments.Add(new System.Web.Mail.MailAttachment(strAttachmentDirectory + file.Name));
                            Mailer.Attachments.Add(new System.Net.Mail.Attachment(strAttachmentDirectory + file.Name));
                            Console.Write("Attachment File...." + "\t" + "\t" + strAttachmentDirectory + file.Name + "\r\n");
                            u.CreateStreamWriterFile(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + "\t" + "\t" + "Attachment File...." + "\t" + "\t" + strAttachmentDirectory + file.Name, strLogFileName);
                        }
                    }
                    else
                    {
          //Origin  //  Mailer.Attachments.Add(new System.Web.Mail.MailAttachment(strAttachmentDirectory));
                        Mailer.Attachments.Add(new System.Net.Mail.Attachment(strAttachmentDirectory));
                        Console.Write("Attachment File...." + "\t" + "\t" + strAttachmentDirectory + "\r\n");
                        u.CreateStreamWriterFile(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + "\t" + "\t" + "Attachment File...." + "\t" + "\t" + strAttachmentDirectory, strLogFileName);
                    }
                }

                SmtpMail.SmtpServer = "Mailrelay.cc-inc.com";
                SmtpMail.Send(Mailer);
                Console.Write("Email application/program error details...." + "\r\n");
                u.CreateStreamWriterFile(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + "\t" + "\t" + "Email application/program error details sent...", strLogFileName);
            }

            catch (System.SystemException exp)
            {
                u.CreateStreamWriterFile(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss") + "\t" + "\t" + exp.Message.ToString(), strLogFileName);
            }
        }

        #endregion
    }
   
}
