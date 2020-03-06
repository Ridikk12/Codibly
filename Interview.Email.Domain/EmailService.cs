using Interview.Email.Core.Exceptions;
using Interview.Email.Domain.Aggregates;
using Interview.Email.Domain.Common;
using Interview.Email.Domain.Dto;
using Interview.Email.Domain.Interfaces;
using Interview.Email.Domain.Interfaces.Infrastructure;
using Interview.Email.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview.Email.Domain
{
    public class EmailService : IEmailService
    {
        private readonly IRepository<EmailAggregate> _repository;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IValidator<EmailAggregate> _validator;

        public EmailService(IRepository<EmailAggregate> repository, IEmailSenderService emailSenderService, IValidator<EmailAggregate> validator)
        {
            _emailSenderService = emailSenderService;
            _repository = repository;
            _validator = validator;
        }

        public EmailDto Get(Guid emailId)
        {
            var email = _repository.Get(emailId);

            if (email == null)
                throw new ObjectNotFoundException($"Email {emailId} not found");
            return new EmailDto(email.Id, email.Recipients, email.Sender, email.Status.ToString(), email.Priority.ToString(), email.Message, email.Subject);
        }

        public IEnumerable<EmailDto> GetAll()
        {
            var emails = _repository.GetAll();
            return emails.Select(email =>
            new EmailDto(email.Id, email.Recipients, email.Sender, email.Status.ToString(), email.Priority.ToString(), email.Message, email.Subject)).ToList();
        }

        public Guid Save(EmailAggregate email)
        {
            _validator.ValidateAndThrow(email);
            return _repository.Save(email).Id;
        }

        public bool Send(EmailAggregate email)
        {
            _validator.ValidateAndThrow(email);
            _emailSenderService.Send(email);
            email.SetEmailStatus(EmailStatus.Sent);
            _repository.Save(email);
            return true;
        }

        public bool Send(Guid id)
        {
            EmailAggregate email = _repository.Get(id);
            _validator.ValidateAndThrow(email);
            _emailSenderService.Send(email);
            email.SetEmailStatus(EmailStatus.Sent);
            _repository.Save(email);
            return true;
        }
    }
}
