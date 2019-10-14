using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SpeekIO.EmailService.Exceptions
{
    public class EmailProviderLimitReached : Exception
    {
        public EmailProviderLimitReached()
        {
        }

        public EmailProviderLimitReached(string message) : base(message)
        {
        }

        public EmailProviderLimitReached(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmailProviderLimitReached(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
