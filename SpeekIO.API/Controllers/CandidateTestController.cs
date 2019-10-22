using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Queries.CandidateTest.VideoQuestion;

namespace SpeekIO.API.Controllers
{

	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class CandidateTestController : SpeekIOController
	{
		private readonly IMediator _mediator;
		private readonly ILogger<IdentityController> _logger;


		public CandidateTestController(IMediator mediator, ILogger<IdentityController> logger)
		{
			this._mediator = mediator;
			this._logger = logger;
		}


		[HttpGet(nameof(StartVideo))]
		public async Task<IActionResult> StartVideo()
		{
			try
			{
				VideoQuestionQuery objVideoQuestion = new VideoQuestionQuery();
				var response = await _mediator.Send(objVideoQuestion);

				return Ok(response);

			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}


	}
}