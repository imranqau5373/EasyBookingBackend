using SpeekIO.Domain.Entities.Question;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response.JobsResponse.Questionaire
{
    public class AddQuestionaireResponse:CommonResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}
