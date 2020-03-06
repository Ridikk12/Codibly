using Interview.Email.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Email.Domain.Interfaces
{
    public interface IValidator<T> where T : BaseEntity
    {
        bool Validate(T entity);
        void ValidateAndThrow(T entity);
    }
}
