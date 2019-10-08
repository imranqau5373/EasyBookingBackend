using Microsoft.AspNetCore.Identity;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.Identity
{
    public class UserRole : IdentityRole<long>, IEntity
    {
    }
}
