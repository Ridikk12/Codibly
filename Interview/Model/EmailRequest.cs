using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Models
{
    public class EmailRequest
    {
        public string Subject { get; set; }
        public List<string> Recipients { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        public IFormFile Attachment { get; set; }
        public int Priority { get; set; }

    }
}
