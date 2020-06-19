using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Twitch.Net.Interfaces;
using Twitch.Net.Models;
using Twitch.Net.Models.Responses;
using Twitch.Net.Utility;

namespace Twitch.Net.Elements
{
    public class BitActions : IBitActions
    {

        private readonly Func<TwitchHttpClient> _httpClientFactory;

        private const string _getCheermotesEndpoint = "https://api.twitch.tv/helix/bits/cheermotes";

        internal BitActions(Func<TwitchHttpClient> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HelixResponse<HelixCheermote>> GetCheermotes(string userId = null)
        {
            using var httpClient = _httpClientFactory();

            var parameters = new List<KeyValuePair<string, string>>();

            if (userId != null)
            {
                parameters.Add(new KeyValuePair<string, string>("broadcaster_id", userId));
            }

            var responseStream = await httpClient.GetAsync(_getCheermotesEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixResponse<HelixCheermote>>(responseStream);
        }
    }
}
