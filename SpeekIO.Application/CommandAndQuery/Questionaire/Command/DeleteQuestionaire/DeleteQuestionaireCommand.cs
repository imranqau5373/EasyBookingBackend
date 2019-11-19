using MediatR;
using SpeekIO.Domain.Entities.Question;
using SpeekIO.Domain.ViewModels.Response;
using SpeekIO.Domain.ViewModels.Response.JobsResponse.CommandResponse;
using SpeekIO.Domain.ViewModels.Response.JobsResponse.Questionaire;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.QuestionaireCommand.AddQuestionaire
{
    public class DeleteQuestionaireCommand : IRequest<CommonResponse>
    {
        public int Id { get; set; }

    }
}
