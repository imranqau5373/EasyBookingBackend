using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.JobManager.AddJob
{
    public class AddJobCommandValidator : BaseValidator<AddJobCommand>
    {
        public AddJobCommandValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("Name is missing");
            RuleFor(t => t.Reference).NotNull().NotEmpty().WithMessage("Reference is missing");
            RuleFor(t => t.StatusId).GreaterThan(0).WithMessage("Status is missing");
            RuleFor(t => t.LanguageId).GreaterThan(0).WithMessage("Language is missing");
        }
    }
}
