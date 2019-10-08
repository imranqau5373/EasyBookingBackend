using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Commands.Conference.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeekIO.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceController : SpeekIOController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ConferenceController> _logger;

        public ConferenceController(IMediator mediator, ILogger<ConferenceController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }

        // POST api/Identity/SignUp
        [Authorize]
        [HttpPut(nameof(Create))]
        public async Task<IActionResult> Create([FromBody] CreateConferenceCommand createConferenceCommand)
        {
            try
            {
                var response = await _mediator.Send(createConferenceCommand);

                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
