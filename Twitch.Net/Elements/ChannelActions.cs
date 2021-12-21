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

        public async Task ModifyChannelInformation(string userId, string status = null, string gameId = null, string broadcasterLanguage = null,
            string title = null, string description = null)
        {
            using var httpClient = _httpClientFactory();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("broadcaster_id", userId)
            };

            if (string.IsNullOrEmpty(status) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("status", status));
            }

            if (string.IsNullOrEmpty(gameId) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("game_id", gameId));
            }

            if (string.IsNullOrEmpty(broadcasterLanguage) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("broadcaster_language", broadcasterLanguage));
            }

            if (string.IsNullOrEmpty(title) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("title", title));
            }

            if (string.IsNullOrEmpty(description) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("description", description));
            }

            await httpClient.PatchAsync(_channelInformationEndpoint, parameters);
        }
    }
}
