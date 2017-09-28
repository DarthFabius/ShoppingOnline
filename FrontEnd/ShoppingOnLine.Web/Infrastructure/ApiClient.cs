using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ShoppingOnLine.Web.Infrastructure
{
    public class ApiClient<TRequest, TResponse> : IDisposable
    {       
        public static async Task<TResponse> PostAsync(string endPoint, TRequest request)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri("http://localhost:6740");

                HttpResponseMessage response = await client.PostAsJsonAsync(endPoint , request);
                response.EnsureSuccessStatusCode();

                // Return the URI of the created resource.
                return (TResponse) await response.Content.ReadAsAsync<TResponse>();
            }
        }

        public void Dispose()
        {
            
        }
    }
}
