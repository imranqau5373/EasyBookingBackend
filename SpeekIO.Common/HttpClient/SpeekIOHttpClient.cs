using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpeekIO.Common.HttpClient
{
    internal class SpeekIOHttpClient : ISpeekIOHttpClient
    {
        public Task<T> GetAsync<T>(string url)
        {
            throw new NotImplementedException();
        }

        public Task<T> PostAsync<T>(string url, object payload)
        {
            throw new NotImplementedException();
        }
    }
}
