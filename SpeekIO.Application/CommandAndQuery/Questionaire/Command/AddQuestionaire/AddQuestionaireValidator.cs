using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;
namespace SpeekIO.Application.Commands.QuestionaireCommand.AddQuestionaire
{
    public class AddQuestionaireValidator : BaseValidator<AddQuestionaireCommand>
    {
        public AddQuestionaireValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("Name is missing");
        }

    }
}
