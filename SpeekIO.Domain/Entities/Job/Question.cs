using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.Job
{
    public class Question
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? LastUpdated { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
