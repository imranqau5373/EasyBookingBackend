using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.ViewModels.Response.QuestionResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Queries.Question.QuestionType
{
	public class QuestionTypeQueryHandler : IRequestHandler<QuestionTypeQuery, QuestionTypeResponse>
	{

		private readonly ILogger<QuestionTypeQueryHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly ISpeekIODbContext _context;
		public QuestionTypeQueryHandler(ILogger<QuestionTypeQueryHandler> logger, AutoMapper.IMapper mapper, ISpeekIODbContext context)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}

		public async Task<QuestionTypeResponse> Handle(QuestionTypeQuery request, CancellationToken cancellationToken)
		{
			var questionTypes = await _context.QuestionTypes.ToListAsync();
			if (questionTypes == null)
			{
				return new QuestionTypeResponse()
				{
					Successful = false,
					Message = "Question types not found."
				};
			}
			return new QuestionTypeResponse()
			{
				Successful = true,
				Message = "Question types are found successfully.",
				listQuestionType = questionTypes.ToList()
			};
		}
	}
}
