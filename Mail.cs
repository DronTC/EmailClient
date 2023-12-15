using System.Net;
using System.Net.Mail;

namespace MyEmailClient
{
    public class Mail
    {
        public static MailMessage CreateMail(string fromName, string email, string emailTo, string subject, string body)
        {
            var from = new MailAddress(email, fromName);
            var to = new MailAddress(emailTo);
            var mail = new MailMessage(from, to);

            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            return mail;
        }

        public static void SendMail(string host, int smtpPort, string emailFrom, string pass, MailMessage mail)
        {
            SmtpClient smtp = new SmtpClient(host, smtpPort);
            smtp.Credentials = new NetworkCredential(emailFrom, pass);
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }
    }
}
