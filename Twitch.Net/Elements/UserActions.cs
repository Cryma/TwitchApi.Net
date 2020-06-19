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
    public class UserActions : IUserActions
    {

        private const string _getUsersEndpoint = "https://api.twitch.tv/helix/users";
        private const string _getUsersFollowsEndpoint = "https://api.twitch.tv/helix/users/follows";

        private readonly Func<TwitchHttpClient> _httpClientFactory;

        internal UserActions(Func<TwitchHttpClient> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HelixResponse<HelixUser>> GetUsersWithIds(string[] userIds)
        {
            using var httpClient = _httpClientFactory();

            var parameters = new List<KeyValuePair<string, string>>();

            parameters.AddRange(userIds.Select(userId => new KeyValuePair<string, string>("id", userId)));

            var responseStream = await httpClient.GetAsync(_getUsersEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixResponse<HelixUser>>(responseStream);
        }

        public async Task<HelixResponse<HelixUser>> GetUsersWithLoginNames(string[] userLoginNames)
        {
            using var httpClient = _httpClientFactory();

            var parameters = new List<KeyValuePair<string, string>>();

            parameters.AddRange(userLoginNames.Select(userId => new KeyValuePair<string, string>("login", userId)));

            var responseStream = await httpClient.GetAsync(_getUsersEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixResponse<HelixUser>>(responseStream);
        }

        public async Task<HelixPaginatedResponseWithTotal<HelixFollow>> GetUsersFollows(int first = 20, string after = null, string toId = null, string fromId = null)
        {
            using var httpClient = _httpClientFactory();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("first", first.ToString())
            };

            if (string.IsNullOrEmpty(after) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            if (string.IsNullOrEmpty(toId) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("to_id", toId));
            }

            if (string.IsNullOrEmpty(fromId) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("from_id", fromId));
            }

            var responseStream = await httpClient.GetAsync(_getUsersFollowsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponseWithTotal<HelixFollow>>(responseStream);
        }

    }
}
