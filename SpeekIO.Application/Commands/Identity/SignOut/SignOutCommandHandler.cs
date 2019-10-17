using MediatR;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Commands.Identity.SignOut;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.Identity.SignOut
{
	public class SignOutCommandHandler : IRequestHandler<SignOutCommand, SignInResponse>
	{

		private readonly ApplicationSignInManager _signInManager;
		private readonly ILogger<SignOutCommandHandler> _logger;
		public SignOutCommandHandler(ApplicationSignInManager signOutManager,ILogger<SignOutCommandHandler> logger)
		{
			this._signInManager = signOutManager;
			this._logger = logger;
		}

		public async Task<SignInResponse> Handle(SignOutCommand request, CancellationToken cancellationToken)
		{
			await _signInManager.SignOutAsync();
			_logger.LogInformation("User Logout Successfully."+DateTime.Now.ToString());
			return new SignInResponse()
			{
				Successful = true,
				Message = $"User Signout Successfully."
			};
		}
	}
}
