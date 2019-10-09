using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Commands.Conference.Connect;
using SpeekIO.Application.Commands.Conference.ConnectionLog;
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

        // POST api/Conference/Create
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

        // POST api/Conference/Connect
        [Authorize]
        [HttpPost(nameof(Connect))]
        public async Task<IActionResult> Connect([FromBody] ConnectConferenceCommand connectConferenceCommand)
        {
            try
            {
                var response = await _mediator.Send(connectConferenceCommand);

                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        // POST api/Conference/ConnectionLog
        [Authorize]
        [HttpPut(nameof(ConnectionLog))]
        public async Task<IActionResult> ConnectionLog([FromBody] ConnectionLogCommand connectionLogCommand)
        {
            try
            {
                var response = await _mediator.Send(connectionLogCommand);

                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
