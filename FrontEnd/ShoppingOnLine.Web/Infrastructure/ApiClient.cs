using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ShoppingOnLine.Web.Infrastructure
{
    public class ApiClient : IDisposable
    {
        private string _baseAddress;
        private HttpClient _client;
        public ApiClient(string baseAddress)
        {
            _baseAddress = baseAddress ?? throw new ArgumentNullException(nameof(baseAddress));
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(_baseAddress);

        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(PathString endPoint, TRequest request)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(_baseAddress);

                HttpResponseMessage response = await client.PostAsJsonAsync<TRequest>(endPoint , request );
                response.EnsureSuccessStatusCode();

                // Return the URI of the created resource.
                return (TResponse) await response.Content.ReadAsAsync<TResponse>();
            }
        }

        public async Task<TResult> GetAsync<TResult>(PathString endPoint, string id = "")
        {
            if ( !string.IsNullOrEmpty(id))
            {
                endPoint.Add(id);
            }

            HttpResponseMessage response = await _client.GetAsync(endPoint);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<TResult>();
        }
        
        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
