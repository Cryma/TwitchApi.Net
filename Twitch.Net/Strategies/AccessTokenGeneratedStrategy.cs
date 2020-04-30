using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Twitch.Net.Interfaces;
using Twitch.Net.Response;

namespace Twitch.Net.Strategies
{
    internal class AccessTokenGeneratedStrategy : IAccessTokenStrategy
    {

        private const string _postTokenEndpoint = "https://id.twitch.tv/oauth2/token";

        private readonly string _clientId;
        private readonly string _clientSecret;

        private DateTime _accessTokenExpiresAt;

        private string _accessToken;

        public AccessTokenGeneratedStrategy(string clientId, string clientSecret)
        {
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        public async Task<string> GetAccessToken()
        {
            if (string.IsNullOrEmpty(_accessToken) || DateTime.UtcNow >= _accessTokenExpiresAt)
            {
                await FetchAccessToken();
            }

            return _accessToken;
        }

        private async Task FetchAccessToken()
        {
            using var httpClient = new HttpClient();

            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", _clientId),
                new KeyValuePair<string, string>("client_secret", _clientSecret),
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
            });

            var responseStream = await httpClient.PostAsync(_postTokenEndpoint, content);

            var response = await JsonSerializer.DeserializeAsync<TokenResponse>(await responseStream.Content.ReadAsStreamAsync());

            _accessToken = response.AccessToken;
            _accessTokenExpiresAt = DateTime.UtcNow.AddSeconds(response.ExpiresIn);
        }

    }
}
