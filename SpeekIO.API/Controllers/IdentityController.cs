using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Commands.Identity.AccountActivation;
using SpeekIO.Application.Commands.Identity.ForgetPassword.ForgetPasswordStepOne;
using SpeekIO.Application.Commands.Identity.ForgetPassword.ForgetPasswordStepTwo;
using SpeekIO.Application.Commands.Identity.Guest;
using SpeekIO.Application.Commands.Identity.SignIn;
using SpeekIO.Application.Commands.Identity.SignUp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using SpeekIO.Application.Commands.Identity.SignOut;
using SpeekIO.Application.Queries.Identity.SearchCompanyUrl;
using SpeekIO.Application.Queries.GetProfile;
using SpeekIO.Domain.ViewModels.Response.IdentityResponse.QueryResponse;
using SpeekIO.Domain.ViewModels.Response;
using SpeekIO.Application.Commands.Identity.UpdateProfile;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace SpeekIO.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : EasyBookingController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<IdentityController> _logger;

        public IdentityController(IMediator mediator, ILogger<IdentityController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }


        // POST api/Identity/SignUp
        [AllowAnonymous]
        [HttpPost(nameof(SignUp))]
        public async Task<IActionResult> SignUp([FromBody] SignupCommand signupCommand)
        {
            try
            {
                var response = await _mediator.Send(signupCommand);

                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // POST api/Identity/Activate
        [AllowAnonymous]
        [HttpPost(nameof(Activate))]
        public async Task<IActionResult> Activate([FromBody] AccountActivationCommand activationCommand)
        {
            try
            {
                var response = await _mediator.Send(activationCommand);

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // POST api/Identity/SignIn
        [AllowAnonymous]
        [HttpPost(nameof(SignIn))]
        public async Task<IActionResult> SignIn([FromBody] SignInCommand signInCommand)
        {
            try
            {
                var response = await _mediator.Send(signInCommand);

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet(nameof(SignOut))]
        public async Task<IActionResult> SignOut()
        {
            try
            {
                SignOutCommand objSignOutCommand = new SignOutCommand();
                var response = await _mediator.Send(objSignOutCommand);

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [AllowAnonymous]
        [HttpGet(nameof(SearchCompanyUrl))]
        public async Task<IActionResult> SearchCompanyUrl(string strCompanyUrl)
        {
            try
            {
                SearchCompanyUrlQuery objCompany = new SearchCompanyUrlQuery();
                objCompany.strCompanyUrl = strCompanyUrl;
                var response = await _mediator.Send(objCompany);

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [AllowAnonymous]
        [HttpPost(nameof(Guest))]
        public async Task<IActionResult> Guest([FromBody] CreateGuestUserCommand createGuestCommand)
        {
            try
            {
                var response = await _mediator.Send(createGuestCommand);

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        [AllowAnonymous]
        [HttpPost(nameof(ForgetPasswordStepOne))]
        public async Task<IActionResult> ForgetPasswordStepOne([FromBody] ForgetPasswordStepOneCommand forgetPasswordCommand)
        {
            try
            {
                var response = await _mediator.Send(forgetPasswordCommand);

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [AllowAnonymous]
        [HttpPost(nameof(ForgetPasswordStepTwo))]
        public async Task<IActionResult> ForgetPasswordStepTwo([FromBody] ForgetPasswordStepTwoCommand forgetPasswordCommand)
        {
            try
            {
                //forgetPasswordCommand.ResetToken = WebUtility.UrlEncode(forgetPasswordCommand.ResetToken);
                var response = await _mediator.Send(forgetPasswordCommand);

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet(nameof(GetProfile))]
        public async Task<CommonResponse> GetProfile()
        {
            try
            {
                var response = await _mediator.Send(new GetProfileQuery());
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return CommonResponse.CreateFailedResponse<CommonResponse>("Something went wrong. Please try again.");
            }
        }

        [HttpPost(nameof(UpdateProfile))]
        public async Task<CommonResponse> UpdateProfile(UpdateProfileCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return CommonResponse.CreateFailedResponse<CommonResponse>("Something went wrong. Please try again.");
            }
        }

        [HttpPost(nameof(ProfilePicTest))]
        public async void ProfilePicTest([FromForm]IFormFile file)
        {
            try
            {
                var path = "D:\\Adnan";
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
                //  return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                //return CommonResponse.CreateFailedResponse<CommonResponse>("Something went wrong. Please try again.");
            }
        }

    }
}
