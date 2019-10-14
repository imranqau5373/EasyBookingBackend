using Polly;
using SmartFormat;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Intefaces.Email;
using SpeekIO.Domain.Interfaces.Email;
using SpeekIO.EmailService.Exceptions;
using SpeekIO.EmailService.Interfaces;
using SpeekIO.EmailService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SpeekIO.EmailService.Implementation
{
    internal class EmailService : IEmailService
    {
        private readonly Func<string, IEmailProvider> _emailProvider;
        private readonly IEmailConfiguration _emailConfiguration;

        public EmailService(ISpeekIODbContext context, Func<string, IEmailProvider> emailProvider, IEmailConfiguration emailConfiguration)
        {
            _emailProvider = emailProvider;
            _emailConfiguration = emailConfiguration;
        }

        public async Task SendEmailAsync(IEmailModel emailModel)
        {
            await Task.Delay(0);

            var htmlContent = GetEmailTemplate(emailModel);

            var recipientPayloadMappings = emailModel.Prepare();
            foreach (var item in recipientPayloadMappings)
            {
                var formattedContent = Smart.Format(htmlContent, item.Payload);

                await SendEmailToRecipient(item.Recipient, item.Subject, formattedContent);
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

        private async Task<bool> SendEmailToRecipient(IRecipient recipient, string subject, string formattedContent)
        {
            // SendEmail through any provider like mandrill

            //TODO: apply fallback policy with multiple providers
            try
            {
                return await _emailProvider(_emailConfiguration.DefaultProvider).Send(new EmailModel
                {
                    Recipient = recipient,
                    Content = formattedContent,
                    Subject = subject
                });
            }
            catch (EmailProviderLimitReached)
            {
                // fallback
                throw;
            }
            // Currently we are using default provider. If daily limit of provider reaches then apply secondary policy to 

        }
    }
}
