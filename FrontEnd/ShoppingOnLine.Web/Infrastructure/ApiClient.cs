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
        private string _serviceName = null;
        private HttpClient _client;

        public ApiClient(string baseAddress)
        {
            _baseAddress = baseAddress ?? throw new ArgumentNullException(nameof(baseAddress));
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(_baseAddress);

        }
        public ApiClient(string baseAddress, string serviceName)
        {
            _baseAddress = baseAddress ?? throw new ArgumentNullException(nameof(baseAddress));
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(_baseAddress);

            _serviceName = new PathString(serviceName);
        }

        public Task PostAsync<TRequest>(TRequest request)
        {
            return PostAsync<TRequest>(request);
        }
        public async Task PostAsync<TRequest>(PathString endPoint, TRequest request)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(_baseAddress);

                HttpResponseMessage response = await client.PostAsJsonAsync<TRequest>(endPoint, request);
                response.EnsureSuccessStatusCode();
            }
        }
        public Task<TResponse> PostAsync<TRequest, TResponse>(TRequest request)
        {
            return PostAsync<TRequest, TResponse>(_serviceName, request);
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
        public Task<TResult> GetAsync<TResult>(string id = "")
        {
            return GetAsync<TResult>(_serviceName, id);
        }
        public async Task<TResult> GetAsync<TResult>(PathString endPoint, string id = "")
        {
            if ( !string.IsNullOrEmpty(id))
            {
                endPoint = endPoint.Add($"/{id}");
            }

            HttpResponseMessage response = await _client.GetAsync(endPoint);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<TResult>();
        }

        public Task PutAsync<TRequest>(string id, TRequest request)
        {
            return PutAsync<TRequest>(_serviceName, id, request);
        }
        public async Task PutAsync<TRequest>(PathString endPoint, string id, TRequest request)
        {
            endPoint = endPoint.Add($"/{id}");

            _client.BaseAddress = new Uri(_baseAddress);

            HttpResponseMessage response = await _client.PutAsJsonAsync<TRequest>(endPoint, request);
            response.EnsureSuccessStatusCode();
        }
        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
