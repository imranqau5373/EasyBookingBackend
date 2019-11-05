using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Queries.Question.QuestionType;

namespace SpeekIO.API.Controllers
{

	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class QuestionController : SpeekIOController
	{

		private readonly IMediator _mediator;
		private readonly ILogger<QuestionController> _logger;

		public QuestionController(IMediator mediator, ILogger<QuestionController> logger)
		{
			this._mediator = mediator;
			this._logger = logger;
		}



		[HttpGet(nameof(GetQuestionTypes))]
		public async Task<IActionResult> GetQuestionTypes()
		{
			try
			{
				var questionTypeQuery = new QuestionTypeQuery();
				var response = await _mediator.Send(questionTypeQuery);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}
	}
}