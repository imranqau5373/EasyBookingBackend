using Microsoft.AspNetCore.Identity;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser<long>, IEntity
    {
        public Profile UserProfile { get; set; }
    }
}
