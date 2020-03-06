using AutoFixture;
using Interview.Email.Domain.Aggregates;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview.Email.Domain.Test.UnitTest
{
    [TestFixture(Category = "UnitTest")]
    class EmailAggregateTest
    {
        private readonly IFixture _fixture = new Fixture();

        public void Should_Set_Email_Status()
        {
            //Arrange
            EmailAggregate emailAggregate = _fixture.Create<EmailAggregate>();

            //Act
            emailAggregate.SetEmailStatus(Common.EmailStatus.Sent);

            //Assert
            Assert.True(emailAggregate.Status == Common.EmailStatus.Sent);
        }

    }
}
