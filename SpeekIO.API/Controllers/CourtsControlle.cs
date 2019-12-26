using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBooking.API.Controllers
{
	public class CourtsControlle : EasyBookingController
	{
		private readonly IMediator _mediator;
		private readonly ILogger<CourtsControlle> _logger;


		public CourtsControlle(IMediator mediator, ILogger<CourtsControlle> logger)
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

		[HttpGet(nameof(GetSports))]
		public async Task<IActionResult> GetSports(int id)
		{
			try
			{
				GetSportsQuery sportsQuery = new GetSportsQuery() { SportsId = id };
				var response = await _mediator.Send(sportsQuery);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}

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


		#endregion


	}
}
