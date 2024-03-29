﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Command.BookedSlot.Dto;
using EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Command.CancelBookingSlot.Dto;
using EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Command.OpenBookedSlot.Dto;
using EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Query.DetailSlot.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpeekIO.API.Controllers;

namespace EasyBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingSlotsController : EasyBookingController
    {

        private readonly IMediator _mediator;
        private readonly ILogger<CourtsDurationController> _logger;


        public BookingSlotsController(IMediator mediator, ILogger<CourtsDurationController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }

        [HttpGet(nameof(CancelBookingSlot))]
        public async Task<IActionResult> CancelBookingSlot(int slotId)
        {
            try
            {
                CancelBookingCommand command = new CancelBookingCommand() { SlotId = slotId };
                var response = await _mediator.Send(command);

                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet(nameof(OpenBookingSlot))]
        public async Task<IActionResult> OpenBookingSlot(int slotId)
        {
            try
            {
                OpenBookedSlotCommand command = new OpenBookedSlotCommand() { SlotId = slotId };
                var response = await _mediator.Send(command);

                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpGet(nameof(DetailBookingSlot))]
        public async Task<IActionResult> DetailBookingSlot(int slotId)
        {
            try
            {
                DetailSlotCommand command = new DetailSlotCommand() { SlotId = slotId };
                var response = await _mediator.Send(command);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        [HttpGet(nameof(BookedSlot))]
        public async Task<IActionResult> BookedSlot(int slotId)
        {
            try
            {
                BookedSlotCommand bookingSlot = new BookedSlotCommand() { SlotId = slotId };
                var response = await _mediator.Send(bookingSlot);

                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}