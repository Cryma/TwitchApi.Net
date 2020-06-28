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
    public class ChannelActions : IChannelActions
    {

        private readonly Func<TwitchHttpClient> _httpClientFactory;

        private const string _channelInformationEndpoint = "https://api.twitch.tv/helix/channels";

        internal ChannelActions(Func<TwitchHttpClient> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HelixResponse<HelixChannelInformation>> GetChannelInformation(string userId)
        {
            using var httpClient = _httpClientFactory();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("broadcaster_id", userId)
            };

            var responseStream = await httpClient.GetAsync(_channelInformationEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixResponse<HelixChannelInformation>>(responseStream);
        }

    }
}
