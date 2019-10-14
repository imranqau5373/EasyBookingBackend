using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response
{
    public class ResetPasswordResponse : CommonResponse
    {
        public ResetPasswordResponse()
        {

        }
        public ResetPasswordResponse(bool success, string message) : base(success, message)
        {

        }

        public bool EmailSentWithLink { get; set; }
        public object Errors { get; set; }
    }
}
