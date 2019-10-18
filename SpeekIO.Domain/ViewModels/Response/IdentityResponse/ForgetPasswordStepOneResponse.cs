using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response
{
    public class ForgetPasswordStepOneResponse : CommonResponse
    {
        public ForgetPasswordStepOneResponse()
        {
        }

        public ForgetPasswordStepOneResponse(bool success, string message) : base(success, message)
        {
        }

        public bool EmailDoesnotExist { get; set; }
        public bool ResetPasswordNotAllowed { get; set; }
        public bool SentPasswordResetLinkToEmail { get; set; }

    }
}
