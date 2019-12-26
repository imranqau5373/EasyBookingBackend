using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Command.AddCourts.Dto
{
    public class AddCourtsCommandValidator : BaseValidator<AddCourtsCommand>
    {
        public AddCourtsCommandValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("Court name is missing.");
        }
    }
}
