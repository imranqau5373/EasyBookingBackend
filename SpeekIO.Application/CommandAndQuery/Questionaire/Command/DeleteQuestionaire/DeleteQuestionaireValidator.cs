using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;
namespace SpeekIO.Application.Commands.QuestionaireCommand.AddQuestionaire
{
    public class DeleteQuestionaireValidator : BaseValidator<DeleteQuestionaireCommand>
    {
        public DeleteQuestionaireValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Please provide Identifier");
        }

    }
}
