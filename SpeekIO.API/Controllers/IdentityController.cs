using MediatR;
using Microsoft.AspNetCore.Authorization;
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
using System.Threading.Tasks;

namespace SpeekIO.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : SpeekIOController
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
        [HttpPut(nameof(SignUp))]
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
                var response = await _mediator.Send(forgetPasswordCommand);

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
