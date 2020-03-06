using AutoFixture;
using Interview.Email.Domain.Aggregates;
using Interview.Email.Domain.Dto;
using Interview.Email.Domain.Interfaces;
using Interview.Email.Domain.Interfaces.Infrastructure;
using Interview.Email.Domain.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview.Email.Domain.Test
{
    [TestFixture(Category = "Integration")]
    public class EmailServiceTest
    {
        private IEmailService _emailService;
        private Mock<IRepository<EmailAggregate>> _repositoryMock = new Mock<IRepository<EmailAggregate>>();
        private Mock<IEmailSenderService> _emailSenderServiceMock = new Mock<IEmailSenderService>();
        private Mock<IValidator<EmailAggregate>> _validatorMock = new Mock<IValidator<EmailAggregate>>();
        private IFixture _fixture;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _fixture = new Fixture();
            EmailAggregate email = _fixture.Create<EmailAggregate>();

            //
            _repositoryMock.Setup(r => r.Get(It.IsAny<Guid>())).Returns(email);
            _emailSenderServiceMock.Setup(e => e.Send(It.IsAny<EmailAggregate>())).Verifiable();
            _validatorMock.Setup(v => v.Validate(It.IsAny<EmailAggregate>())).Returns(true);
        }


        [Test]
        public void Should_Get_Email()
        {
            //Arrange
            _emailService = new EmailService(_repositoryMock.Object, _emailSenderServiceMock.Object, _validatorMock.Object);
            //Act
            var email = _emailService.Get(Guid.NewGuid());
            //Assert
            Assert.IsNotNull(email);
        }


        [Test]
        public void Should_Save_Email()
        {
            //Arrange
            _emailService = new EmailService(_repositoryMock.Object, _emailSenderServiceMock.Object, _validatorMock.Object);
            EmailAggregate emailAggregate = _fixture.Create<EmailAggregate>();
            //Act
            Guid id = _emailService.Save(emailAggregate);
            EmailDto savedEmail = _emailService.Get(id);
            //Assert
            Assert.IsNotNull(savedEmail);
        }

        [Test]
        public void Should_GetAll_Email()
        {
            //Arrange
            _emailService = new EmailService(_repositoryMock.Object, _emailSenderServiceMock.Object, _validatorMock.Object);

            //Act
            var emails = _emailService.GetAll();
            //Assert
            Assert.IsTrue(emails.Any());
        }



    }
}
