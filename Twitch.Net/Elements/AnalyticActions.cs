using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Twitch.Net.Interfaces;
using Twitch.Net.Models;
using Twitch.Net.Models.Enums;
using Twitch.Net.Models.Responses;
using Twitch.Net.Utility;

namespace Twitch.Net.Elements
{
    public class AnalyticActions : IAnalyticActions
    {

        private readonly Func<TwitchHttpClient> _httpClientFactory;

        private const string _extionsionAnalyticsEndpoint = "https://api.twitch.tv/helix/analytics/extensions";
        private const string _gameAnalyticsEndpoint = "https://api.twitch.tv/helix/analytics/games";

        internal AnalyticActions(Func<TwitchHttpClient> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HelixResponse<HelixExtensionAnalytic>> GetExtensionAnalytic(string extensionId = null, int first = 20, string after = null,
            DateTime? startedAt = null, DateTime? endedAt = null)
        {
            using var httpClient = _httpClientFactory();

            var parameters = GetAnalyticParameters(first, after, startedAt, endedAt);

            if (extensionId != null)
            {
                parameters.Add(new KeyValuePair<string, string>("extension_id", extensionId));
            }

            var responseStream = await httpClient.GetAsync(_extionsionAnalyticsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixResponse<HelixExtensionAnalytic>>(responseStream);
        }

        public async Task<HelixPaginatedResponse<HelixExtensionAnalytic>> GetExtensionAnalyticsWithType(HelixAnalyticType type, string extensionId = null, int first = 20,
            string after = null, DateTime? startedAt = null, DateTime? endedAt = null)
        {
            using var httpClient = _httpClientFactory();

            var parameters = GetAnalyticParameters(first, after, startedAt, endedAt);
            parameters.Add(new KeyValuePair<string, string>("type", GetAnalyticsType(type)));

            if (extensionId != null)
            {
                parameters.Add(new KeyValuePair<string, string>("extension_id", extensionId));
            }

            var responseStream = await httpClient.GetAsync(_extionsionAnalyticsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixExtensionAnalytic>>(responseStream);
        }

        public async Task<HelixResponse<HelixGameAnalytic>> GetGameAnalytic(string gameId = null, int first = 20, string after = null, DateTime? startedAt = null,
            DateTime? endedAt = null)
        {
            using var httpClient = _httpClientFactory();

            var parameters = GetAnalyticParameters(first, after, startedAt, endedAt);

            if (gameId != null)
            {
                parameters.Add(new KeyValuePair<string, string>("game_id", gameId));
            }

            var responseStream = await httpClient.GetAsync(_gameAnalyticsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixResponse<HelixGameAnalytic>>(responseStream);
        }

        public async Task<HelixPaginatedResponse<HelixGameAnalytic>> GetGameAnalyticsWithType(HelixAnalyticType type, string gameId = null, int first = 20,
            string after = null, DateTime? startedAt = null, DateTime? endedAt = null)
        {
            using var httpClient = _httpClientFactory();

            var parameters = GetAnalyticParameters(first, after, startedAt, endedAt);
            parameters.Add(new KeyValuePair<string, string>("type", GetAnalyticsType(type)));

            if (gameId != null)
            {
                parameters.Add(new KeyValuePair<string, string>("game_id", gameId));
            }

            var responseStream = await httpClient.GetAsync(_gameAnalyticsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixGameAnalytic>>(responseStream);
        }

        private List<KeyValuePair<string, string>> GetAnalyticParameters(int first, string after, DateTime? startedAt, DateTime? endedAt)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("first", first.ToString())
            };

            if (after != null)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            if (startedAt.HasValue)
            {
                parameters.Add(new KeyValuePair<string, string>("started_at", HttpUtility.UrlEncode(startedAt.Value.ToRfc3339String())));
            }

            if (endedAt.HasValue)
            {
                parameters.Add(new KeyValuePair<string, string>("started_at", HttpUtility.UrlEncode(endedAt.Value.ToRfc3339String())));
            }

            return parameters;
        }

        private string GetAnalyticsType(HelixAnalyticType type)
        {
            switch (type)
            {
                case HelixAnalyticType.OverviewV1:
                    return "overview_v1";
                case HelixAnalyticType.OverviewV2:
                    return "overview_v2";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

    }
}
