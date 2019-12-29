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
using EasyBooking.Application.CommandAndQuery.CompanyModule.Command.AddCompany.Dto;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompanyList.Dto;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompany.Dto;
using SpeekIO.Domain.ViewModels.Response;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Command.DeleteCompany.Dto;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Command.UpdateCompany.Dto;

namespace EasyBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : EasyBookingController
	{

		private readonly IMediator _mediator;
		private readonly ILogger<CompanyController> _logger;


		public CompanyController(IMediator mediator, ILogger<CompanyController> logger)
		{
			this._mediator = mediator;
			this._logger = logger;
		}
		#region Company CRUD
		[HttpPost(nameof(AddCompany))]
		public async Task<IActionResult> AddCompany(AddCompanyCommand company)
		{
			try
			{
				var response = await _mediator.Send(company);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}

		[HttpPost(nameof(UpdateCompany))]
		public async Task<IActionResult> UpdateCompany(UpdateCompanyCommand company)
		{
			try
			{
				var response = await _mediator.Send(company);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}
		[HttpPost(nameof(DeleteCompany))]
		public async Task<CommonResponse> DeleteCompany(DeleteCompanyCommand model)
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
		[HttpPost(nameof(GetCompanyList))]
		public async Task<IActionResult> GetCompanyList([FromBody]GetCompanyListQuery model)
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

		[HttpGet(nameof(GetCompany))]
		public async Task<IActionResult> GetCompany(int id)
		{
			try
			{
				GetCompanyQuery query = new GetCompanyQuery() { Id = id };
				var response = await _mediator.Send(query);

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