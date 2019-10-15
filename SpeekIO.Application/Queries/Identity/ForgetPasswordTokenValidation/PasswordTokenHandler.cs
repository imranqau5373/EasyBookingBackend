using MediatR;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Queries.Identity.ForgetPasswordTokenValidation
{
	public class PasswordTokenHandler : IRequestHandler<PasswordTokenQuery, PasswordTokenValidationResponse>
	{
		private readonly ISpeekIODbContext _context;
		private readonly IApplicationConfiguration _applicationConfiguration;

		public PasswordTokenHandler(ISpeekIODbContext context, IEmailService emailService, IApplicationConfiguration applicationConfiguration)
		{
			_context = context;
			_applicationConfiguration = applicationConfiguration;
		}


		public Task<PasswordTokenValidationResponse> Handle(PasswordTokenQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

	}
}
