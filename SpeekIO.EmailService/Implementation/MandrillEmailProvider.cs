using Mandrill;
using Mandrill.Models;
using SpeekIO.EmailService.Exceptions;
using SpeekIO.EmailService.Interfaces;
using SpeekIO.EmailService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SpeekIO.EmailService.Implementation
{
    internal class MandrillEmailProvider : IEmailProvider
    {
        private readonly IEmailConfiguration _emailConfiguration;

        public MandrillEmailProvider(IEmailConfiguration emailConfiguration)
        {
            _emailConfiguration = emailConfiguration;
        }
        public async Task<bool> Send(EmailModel model)
        {
            var mandrillApi = new MandrillApi(_emailConfiguration.MandrillAPIKey);

            var emailMessage = new EmailMessage
            {
                MergeLanguage = TemplateSyntax.Mailchimp,
                Subject = model.Subject,
                To = new[] { new EmailAddress(model.Recipient.Email) },
                FromEmail = _emailConfiguration.MandrillSenderEmail,
                Html = model.Content
            };

            var result = await mandrillApi.SendMessage(new Mandrill.Requests.Messages.SendMessageRequest(emailMessage));

            return result.FirstOrDefault()?.Status != EmailResultStatus.Rejected;
        }
    }
}
