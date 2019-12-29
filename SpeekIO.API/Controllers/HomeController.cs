using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Queries.Dashboard.Job;

namespace SpeekIO.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class HomeController : EasyBookingController
    {

        private readonly IMediator _mediator;
        private readonly ILogger<HomeController> _logger;
        // Identical schemaIds detected for types 
        //EasyBooking.Application.CommandAndQuery.ProfileModule.Command.UpdateProfile.Dto.UpdateProfileCommand
        //and SpeekIO.Application.Commands.Identity.UpdateProfile.UpdateProfileCommand. See config settings 

        public HomeController(IMediator mediator, ILogger<HomeController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet(nameof(Index))]
        public async Task<IActionResult> Index()
        {
            try
            {
                JobQuery objJobQuery = new JobQuery();
                var response = await _mediator.Send(objJobQuery);

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}