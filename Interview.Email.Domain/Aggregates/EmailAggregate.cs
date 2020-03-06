using Interview.Email.Domain.Common;
using Interview.Email.Domain.Events;
using Interview.Email.Domain.Interfaces;
using System.Collections.Generic;

namespace Interview.Email.Domain.Aggregates
{
    public class EmailAggregate : BaseEntity, IAggregateRoot
    {
        public List<IDomainEvent> DomainEvents { get; private set; } = new List<IDomainEvent>();
        public List<string> Recipients { get; private set; }
        public string Sender { get; private set; }
        public EmailStatus Status { get; private set; }
        public EmailPriority Priority { get; private set; }
        public string Message { get; private set; }
        public string Subject { get; private set; }

        public EmailAggregate(List<string> recipients, string sender, EmailPriority priority, string message, string subject)
        {

            Recipients = recipients;
            Sender = sender;
            Priority = priority;
            Message = message;
            Subject = subject;
        }

        public void SetEmailStatus(EmailStatus status)
        {
            Status = status;
            DomainEvents.Add(new EmailStatusChangedEvent());
        }
    }
}
