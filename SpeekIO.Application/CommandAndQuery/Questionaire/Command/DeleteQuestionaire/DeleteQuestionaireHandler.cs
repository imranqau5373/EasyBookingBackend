using AutoMapper;
using MediatR;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Questionaire;
using SpeekIO.Domain.ViewModels.Response;
using SpeekIO.Domain.ViewModels.Response.JobsResponse.CommandResponse;
using SpeekIO.Domain.ViewModels.Response.JobsResponse.Questionaire;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.QuestionaireCommand.AddQuestionaire
{
    public class DeleteQuestionaireHandler : IRequestHandler<DeleteQuestionaireCommand, CommonResponse>
    {
        private readonly ISpeekIODbContext _context;
        private readonly IMapper _mapper;
        public DeleteQuestionaireHandler(
            ISpeekIODbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CommonResponse> Handle(DeleteQuestionaireCommand request, CancellationToken cancellationToken)
        {

            CommonResponse response = new CommonResponse()
            {
                Message = "Deleted Successfully",
                Successful = true
            };

            try
            {
                var questionaire = new Questionaire() { Id = request.Id };
                _context.Questionaires.Attach(questionaire);
                _context.Questionaires.Remove(questionaire);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;

        }
    }
}
