using SpeekIO.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpeekIO.Application.Interfaces.Identity
{
    public interface ITokenGenerator
    {
        Task<string> GenerateSignInTokenAsync(ApplicationUser user);
    }
}
