using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.Question
{
	public class QuestionType : BaseEntity, IEntity
	{
		public string QuestionTypeName { get; set; }

		public string Type { get; set; }

		public bool isActive { get; set; }


	}
}
