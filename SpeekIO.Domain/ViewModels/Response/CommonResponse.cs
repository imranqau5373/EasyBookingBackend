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

        public static T CreateFailedResponse<T>(string message) where T : CommonResponse
        {
            var instance = Activator.CreateInstance<T>();
            instance.Successful = false;
            instance.Message = message;

            return instance;
        }

        public static T CreateSuccessResponse<T>(string message) where T : CommonResponse
        {
            var instance = Activator.CreateInstance<T>();
            instance.Successful = true;
            instance.Message = message;

            return instance;
        }
    }
}
