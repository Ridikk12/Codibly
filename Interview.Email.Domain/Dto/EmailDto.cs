using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Email.Domain.Dto
{
    public class EmailDto
    {
        public EmailDto(Guid id, List<string> recipients, string sender, string status, string priority, string message, string subject)
        {
            Id = id;
            Recipients = recipients;
            Sender = sender;
            Status = status;
            Priority = priority;
            Message = message;
            Subject = subject;
        }

        public Guid Id { get; set; }
        public List<string> Recipients { get; private set; }
        public string Sender { get; private set; }
        public string Status { get; private set; }
        public string Priority { get; private set; }
        public string Message { get; private set; }
        public string Subject { get; private set; }

        
    }
}
