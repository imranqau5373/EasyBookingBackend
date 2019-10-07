using SpeekIO.Domain.Intefaces.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpeekIO.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(IEmailModel emailModel);
    }
}
