using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response
{
    public class CommonResponse
    {
        public CommonResponse()
        {

        }
        public CommonResponse(bool success, string message)
        {
            Successful = success;
            Message = message;
        }
        public bool Successful { get; set; }
        public string Message { get; set; }
    }
}
