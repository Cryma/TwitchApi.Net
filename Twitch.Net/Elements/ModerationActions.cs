using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Twitch.Net.Interfaces;
using Twitch.Net.Models;
using Twitch.Net.Models.Responses;
using Twitch.Net.Utility;

namespace Twitch.Net.Elements
{
    public class ModerationActions : IModerationActions
    {

        private readonly Func<TwitchHttpClient> _httpClientFactory;

        private const string _getBannedUsersEndpoint = "https://api.twitch.tv/helix/moderation/banned";

        internal ModerationActions(Func<TwitchHttpClient> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<HelixPaginatedResponse<HelixBannedUser>> GetBannedUsers(string broadcasterId, string[] userIds = null, string after = null, string before = null)
        {
            using var httpClient = _httpClientFactory();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
            };

            if (userIds != null)
            {
                parameters.AddRange(userIds.Select(userId=> new KeyValuePair<string, string>("user_id", userId)));
            }

            if (string.IsNullOrEmpty(after) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("before", before));
            }

            var responseStream = await httpClient.GetAsync(_getBannedUsersEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixBannedUser>>(responseStream);
        }

    }
}
