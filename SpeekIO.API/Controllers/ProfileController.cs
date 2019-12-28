
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.API.Controllers;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EasyBooking.Application.CommandAndQuery.ProfileModule.Command.AddProfile.Dto;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompanyList.Dto;
using EasyBooking.Application.CommandAndQuery.ProfileModule.Query.GetProfile.Dto;
using SpeekIO.Domain.ViewModels.Response;
using EasyBooking.Application.CommandAndQuery.ProfileModule.Command.DeleteProfile.Dto;
using SpeekIO.Application.Commands.Identity.UpdateProfile;

namespace EasyBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : EasyBookingController
	{

		private readonly IMediator _mediator;
		private readonly ILogger<ProfileController> _logger;


		public ProfileController(IMediator mediator, ILogger<ProfileController> logger)
		{
			this._mediator = mediator;
			this._logger = logger;
		}
		#region Profile CRUD
		[HttpPost(nameof(AddProfile))]
		public async Task<IActionResult> AddProfile(AddProfileCommand sprots)
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

		[HttpPost(nameof(UpdateProfile))]
		public async Task<IActionResult> UpdateProfile(UpdateProfileCommand profile)
		{
			try
			{
				var response = await _mediator.Send(profile);

				return StatusCode(201, response);
			}
			catch (Exception e)
			{
				return StatusCode(500, e);
			}
		}
		[HttpPost(nameof(DeleteProfile))]
		public async Task<CommonResponse> DeleteProfile(DeleteProfileCommand model)
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
		[HttpPost(nameof(GetProfileList))]
		public async Task<IActionResult> GetProfileList([FromBody]GetProfileListQuery model)
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

		[HttpGet(nameof(GetProfile))]
		public async Task<IActionResult> GetProfile(int id)
		{
			try
			{
				GetProfileQuery query = new GetProfileQuery() { Id = id };
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