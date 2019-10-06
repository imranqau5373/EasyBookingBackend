using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.Identity
{
    public class Profile : BaseEntity, IEntity
    {
        public string FirstName { get; set; }

        public ApplicationUser User { get; set; }
    }
}
