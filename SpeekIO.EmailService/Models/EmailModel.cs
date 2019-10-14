using SpeekIO.Domain.Interfaces.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.EmailService.Models
{
    public class EmailModel
    {
        public IRecipient Recipient { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        // add attachments
    }
}
