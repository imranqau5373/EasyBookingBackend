using EasyBooking.Application.CommandAndQuery.CourtsModule.Command.Dto.DeleteCourts;
using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Command.DeleteCourts.Dto
{
    public class DeleteCourtsCommandValidator : BaseValidator<DeleteCourtsCommand>
    {

        public DeleteCourtsCommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Please provide Identifier");
        }
    }
}
