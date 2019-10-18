using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response
{
    public class SignupResponse : CommonResponse
    {
        public bool IsAlreadyRegistered { get; set; }
        public object Data { get; set; }
    }
}
