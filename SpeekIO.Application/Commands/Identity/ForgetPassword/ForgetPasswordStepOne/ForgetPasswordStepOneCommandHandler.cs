using MediatR;
using SpeekIO.Application.Configuration;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Enums.IdentityEnums;
using SpeekIO.Domain.Intefaces.Email;
using SpeekIO.Domain.Models.Email;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Net;

namespace SpeekIO.Application.Commands.Identity.ForgetPassword.ForgetPasswordStepOne
{
    public class ForgetPasswordStepOneCommandHandler : IRequestHandler<ForgetPasswordStepOneCommand, ForgetPasswordStepOneResponse>
    {
        private readonly ApplicationUserManager _userManager;
        private readonly ISpeekIODbContext _context;
        private readonly IEmailService _emailService;
        private readonly IApplicationConfiguration _applicationConfiguration;

        public ForgetPasswordStepOneCommandHandler(ApplicationUserManager applicationUserManager, ISpeekIODbContext context, IEmailService emailService, IApplicationConfiguration applicationConfiguration)
        {
            _userManager = applicationUserManager;
            _context = context;
            _emailService = emailService;
            _applicationConfiguration = applicationConfiguration;
        }

        public async Task<ForgetPasswordStepOneResponse> Handle(ForgetPasswordStepOneCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.ForgetEmail);
            if (null == user)
            {
                var response = CommonResponse.CreateFailedResponse<ForgetPasswordStepOneResponse>("Üser Not found with this email");
                response.EmailDoesnotExist = true;
                return response;
            }

            if (!await CanResetPassword(user))
            {
                var response = CommonResponse.CreateFailedResponse<ForgetPasswordStepOneResponse>("Üser Not found with this email");
                response.ResetPasswordNotAllowed = true;
                return response;
            }

            await SendPasswordResetEmail(user);


            var successReponse = CommonResponse.CreateSuccessResponse<ForgetPasswordStepOneResponse>("Success");
            successReponse.SentPasswordResetLinkToEmail = true;
            return successReponse;
        }

        private async Task SendPasswordResetEmail(ApplicationUser user)
        {
            var profile = _context.Profiles.SingleOrDefault(t => t.Id == user.Id);
            var name = profile?.Name ?? string.Empty;

            var resetPasswordUrl = $"http://{_applicationConfiguration.Domain}/auth/resetpassword?email={user.Email}&token={WebUtility.UrlEncode(await _userManager.GeneratePasswordResetTokenAsync(user))}";
			IEmailModel emailModel = new ForgetPasswordEmailModel(name, user.Email, resetPasswordUrl);
            await _emailService.SendEmailAsync(emailModel);

        }

        private async Task<bool> CanResetPassword(ApplicationUser user)
        {
            if (null == user)
                return false;
            return await _userManager.IsInRoleAsync(user, UserRoles.User.ToString());
        }
    }
}
