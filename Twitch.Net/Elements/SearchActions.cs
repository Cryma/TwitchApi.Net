using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Twitch.Net.Interfaces;
using Twitch.Net.Models;
using Twitch.Net.Models.Responses;
using Twitch.Net.Utility;

namespace Twitch.Net.Elements
{
    public class SearchActions : ISearchActions
    {
        private readonly Func<TwitchHttpClient> _httpClientFactory;

        private const string _searchCategoriesEndpoint = "https://api.twitch.tv/helix/search/categories";
        private const string _searchChannelsEndpoint = "https://api.twitch.tv/helix/search/channels";

        internal SearchActions(Func<TwitchHttpClient> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HelixPaginatedResponse<HelixCategory>> SearchCategories(string query, int first = 20, string after = null)
        {
            using var httpClient = _httpClientFactory();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("query", HttpUtility.UrlEncode(query)),
                new KeyValuePair<string, string>("first", first.ToString())
            };

            if (string.IsNullOrEmpty(after) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            var responseStream = await httpClient.GetAsync(_searchCategoriesEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixCategory>>(responseStream);
        }

        public async Task<HelixPaginatedResponse<HelixChannel>> SearchChannels(string query, int first = 20, string after = null, bool liveOnly = false)
        {
            using var httpClient = _httpClientFactory();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("query", HttpUtility.UrlEncode(query)),
                new KeyValuePair<string, string>("first", first.ToString()),
                new KeyValuePair<string, string>("live_only", liveOnly.ToString())
            };

            if (string.IsNullOrEmpty(after) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            var responseStream = await httpClient.GetAsync(_searchChannelsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixChannel>>(responseStream);
        }

    }
}
