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

        internal AnalyticActions(Func<TwitchHttpClient> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HelixResponse<HelixExtensionAnalytic>> GetExtensionAnalytic(string extensionId = null, int first = 20, string after = null,
            DateTime? startedAt = null, DateTime? endedAt = null)
        {
            using var httpClient = _httpClientFactory();

            var parameters = GetExtensionAnalyticParameters(extensionId, first, after, startedAt, endedAt);

            var responseStream = await httpClient.GetAsync(_extionsionAnalyticsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixResponse<HelixExtensionAnalytic>>(responseStream);
        }

        public async Task<HelixPaginatedResponse<HelixExtensionAnalytic>> GetExtensionAnalyticWithType(HelixExtensionAnalyticType type, string extensionId = null, int first = 20,
            string after = null, DateTime? startedAt = null, DateTime? endedAt = null)
        {
            using var httpClient = _httpClientFactory();

            var parameters = GetExtensionAnalyticParameters(extensionId, first, after, startedAt, endedAt);

            parameters.Add(new KeyValuePair<string, string>("type", GetExtensionAnalyticsType(type)));

            var responseStream = await httpClient.GetAsync(_extionsionAnalyticsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixExtensionAnalytic>>(responseStream);
        }

        private List<KeyValuePair<string, string>> GetExtensionAnalyticParameters(string extensionId, int first, string after, DateTime? startedAt, DateTime? endedAt)
        {
            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("first", first.ToString())
            };

            if (extensionId != null)
            {
                parameters.Add(new KeyValuePair<string, string>("extension_id", extensionId));
            }

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

        private string GetExtensionAnalyticsType(HelixExtensionAnalyticType type)
        {
            switch (type)
            {
                case HelixExtensionAnalyticType.OverviewV1:
                    return "overview_v1";
                case HelixExtensionAnalyticType.OverviewV2:
                    return "overview_v2";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

    }
}
