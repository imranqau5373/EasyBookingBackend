using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SpeekIO.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class HomeController : SpeekIOController
    {

        private readonly IMediator _mediator;
        private readonly ILogger<HomeController> _logger;


        public HomeController(IMediator mediator, ILogger<HomeController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }


        [HttpGet]
        public string Index()
        {
            try
            {
                return "test it is working.";
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        //public async Task<IActionResult> Index(DashboardCommand)
        //{
        //    try
        //    {
        //       var response = await _mediator.Send();

        //        return Ok(response);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e);
        //    }
        //}
    }
}