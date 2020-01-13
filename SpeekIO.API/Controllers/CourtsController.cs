using EasyBooking.Application.CommandAndQuery.CourtsModule.Command.AddCourts.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsModule.Command.Dto.DeleteCourts;
using EasyBooking.Application.CommandAndQuery.CourtsModule.Command.UpdateCourts.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourts.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourtsBySportCompany.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourtsList.Dto;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Command.AddSports.Dto;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSports.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.API.Controllers;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBooking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourtsController : EasyBookingController
	{
		private readonly IMediator _mediator;
		private readonly ILogger<CourtsController> _logger;


		public CourtsController(IMediator mediator, ILogger<CourtsController> logger)
		{
			this._mediator = mediator;
			this._logger = logger;
		}

		#region Courts CRUD

		[HttpPost(nameof(GetCourtsList))]
		public async Task<IActionResult> GetCourtsList([FromBody]GetCourtsListQuery model)
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

		[HttpGet(nameof(GetCourts))]
		public async Task<IActionResult> GetCourts(int id)
		{
			try
			{
				GetCourtsQuery query = new GetCourtsQuery() { Id = id };
				var response = await _mediator.Send(query);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}
		[HttpGet(nameof(GetCourtsByCompanySportsId))]
		public async Task<IActionResult> GetCourtsByCompanySportsId(long companyId, long sportsId)
		{
			try
			{
				GetCourtsBySportCompanyListQuery query = new GetCourtsBySportCompanyListQuery() 
				{  CompanyId = companyId , SportId = sportsId};
				var response = await _mediator.Send(query);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}

		[HttpPost(nameof(AddCourts))]
		public async Task<IActionResult> AddCourts(AddCourtsCommand court)
		{
			try
			{
				var response = await _mediator.Send(court);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}
		[HttpPost(nameof(UpdateCourts))]
		public async Task<IActionResult> UpdateCourts(UpdateCourtsCommand court)
		{
			try
			{
				var response = await _mediator.Send(court);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}
		[HttpPost(nameof(DeleteCourts))]
		public async Task<CommonResponse> DeleteCourts(DeleteCourtsCommand model)
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
