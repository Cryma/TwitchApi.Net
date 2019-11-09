using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Response;

namespace Twitch.Net
{
    public partial class TwitchApi
    {

        private const string _getUsersEndpoint = "https://api.twitch.tv/helix/users";
        private const string _getUsersFollowsEndpoint = "https://api.twitch.tv/helix/users/follows";

        public async Task<TwitchResponse<TwitchUser>> GetUsers(string[] userIds)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>();
            parameters.AddRange(userIds.Select(userId => new KeyValuePair<string, string>("id", userId)));

            var responseStream = await httpClient.GetAsync(_getUsersEndpoint, parameters, _clientId);

            return await JsonSerializer.DeserializeAsync<TwitchResponse<TwitchUser>>(responseStream);
        }

        public async Task<TwitchPaginatedResponseWithTotal<TwitchFollow>> GetUsersFollows(int first = 20, string after = null, string toId = null, string fromId = null)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("first", first.ToString())
            };

            if(string.IsNullOrEmpty(after) == false)
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

            var responseStream = await httpClient.GetAsync(_getUsersFollowsEndpoint, parameters, _clientId);

            return await JsonSerializer.DeserializeAsync<TwitchPaginatedResponseWithTotal<TwitchFollow>>(responseStream);
        }

    }
}
