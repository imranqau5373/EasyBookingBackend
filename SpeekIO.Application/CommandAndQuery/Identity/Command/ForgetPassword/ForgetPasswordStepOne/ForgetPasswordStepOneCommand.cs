using MediatR;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Identity.ForgetPassword.ForgetPasswordStepOne
{
    public class ForgetPasswordStepOneCommand : IRequest<ForgetPasswordStepOneResponse>
    {
        public string ForgetEmail { get; set; }
    }
}
