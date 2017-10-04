using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace System.Net.Http
{
    public static class HttpContentExtension
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent httpContent)
        {
            var responseString = await httpContent.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}
