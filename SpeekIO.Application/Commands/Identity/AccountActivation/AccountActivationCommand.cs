using MediatR;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Identity.AccountActivation
{
    public class AccountActivationCommand : IRequest<AccountActivationResponse>
    {
        public string ActivationToken { get; set; }
        public string Email { get; set; }
    }
}
