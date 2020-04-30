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

        private readonly IRateLimitStrategy _rateLimitStrategy;
        private readonly string _clientId;
        private readonly string _accessToken;

        public TwitchHttpClient(IRateLimitStrategy ratelimitBypass, string clientId, string accessToken)
        {
            _rateLimitStrategy = ratelimitBypass;
            _clientId = clientId;
            _accessToken = accessToken;
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

            if (string.IsNullOrEmpty(_clientId) == false)
            {
                request.Headers.Add("Client-ID", _clientId);
            }

            if (string.IsNullOrEmpty(_accessToken) == false)
            {
                request.Headers.Add("Authorization", $"Bearer {_accessToken}");
            }

            if (_rateLimitStrategy != null)
            {
                await _rateLimitStrategy.Wait();
            }

            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStreamAsync();
            }

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
                    throw new HttpRequestException();
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

    }
}
