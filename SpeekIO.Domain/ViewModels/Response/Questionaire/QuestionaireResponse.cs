using SpeekIO.Domain.Entities.Questionaire;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response.QuestionaireResponse
{
	public class QuestionaireResponse : CommonResponse
	{
		public List<Questionaire> listQuestionaire { get; set; }

	}
}
