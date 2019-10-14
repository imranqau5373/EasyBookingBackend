using SpeekIO.EmailService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpeekIO.EmailService.Interfaces
{
    public interface IEmailProvider
    {
        Task<bool> Send(EmailModel model);
    }
}
