using MediatR;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Identity.Guest
{
    public class CreateGuestUserCommand : IRequest<CreateGuestUserResponse>
    {
        public CreateGuestUserCommand()
        {
        }

        public CreateGuestUserCommand(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}
