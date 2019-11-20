using MediatR;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Identity.ForgetPassword.ForgetPasswordStepTwo
{
    public class ForgetPasswordStepTwoCommand : IRequest<ForgetPasswordStepTwoResponse>
    {
        public string Email { get; set; }
        public string ResetToken { get; set; }
        public string NewPassword { get; set; }
    }
}
