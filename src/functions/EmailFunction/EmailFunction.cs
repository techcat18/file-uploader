using System.Collections.Generic;
using System.IO;
using EmailFunction.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Mail;

namespace EmailFunction
{
    public class EmailFunction
    {
        private readonly IEmailSenderService _emailSenderService;

        public EmailFunction(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }

        [FunctionName("EmailFunction")]
        [return: SendGrid(ApiKey = "SendGridApiKey")]
        public SendGridMessage Run(
            [BlobTrigger("documents/{name}", Connection = "BlobConnectionString")]Stream myBlob, 
            string name,
            IDictionary<string, string> metadata,
            ILogger log)
        {
            var message = _emailSenderService.Send(metadata["Email"]);
            return message;
        }
    }
}
