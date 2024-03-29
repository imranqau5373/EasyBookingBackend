﻿using EasyBooking.Application.CommandAndQuery.CompanyModule.Command.DeleteSports.Dto;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Command.AddSports.Dto;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Command.UpdateSports.Dto;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSports.Dto;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsByCompanyList.Dto;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsCompany.Dto;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSportsList.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.API.Controllers;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Threading.Tasks;

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

		#region Sports CRUD

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


		[HttpGet(nameof(GetSportsCompanies))]
		public async Task<IActionResult> GetSportsCompanies()
		{
			try
			{
				GetSportsCompanyQuery sportsQuery = new GetSportsCompanyQuery();
				var response = await _mediator.Send(sportsQuery);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}
		[HttpGet(nameof(GetSportsByCompanyId))]
		public async Task<IActionResult> GetSportsByCompanyId(long companyId)
		{
			try
			{
				GetSportsByCompanyListQuery sportsQuery = new GetSportsByCompanyListQuery() { CompanyId = companyId };
				var response = await _mediator.Send(sportsQuery);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}

		[HttpPost(nameof(DeleteSports))]
		public async Task<CommonResponse> DeleteSports(DeleteSportsCommand model)
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

		[HttpPost(nameof(UpdateSports))]
		public async Task<IActionResult> UpdateSports(UpdateSportsCommand sports)
		{
			try
			{
				var response = await _mediator.Send(sports);

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