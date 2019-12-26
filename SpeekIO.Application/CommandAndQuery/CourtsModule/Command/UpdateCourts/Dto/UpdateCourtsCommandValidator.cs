using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Command.UpdateCourts.Dto
{
    public class UpdateCourtsCommandValidator : BaseValidator<UpdateCourtsCommand>
    {

        public UpdateCourtsCommandValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("Courts name is missing.");
        }
    }
}
