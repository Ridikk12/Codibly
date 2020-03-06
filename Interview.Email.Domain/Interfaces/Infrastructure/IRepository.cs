using Interview.Email.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview.Email.Domain.Interfaces.Infrastructure
{
    public interface IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        T Get(Guid? id);
        IEnumerable<T> GetAll();
        T Save(T entity);

    }
}
