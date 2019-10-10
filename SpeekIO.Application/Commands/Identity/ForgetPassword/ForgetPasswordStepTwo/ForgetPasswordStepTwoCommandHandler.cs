using MediatR;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.Identity.ForgetPassword.ForgetPasswordStepTwo
{
    public class ForgetPasswordStepTwoCommandHandler : IRequestHandler<ForgetPasswordStepTwoCommand, ForgetPasswordStepTwoResponse>
    {
        private readonly ApplicationUserManager _userManager;
        private readonly ISpeekIODbContext _context;
        private readonly IEmailService _emailService;
        private readonly IApplicationConfiguration _applicationConfiguration;

        public ForgetPasswordStepTwoCommandHandler(ApplicationUserManager applicationUserManager, ISpeekIODbContext context, IEmailService emailService, IApplicationConfiguration applicationConfiguration)
        {
            _userManager = applicationUserManager;
            _context = context;
            _emailService = emailService;
            _applicationConfiguration = applicationConfiguration;
        }
        public async Task<ForgetPasswordStepTwoResponse> Handle(ForgetPasswordStepTwoCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (null == user)
                return CommonResponse.CreateFailedResponse<ForgetPasswordStepTwoResponse>("User not found");

            var result = await _userManager.ResetPasswordAsync(user, request.ResetToken, request.NewPassword);

            return new ForgetPasswordStepTwoResponse()
            {
                Successful = result.Succeeded,
                Errors = result.Errors
            };
        }
    }
}
