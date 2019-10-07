using SpeekIO.Domain.Interfaces.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Models.Email
{
    public class Recipient : IRecipient
    {
        public Recipient(string fullName, string email)
        {
            this.FullName = fullName;
            this.Email = email;
        }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}
