using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.Other
{
    public class Language : BaseEntity, IEntity
    {
        public string Name { get; set; }
    }
}
