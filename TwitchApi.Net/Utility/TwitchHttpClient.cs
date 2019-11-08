using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TwitchApi.Net.Exceptions;

namespace TwitchApi.Net.Utility
{
    public class TwitchHttpClient : IDisposable
    {

        private readonly HttpClient _httpClient = new HttpClient();

        private readonly RatelimitBypass _ratelimitBypass;

        public TwitchHttpClient(RatelimitBypass ratelimitBypass)
        {
            _ratelimitBypass = ratelimitBypass;
        }

        public async Task<Stream> GetAsync(string url, string clientId = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            if (string.IsNullOrEmpty(clientId) == false)
            {
                request.Headers.Add("Client-ID", clientId);
            }

            if (_ratelimitBypass != null)
            {
                await _ratelimitBypass.Wait();
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
