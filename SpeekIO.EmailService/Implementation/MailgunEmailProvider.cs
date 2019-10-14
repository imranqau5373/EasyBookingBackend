using SpeekIO.EmailService.Interfaces;
using SpeekIO.EmailService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpeekIO.EmailService.Implementation
{
    public class MailgunEmailProvider : IEmailProvider
    {
        public Task<bool> Send(EmailModel model)
        {
            throw new NotImplementedException();
        }
    }
}
