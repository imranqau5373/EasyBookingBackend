using EasyBooking.Application.CommandAndQuery.Sports_Module.Command.AddSports.Dto;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSports.Dto;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsList.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.API.Controllers;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDuration.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.AddCourtsDuration.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.UpdateCourtsDuration.Dto;
using SpeekIO.Domain.ViewModels.Response;
using EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.DeleteCourtsDuration.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDurationList.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDurationSlots.Dto;

namespace EasyBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtsDurationController : EasyBookingController
	{
		private readonly IMediator _mediator;
		private readonly ILogger<CourtsDurationController> _logger;


		public CourtsDurationController(IMediator mediator, ILogger<CourtsDurationController> logger)
		{
			this._mediator = mediator;
			this._logger = logger;
		}
		#region Courts Duration CRUD

		[HttpPost(nameof(GetCourtsDurationList))]
		public async Task<IActionResult> GetCourtsDurationList([FromBody]GetCourtsDurationListQuery model)
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

		[HttpGet(nameof(GetCourtsDuration))]
		public async Task<IActionResult> GetCourtsDuration(int id)
		{
			try
			{
				GetCourtsDurationQuery query = new GetCourtsDurationQuery() { Id = id };
				var response = await _mediator.Send(query);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}

		[HttpGet(nameof(GetDurationSlots))]
		public async Task<IActionResult> GetDurationSlots(int id)
		{
			try
			{
				GetCourtsDurationSlotsQuery query = new GetCourtsDurationSlotsQuery() { Id = id };
				var response = await _mediator.Send(query);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}

		[HttpPost(nameof(AddCourtsDuration))]
		public async Task<IActionResult> AddCourtsDuration(AddCourtsDurationCommand data)
		{
			try
			{
				var response = await _mediator.Send(data);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}
		[HttpPost(nameof(UpdateCourtsDuration))]
		public async Task<IActionResult> UpdateCourtsDuration(UpdateCourtsDurationCommand data)
		{
			try
			{
				var response = await _mediator.Send(data);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}
		[HttpPost(nameof(DeleteCourtsBooking))]
		public async Task<CommonResponse> DeleteCourtsBooking(DeleteCourtsDurationCommand model)
		{
			try
			{
				return await _mediator.Send(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message, ex);
				return new CommonResponse(false, "Something went wrong. Please try again.");
			}
		}

		#endregion

	}
}