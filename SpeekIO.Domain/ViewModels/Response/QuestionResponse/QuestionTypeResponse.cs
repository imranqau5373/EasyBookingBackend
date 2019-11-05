using SpeekIO.Domain.Entities.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response.QuestionResponse
{
	public class QuestionTypeResponse : CommonResponse
	{
		public List<QuestionType> listQuestionType { get; set; }

	}
}
