using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.ViewModels.Response.QuestionaireResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Queries.Questionaire
{
	public class QuestionaireQueryHandler : IRequestHandler<QuestionaireQuery, QuestionaireResponse>
	{

		private readonly ILogger<QuestionaireQueryHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly ISpeekIODbContext _context;
		public QuestionaireQueryHandler(ILogger<QuestionaireQueryHandler> logger, AutoMapper.IMapper mapper, ISpeekIODbContext context)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}

		public async Task<QuestionaireResponse> Handle(QuestionaireQuery request, CancellationToken cancellationToken)
		{
			var questionaires = await _context.Questionaires.ToListAsync();
			if (questionaires == null)
			{
				return new QuestionaireResponse()
				{
					Successful = false,
					Message = "Question types not found."
				};
			}
			return new QuestionaireResponse()
			{
				Successful = true,
				Message = "Question types are found successfully.",
				listQuestionaire = questionaires.ToList()
			};
		}
	}
}
