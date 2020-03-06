using Interview.Email.Domain.Aggregates;
using Interview.Email.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Email.Domain.Services
{
    public interface IEmailSenderService
    {
        void Send(EmailAggregate email);
    }
}
