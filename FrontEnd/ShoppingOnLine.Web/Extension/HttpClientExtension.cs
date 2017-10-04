using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace System.Net.Http
{
    public static class HttpClientExtension
    {
        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient httpClient, string requestUri, T value)
        {
            var contentJson = JsonConvert.SerializeObject(value);
            return httpClient.PostAsync(requestUri, new StringContent(contentJson));
        }
    }
}
