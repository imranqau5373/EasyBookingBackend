using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Commands.Umbraco;
using SpeekIO.Application.Commands.Umbraco.ContactUs;

namespace SpeekIO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
	public class UmbracoController : SpeekIOController
	{

		private readonly IMediator _mediator;
		private readonly ILogger<HomeController> _logger;


		public UmbracoController(IMediator mediator, ILogger<HomeController> logger)
		{
			this._mediator = mediator;
			this._logger = logger;
		}

		[AllowAnonymous]
		[HttpPost(nameof(SubscribeEmail))]
		public async Task<IActionResult> SubscribeEmail([FromBody] EmailSubscribeCommand emailSubscribeCommand)
		{
			try
			{
				var response = await _mediator.Send(emailSubscribeCommand);
				return Ok(response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}

		[AllowAnonymous]
		[HttpPost(nameof(ContactUs))]
		public async Task<IActionResult> ContactUs([FromBody] ContactUsCommand contactUsCommand)
		{
			try
			{
				var response = await _mediator.Send(contactUsCommand);
				return Ok(response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}

	}
}