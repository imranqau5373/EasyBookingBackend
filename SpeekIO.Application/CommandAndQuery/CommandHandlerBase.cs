using MediatR;
using Microsoft.AspNetCore.Http;
using SpeekIO.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands
{
    public abstract class CommandHandlerBase<TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : IRequest<TResponse>
    {
        protected readonly ApplicationUserManager _userManager;

        private Task<ApplicationUser> applicationUserTask;

        private ApplicationUser _user = null;

        public CommandHandlerBase(ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor)
        {
            this._userManager = userManager;

            ClaimsPrincipal currentUser = httpContextAccessor.HttpContext.User;
            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            applicationUserTask = _userManager.FindByIdAsync(userId);
        }
        protected ApplicationUser User
        {
            get
            {
                if (null == _user)
                    _user = applicationUserTask.GetAwaiter().GetResult();

                return _user;
            }
        }

        public abstract Task<TResponse> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
