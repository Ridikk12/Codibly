using Interview.Email.Domain.Aggregates;
using Interview.Email.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Email.Domain.Interfaces
{
    public interface IEmailService
    {
        Guid Save(EmailAggregate email);
        EmailDto Get(Guid emailId);
        IEnumerable<EmailDto> GetAll();
        bool Send(Guid id);
        bool Send(EmailAggregate email);


    }
}
