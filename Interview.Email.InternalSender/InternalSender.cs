using Interview.Email.Domain.Aggregates;
using Interview.Email.InternalSender.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace Interview.Email.InternalSender
{
    public class InternalSender : IInternalSender
    {
        private readonly SmtpClient _smtpServer;
        public InternalSender(string userName, string password, string smtpServerAddress)
        {
            _smtpServer = new SmtpClient(smtpServerAddress)
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential(userName, password)
            };
        }

        public void Send(EmailAggregate email)
        {
            
            MailMessage message = new MailMessage(email.Sender, "test", email.Subject, email.Message);
            _smtpServer.Send(message);

        }
    }
}



