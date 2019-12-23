using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Command.AddSports.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.API.Controllers;
using SpeekIO.Domain.ViewModels.Response;

namespace EasyBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : EasyBookingController
	{

		private readonly IMediator _mediator;
		private readonly ILogger<SportsController> _logger;


		public SportsController(IMediator mediator, ILogger<SportsController> logger)
		{
			this._mediator = mediator;
			this._logger = logger;
		}

		#region Categories

		[HttpPost(nameof(GetSportsList))]
		public async Task<IActionResult> GetSportsList([FromBody]GetSportsListQuery model)
		{
			try
			{
				var response = await _mediator.Send(model);
				return StatusCode(200, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}

		//[HttpGet(nameof(GetSports))]
		//public async Task<IActionResult> GetSports(int id)
		//{
		//	try
		//	{
		//		GetCategoryQuery categoryQuery = new GetCategoryQuery() { CategoryId = id };
		//		var response = await _mediator.Send(categoryQuery);

		//		return StatusCode(201, response);
		//	}
		//	catch (Exception e)
		//	{
		//		return StatusCode(500, e);
		//	}
		//}

		//[HttpPost(nameof(DeleteSports))]
		//public async Task<CommonResponse> DeleteSports(DeleteCategoryCommand model)
		//{
		//	try
		//	{
		//		return await _mediator.Send(model);
		//	}
		//	catch (Exception ex)
		//	{
		//		_logger.LogError(ex.Message, ex);
		//		return new CommonResponse(false, "Something went wrong. Please try again.");
		//	}
		//}

		[HttpPost(nameof(AddSports))]
		public async Task<IActionResult> AddSports(AddSportsCommand sprots)
		{
			try
			{
				var response = await _mediator.Send(sprots);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}

		//[HttpPost(nameof(UpdateSports))]
		//public async Task<IActionResult> UpdateSports(AddCategoryCommand category)
		//{
		//	try
		//	{
		//		var response = await _mediator.Send(category);

		//		return StatusCode(201, response);
		//	}
		//	catch (Exception e)
		//	{
		//		return StatusCode(500, e);
		//	}
		//}

		#endregion


	}
}