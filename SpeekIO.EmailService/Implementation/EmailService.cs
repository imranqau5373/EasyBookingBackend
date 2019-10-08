using SmartFormat;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Intefaces.Email;
using SpeekIO.Domain.Interfaces.Email;
using SpeekIO.EmailService.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SpeekIO.EmailService.Implementation
{
    internal class EmailService : IEmailService
    {
        public EmailService(ISpeekIODbContext context)
        {

        }

        public async Task SendEmailAsync(IEmailModel emailModel)
        {
            await Task.Delay(0);

            var htmlContent = GetEmailTemplate(emailModel);

            var recipientPayloadMappings = emailModel.Prepare();
            foreach (var item in recipientPayloadMappings)
            {
                var formattedContent = Smart.Format(htmlContent, item.Payload);

                await SendEmailToRecipient(item.Recipient, formattedContent);
            }

        }

        private string GetEmailTemplate(IEmailModel emailModel)
        {
            var loc = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            var path = Path.Combine(loc, "EmailTemplates", $"{emailModel.TemplateName}.html");
            if (!File.Exists(path))
                throw new EmailTemplateMissingException(path);
            var htmlContent = File.ReadAllText(path);

            return htmlContent;
        }

        private async Task SendEmailToRecipient(IRecipient recipient, string formattedContent)
        {
            // SendEmail through any provider like mailgun
            await Task.Delay(0);
        }
    }
}
