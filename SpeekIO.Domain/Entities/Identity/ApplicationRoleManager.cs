﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.Identity
{
    public class ApplicationRoleManager : RoleManager<UserRole>
    {
        public ApplicationRoleManager(IRoleStore<UserRole> store, 
            IEnumerable<IRoleValidator<UserRole>> roleValidators, 
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors, 
            ILogger<RoleManager<UserRole>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
