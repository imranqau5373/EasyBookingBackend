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
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBooking.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.AddCourtsBooking.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.UpdateCourtsBooking.Dto;
using SpeekIO.Domain.ViewModels.Response;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.DeleteCourtsBooking.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBookingList.Dto;

namespace EasyBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtsBookingController : EasyBookingController
	{

		private readonly IMediator _mediator;
		private readonly ILogger<CourtsBookingController> _logger;


		public CourtsBookingController(IMediator mediator, ILogger<CourtsBookingController> logger)
		{
			this._mediator = mediator;
			this._logger = logger;
		}
		#region Bookings CRUD

		[HttpPost(nameof(GetCourtsBookingsList))]
		public async Task<IActionResult> GetCourtsBookingsList([FromBody]GetCourtsBookingListQuery model)
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

		[HttpGet(nameof(GetCourtsBookings))]
		public async Task<IActionResult> GetCourtsBookings(int id)
		{
			try
			{
				GetCourtsBookingQuery query = new GetCourtsBookingQuery() { Id = id };
				var response = await _mediator.Send(query);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}

		[HttpPost(nameof(AddCourtsBooking))]
		public async Task<IActionResult> AddCourtsBooking(AddCourtsBookingCommand data)
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
		[HttpPost(nameof(UpdateCourtsBooking))]
		public async Task<IActionResult> UpdateCourtsBooking(UpdateCourtsBookingCommand data)
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
		public async Task<CommonResponse> DeleteCourtsBooking(DeleteCourtsBookingCommand model)
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