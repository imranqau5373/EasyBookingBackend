using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.API.Controllers;
using EasyBooking.Application.CommandAndQuery.Dashboard.Query.GetCategories.Dto;

namespace EasyBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : EasyBookingController {

        private readonly IMediator _mediator;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(IMediator mediator, ILogger<DashboardController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }

        [HttpGet(nameof(GetCategories))]
        public async Task<IActionResult> GetCategories(long companyId)
        {
			try
                
            {
                GetCategoriesQuery categoriesQuery = new GetCategoriesQuery() { CompanyId = companyId };
                var response = await _mediator.Send(categoriesQuery);

                return StatusCode(201, response);
            }
			catch (Exception e)
			{
				return StatusCode(500, e);
    }
}

    }
}
