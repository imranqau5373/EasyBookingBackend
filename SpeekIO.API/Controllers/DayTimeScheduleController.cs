using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.AddDayTimeSchedule.Dto;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.AddTimeSchedule.Dto;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.UpdateDayTimeSchedule.Dto;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.UpdateTimeSchedule.Dto;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetDayTimeSchedule.Dto;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetDayTimeSchedules.Dto;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetTimeSchedule.Dto;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.ListDayTimeSchedule.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.API.Controllers;
using System;
using System.Threading.Tasks;

namespace EasyBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DayTimeScheduleController : EasyBookingController
    {

        private readonly IMediator _mediator;
        private readonly ILogger<DayTimeScheduleController> _logger;
        public DayTimeScheduleController(IMediator mediator, ILogger<DayTimeScheduleController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }

        [HttpPost(nameof(GetDayTimeScheduleList))]
        public async Task<IActionResult> GetDayTimeScheduleList([FromBody]ListDayTimeScheduleCommand model)
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

        [HttpGet(nameof(GetDayTimeSchedule))]
        public async Task<IActionResult> GetDayTimeSchedule(int id)
        {
            try
            {
                GetDayTimeScheduleQuery query = new GetDayTimeScheduleQuery() { Id = id };
                var response = await _mediator.Send(query);

                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet(nameof(GetDayTimeSchedules))]
        public async Task<IActionResult> GetDayTimeSchedules()
        {
            try
            {
                DayTimeSchedulesQuery query = new DayTimeSchedulesQuery();
                var response = await _mediator.Send(query);

                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet(nameof(GetTimeSchedule))]
        public async Task<IActionResult> GetTimeSchedule(int id)
        {
            try
            {
                GetTimeScheduleQuery query = new GetTimeScheduleQuery() { Id = id };
                var response = await _mediator.Send(query);
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost(nameof(AddDayTimeSchedule))]
        public async Task<IActionResult> AddDayTimeSchedule(AddDayTimeCommand daytime)
        {
            try
            {
                var response = await _mediator.Send(daytime);

                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost(nameof(AddTimeSchedule))]
        public async Task<IActionResult> AddTimeSchedule([FromBody]AddTimeScheduleCommand time)
        {
            try
            {
                var response = await _mediator.Send(time);

                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost(nameof(UpdateTimeSchedule))]
        public async Task<IActionResult> UpdateTimeSchedule([FromBody]UpdateTimeScheduleCommand time)
        {
            try
            {
                var response = await _mediator.Send(time);

                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        [HttpPost(nameof(UpdateDayTimeSchedule))]
        public async Task<IActionResult> UpdateDayTimeSchedule(UpdateDayTimeCommand daytime)
        {
            try
            {
                var response = await _mediator.Send(daytime);

                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

    }
}