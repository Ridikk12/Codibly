using Interview.Email.Domain.Aggregates;
using Interview.Email.Domain.Dto;
using Interview.Email.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Email.ExternalSender.Interfaces
{
    public class IExternalSender : IEmailSenderService
    {
        public void Send(EmailAggregate email)
        {
            throw new NotImplementedException();
        }
    }
}
