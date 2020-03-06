using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Interview.Email.Domain.Aggregates;
using Interview.Email.Domain.Common;
using Interview.Email.Domain.Interfaces;
using Interview.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Interview.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmailsController : ControllerBase
    {
        private readonly ILogger<EmailsController> _logger;
        private readonly IEmailService _emailService;

        public EmailsController(ILogger<EmailsController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;

        }
  
        [HttpPost("Email")]
        public async Task<ActionResult<string>> Email(EmailRequest request)
        {
            EmailAggregate email = new EmailAggregate(request.Recipients, request.Sender, (EmailPriority)request.Priority, request.Message, request.Subject);
            return Accepted(await Task.FromResult(_emailService.Save(email)));
        }

        [HttpGet("Email")]
        public async Task<ActionResult<string>> Email([FromQuery] Guid id) => Ok(await Task.FromResult(new EmailRequest()));
        [HttpPost("Email/{emailId}/Send")]
        public ActionResult<string> Send(Guid id) => Ok(_emailService.Send(id));


        [HttpPost("Email/Send")]
        public ActionResult<string> Send(EmailRequest request) =>
            Ok(Task.FromResult(_emailService.Send(new EmailAggregate(request.Recipients, request.Sender, (EmailPriority)request.Priority, request.Message, request.Subject))));


        [HttpGet("Email/{id}/Status")]
        public async Task<ActionResult<string>> Status([FromQuery] Guid id)
        {
            return Ok(await Task.FromResult("Test"));
        }
    }
}