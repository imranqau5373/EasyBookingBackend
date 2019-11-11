using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response
{
    public class SignInResponse : CommonResponse
    {
        public string AuthenticationToken { get; set; }

        public string UserName { get; set; }

        public string AdminRole { get; set; }

        public string PictureUrl { get; set; }
    }
}
