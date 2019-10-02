using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpeekIO.Common.HttpClient
{
    public interface ISpeekIOHttpClient
    {
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<T>(string url, object payload);
    }
}
