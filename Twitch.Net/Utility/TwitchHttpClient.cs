using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Twitch.Net.Exceptions;
using Twitch.Net.Interfaces;

namespace Twitch.Net.Utility
{
    internal class TwitchHttpClient : IDisposable
    {

        private readonly HttpClient _httpClient = new HttpClient();

        private readonly string _clientId;

        private readonly IAccessTokenStrategy _accessTokenStrategy;
        private readonly IRateLimitStrategy _rateLimitStrategy;

        public TwitchHttpClient(string clientId, IAccessTokenStrategy accessTokenStrategy, IRateLimitStrategy rateLimitStrategy)
        {
            _clientId = clientId;

            _accessTokenStrategy = accessTokenStrategy;
            _rateLimitStrategy = rateLimitStrategy;
        }

        public async Task<Stream> GetAsync(string url, List<KeyValuePair<string, string>> getParameters)
        {
            var parameters = new StringBuilder();
            if (getParameters != null)
            {
                foreach (var pair in getParameters)
                {
                    parameters.Append($"{pair.Key}={pair.Value}&");
                }
            }

            var request = new HttpRequestMessage(HttpMethod.Get, $"{url}?{parameters}");
            request.Headers.Add("Authorization", $"Bearer {await _accessTokenStrategy.GetAccessToken()}");
            request.Headers.Add("Client-ID", _clientId);

            await _rateLimitStrategy.Wait();

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStreamAsync();
            }

            HandleExceptions(response);

            return null;
        }

        public async Task<Stream> PostAsync(string url, List<KeyValuePair<string, string>> bodyParameters)
        {
            var body = new FormUrlEncodedContent(bodyParameters);

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Add("Authorization", $"Bearer {await _accessTokenStrategy.GetAccessToken()}");
            request.Headers.Add("Client-ID", _clientId);
            request.Content = body;

            await _rateLimitStrategy.Wait();

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStreamAsync();
            }

            Console.WriteLine(await response.Content.ReadAsStringAsync());

            HandleExceptions(response);

            return null;
        }

        private void HandleExceptions(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    throw new TwitchUnauthorizedException("No valid Client-ID or OAuth token specified!");

                case HttpStatusCode.InternalServerError:
                    throw new TwitchInternalServerErrorException("500 Internal Server Error!");

                case (HttpStatusCode) 429:
                    throw new TwitchTooManyRequestsException("Too many requests - make sure not to exceed the rate-limit!");

                default:
                    throw new HttpRequestException($"Request failed with status code: {response.StatusCode}");
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

    }
}
