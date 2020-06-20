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
    public class BitActions : IBitActions
    {

        private readonly Func<TwitchHttpClient> _httpClientFactory;

        private const string _getCheermotesEndpoint = "https://api.twitch.tv/helix/bits/cheermotes";
        private const string _getBitsLeaderboardEndpoint = "https://api.twitch.tv/helix/bits/leaderboard";

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

        public async Task<HelixDateRangeResponseWithTotal<HelixBitsLeaderboardEntry>> GetBitsLeaderboard(string userId = null, int count = 10,
            HelixPeriodType period = HelixPeriodType.All, DateTime? startedAt = null)
        {
            using var httpClient = _httpClientFactory();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("count", count.ToString()),
                new KeyValuePair<string, string>("period", GetPeriodType(period))
            };

            if (userId != null)
            {
                parameters.Add(new KeyValuePair<string, string>("user_id", userId));
            }

            if (startedAt.HasValue)
            {
                parameters.Add(new KeyValuePair<string, string>("started_at", HttpUtility.UrlEncode(startedAt.Value.ToRfc3339String())));
            }

            var responseStream = await httpClient.GetAsync(_getBitsLeaderboardEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixDateRangeResponseWithTotal<HelixBitsLeaderboardEntry>>(responseStream);
        }

        private string GetPeriodType(HelixPeriodType period)
        {
            switch (period)
            {
                case HelixPeriodType.All:
                    return "all";
                case HelixPeriodType.Day:
                    return "day";
                case HelixPeriodType.Week:
                    return "week";
                case HelixPeriodType.Month:
                    return "month";
                case HelixPeriodType.Year:
                    return "year";
                default:
                    throw new ArgumentOutOfRangeException(nameof(period), period, null);
            }
        }

    }
}
