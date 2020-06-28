using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Twitch.Net.Interfaces;
using Twitch.Net.Models;
using Twitch.Net.Models.Enums;
using Twitch.Net.Models.Responses;
using Twitch.Net.Utility;

namespace Twitch.Net.Elements
{
    public class AdActions : IAdActions
    {

        private readonly Func<TwitchHttpClient> _httpClientFactory;

        private const string _adsEndpoint = "https://api.twitch.tv/helix/channels/commercial";

        internal AdActions(Func<TwitchHttpClient> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HelixResponse<HelixCommercial>> StartCommercial(string userId, HelixCommercialLength length)
        {
            using var httpClient = _httpClientFactory();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("broadcaster_id", userId),
                new KeyValuePair<string, string>("length", GetCommercialLength(length))
            };

            var responseStream = await httpClient.PostAsync(_adsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixResponse<HelixCommercial>>(responseStream);
        }

        private string GetCommercialLength(HelixCommercialLength length)
        {
            switch (length)
            {
                case HelixCommercialLength.ThirtySeconds:
                    return "30";
                case HelixCommercialLength.SixtySeconds:
                    return "60";
                case HelixCommercialLength.NinetySeconds:
                    return "90";
                case HelixCommercialLength.OneHundredAndTwentySeconds:
                    return "120";
                case HelixCommercialLength.OneHundredAndFiftySeconds:
                    return "150";
                case HelixCommercialLength.OneHundredAndEightySeconds:
                    return "180";
                default:
                    throw new ArgumentOutOfRangeException(nameof(length), length, null);
            }
        }

    }
}
