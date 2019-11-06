using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Commands.QuestionaireCommand.AddQuestionaire;
using SpeekIO.Application.Queries.Question.QuestionType;
using SpeekIO.Application.Queries.Questionaire;
using SpeekIO.Domain.ViewModels.Response.JobsResponse.CommandResponse;
using SpeekIO.Domain.ViewModels.Response.QuestionaireResponse;
namespace SpeekIO.API.Controllers
{

	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class QuestionaireController : SpeekIOController
	{

		private readonly IMediator _mediator;
		private readonly ILogger<QuestionaireController> _logger;

		public QuestionaireController(IMediator mediator, ILogger<QuestionaireController> logger)
		{
			this._mediator = mediator;
			this._logger = logger;
		}



		[HttpGet(nameof(GetQuestionaires))]
		public async Task<IActionResult> GetQuestionaires()
		{
			try
			{
				var questionaireQuery = new QuestionaireQuery();
				var response = await _mediator.Send(questionaireQuery);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}
        [HttpPost(nameof(SaveQuestionaire))]
        public async Task<AddQuestionaireResponse> SaveQuestionaire(DeleteQuestionaireCommand model)
        {
            try
            {
                var questionaire = await _mediator.Send(model);
                return questionaire;
            }
            catch (Exception e)
            {
                return new AddQuestionaireResponse
                {
                    Message = e.Message,
                    Successful = false,
                    Id = -1
                };
            }
        }

       



    }
}