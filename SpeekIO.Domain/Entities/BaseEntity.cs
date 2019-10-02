using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities
{
    public class BaseEntity : IEntity
    {
        public virtual string Id { get; set; }
    }
}
