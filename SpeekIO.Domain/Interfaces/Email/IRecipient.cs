using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Interfaces.Email
{
    public interface IRecipient
    {
        string Email { get; set; }
        string FullName { get; set; }
    }
}
