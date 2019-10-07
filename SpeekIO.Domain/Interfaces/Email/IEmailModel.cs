using SpeekIO.Domain.Interfaces.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Intefaces.Email
{
    public interface IEmailModel
    {
        IList<IEmailRecipientPayloadInfo> Prepare();

        string TemplateName { get; }
    }
}
