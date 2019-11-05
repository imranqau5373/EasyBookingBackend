using AutoMapper;
using MediatR;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Questionaire;
using SpeekIO.Domain.ViewModels.Response.JobsResponse.CommandResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.QuestionaireCommand.AddQuestionaire
{
   public class AddQuestionaireHandler
    {
        private readonly ISpeekIODbContext _context;
        private readonly IMapper _mapper;
        public AddQuestionaireHandler(
            ISpeekIODbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AddJobResponse> Handle(AddQuestionaireCommand request, CancellationToken cancellationToken)
        {
            var questionaireModel = _mapper.Map<Questionaire>(request);
            var questionare = await _context.Questionaires.AddAsync(questionaireModel);
            await _context.SaveChangesAsync();
            if (questionare.Entity.Id < 1)
            {
                return new AddJobResponse()
                {
                    Successful = false,
                    Message = "Something went wrong while adding job."
                };
            }
            var jobResponse = _mapper.Map<AddJobResponse>(questionare.Entity);
            jobResponse.Successful = true;
            return jobResponse;
        }
        }
    }
}
