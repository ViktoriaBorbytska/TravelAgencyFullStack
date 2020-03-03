using MimeKit;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.Interfaces.Dto;
using TravelAgency.Services.Interfaces.Handlers;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace TravelAgency.Services.Handlers
{
    internal class MailHandler : IMailHandler
    {
        public async Task SendMailAsync(EmailData emailData, string receiverAddress)
        {
//            SmtpMail mail = new SmtpMail("TryIt");
//
//            // Your gmail email address
//            mail.From = emailData.Email;
//            // Set recipient email address
//            mail.To = receiverAddress;
//
//            // Set email subject
//            mail.Subject = emailData.Subject;
//            // Set email body
//            mail.TextBody = emailData.Message;
//
//            // Gmail SMTP server address
//            SmtpServer oServer = new SmtpServer("smtp.gmail.com");
//
//            // Gmail user authentication
//            // For example: your email is "gmailid@gmail.com", then the user should be the same
//            oServer.User = "recover.pass.manager@gmail.com";
//            oServer.Password = "qw56io09wwdc";
//
//            // Set 465 port
//            oServer.Port = 465;
//
//            // detect SSL/TLS automatically
//            oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;
//            
//
//            SmtpClient client = new SmtpClient();
//            client.SendMail(oServer, mail);
//            
//            
            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress(emailData.Name, emailData.Email);
            message.From.Add(from);

            message.Subject = emailData.Subject;

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = emailData.Message;

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587);
            client.Authenticate("recover.pass.manager@gmail.com", "qw56io09wwdc");

            MailboxAddress to = new MailboxAddress(receiverAddress);
            message.To.Add(to);

            await client.SendAsync(message);
            
            client.Disconnect(true);
            client.Dispose();
        }
    }
}
