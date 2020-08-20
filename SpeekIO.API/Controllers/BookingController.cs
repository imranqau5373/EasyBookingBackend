using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyBooking.Application.CommandAndQuery.BookingModule.Query.GetCompanyBookings.Dto;
using EasyBooking.Application.CommandAndQuery.BookingModule.Query.GetUserBookings.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.API.Controllers;

namespace EasyBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[AllowAnonymous]
    public class BookingController : EasyBookingController
	{

		private readonly IMediator _mediator;
		private readonly ILogger<BookingController> _logger;


		public BookingController(IMediator mediator, ILogger<BookingController> logger)
		{
			this._mediator = mediator;
			this._logger = logger;
		}


		[HttpPost(nameof(GetCompanyBooking))]
		public async Task<IActionResult> GetCompanyBooking([FromBody]GetCompanyBookingQuery companyBookingQuery)
		{
			try
			{
				var response = await _mediator.Send(companyBookingQuery);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}


		[HttpPost(nameof(GetUserBookings))]
		public async Task<IActionResult> GetUserBookings([FromBody]GetUserBookingQuery userBookingQuery)
		{
			try
			{
				var response = await _mediator.Send(userBookingQuery);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}
	}
}