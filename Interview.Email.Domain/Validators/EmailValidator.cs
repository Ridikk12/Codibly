using Interview.Email.Core.Exceptions;
using Interview.Email.Domain.Aggregates;
using Interview.Email.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Email.Domain.Validators
{
    public class EmailValidator : IValidator<EmailAggregate>
    {
        public bool Validate(EmailAggregate entity)
        {
            //Validation logic
            return true;
        }

        public void ValidateAndThrow(EmailAggregate entity)
        {
            //validation logic
            throw new ValidationException("Validation exception message");
        }
    }
}
