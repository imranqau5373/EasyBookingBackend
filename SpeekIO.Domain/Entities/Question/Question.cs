using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.Question
{
    public class Question : BaseEntity, IEntity
    {
        public long QuestionaireId { get; set; }
        public Questionaire.Questionaire Questionaire { get; set; }
    }
}
