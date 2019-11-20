using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.Questionaire
{
    public class Questionaire : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public ICollection<Question.Question> Questions { get; set; }

    }
}
