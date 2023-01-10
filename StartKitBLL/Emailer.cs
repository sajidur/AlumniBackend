using StarterKITDAL;
using System;
using System.Collections;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace StartKitBLL
{
    public interface IEmailer
    {
        bool SendEmail(Contact email);
    }
    public class Emailer : IEmailer
    {
        public bool SendEmail(Contact email)
        {
            // Specify the file to be attached and sent.
            // This example assumes that a file named Data.xls exists in the
            // current working directory.
            // Create a message and set up the recipients.
            MailMessage message = new MailMessage(
                "web@dhakahandicrafts.com",
               // "suahmed@dhakahandicrafts.com,website@dhakahandicrafts.com,sajid.ict@hotmail.com",
               "website@dhakahandicrafts.com,sajid.ict@hotmail.com",
                email.Subject,
                "My email address is:"+  email.Email+" Message:" + email.Message);
            message.ReplyToList.Add(new MailAddress(email.Email));
            // Create  the file attachment for this email message.
            //  Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
            // Add time stamp information for the file.
            //ContentDisposition disposition = data.ContentDisposition;
            //disposition.CreationDate = System.IO.File.GetCreationTime(file);
            //disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            //disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
            // Add the file attachment to this email message.
            // message.Attachments.Add(data);

            //Send the message.
            //  SmtpClient client = new SmtpClient("mail.rexsystemsbd.com", 8889);
            SmtpClient client = new SmtpClient("mail.dhakahandicrafts.com", 587);
            client.UseDefaultCredentials = false;
            NetworkCredential MyCredentials = new NetworkCredential("web@dhakahandicrafts.com", "Root@pass1");
            // Add credentials if the SMTP server requires them.
            client.Credentials = MyCredentials;
            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}",
                    ex.ToString());
                return false;
            }
            // Display the values in the ContentDisposition for the attachment.
            //ContentDisposition cd = data.ContentDisposition;
            //Console.WriteLine("Content disposition");
            //Console.WriteLine(cd.ToString());
            //Console.WriteLine("File {0}", cd.FileName);
            //Console.WriteLine("Size {0}", cd.Size);
            //Console.WriteLine("Creation {0}", cd.CreationDate);
            //Console.WriteLine("Modification {0}", cd.ModificationDate);
            //Console.WriteLine("Read {0}", cd.ReadDate);
            //Console.WriteLine("Inline {0}", cd.Inline);
            //Console.WriteLine("Parameters: {0}", cd.Parameters.Count);
            //foreach (DictionaryEntry d in cd.Parameters)
            //{
            //    Console.WriteLine("{0} = {1}", d.Key, d.Value);
            //}
            //data.Dispose();
        }
    }
}
