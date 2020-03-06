using Interview.Email.Domain.Aggregates;
using Interview.Email.Domain.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Email.Data
{
    class EmailEntityRepository : IRepository<EmailAggregate>
    {
        public EmailAggregate Get(Guid? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmailAggregate> GetAll()
        {
            throw new NotImplementedException();
        }

        public EmailAggregate Save(EmailAggregate entity)
        {
            throw new NotImplementedException();
        }
    }
}
