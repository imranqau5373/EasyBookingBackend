using MediatR;
using SpeekIO.Domain.Entities.Question;
using SpeekIO.Domain.ViewModels.Response.JobsResponse.CommandResponse;
using SpeekIO.Domain.ViewModels.Response.JobsResponse.Questionaire;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.QuestionaireCommand.AddQuestionaire
{
    public class AddQuestionaireCommand : IRequest<AddQuestionaireResponse>
    {
        public string Name { get; set; }
        public List<Question> Questions { get; set; }

    }
}
