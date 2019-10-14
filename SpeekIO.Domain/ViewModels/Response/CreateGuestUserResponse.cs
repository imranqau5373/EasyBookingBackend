using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response
{
    public class CreateGuestUserResponse : CommonResponse
    {
        public bool AlreadyExists { get; set; }
        public string AuthenticationToken { get; set; }
        public object Data { get; set; }
    }
}
