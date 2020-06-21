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
        private const string _getBannedEventsEndpoint = "https://api.twitch.tv/helix/moderation/banned/events";

        internal ModerationActions(Func<TwitchHttpClient> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<HelixPaginatedResponse<HelixBannedUser>> GetBannedUsers(string broadcasterId, string[] userIds = null, string after = null, string before = null)
        {
            using var httpClient = _httpClientFactory();

            var parameters = GetBannedParameters(broadcasterId, userIds, after, before);

            var responseStream = await httpClient.GetAsync(_getBannedUsersEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixBannedUser>>(responseStream);
        }

        public async Task<HelixPaginatedResponse<HelixBannedUserEvent>> GetBannedEvents(string broadcasterId, string[] userIds = null, string after = null, string before = null)
        {
            using var httpClient = _httpClientFactory();

            var parameters = GetBannedParameters(broadcasterId, userIds, after, before);

            var responseStream = await httpClient.GetAsync(_getBannedEventsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixBannedUserEvent>>(responseStream);
        }

        private IEnumerable<KeyValuePair<string, string>> GetBannedParameters(string broadcasterId, string[] userIds, string after, string before)
        {
            yield return new KeyValuePair<string, string>("broadcaster_id", broadcasterId);

            if (userIds != null)
            {
                foreach (var userId in userIds)
                {
                    yield return new KeyValuePair<string, string>("user_id", userId);
                }
            }

            if (string.IsNullOrEmpty(after) == false)
            {
                yield return new KeyValuePair<string, string>("after", after);
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                yield return new KeyValuePair<string, string>("before", before);
            }
        }

    }
}
