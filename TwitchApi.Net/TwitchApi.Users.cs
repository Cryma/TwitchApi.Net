using System.Text.Json;
using System.Threading.Tasks;
using TwitchApi.Net.Models;
using TwitchApi.Net.Response;
using TwitchApi.Net.Utility;

namespace TwitchApi.Net
{
    public partial class TwitchApi
    {

        private const string _getUsersEndpoint = "https://api.twitch.tv/helix/users";
        private const string _getUsersFollowsEndpoint = "https://api.twitch.tv/helix/users/follows";

        public async Task<TwitchResponse<TwitchUser>> GetUsers(string[] ids)
        {
            using var httpClient = GetHttpClient();

            var url = $"{_getUsersEndpoint}?{GetQueryForParameters("id", ids)}";
            var responseStream = await httpClient.GetAsync(url, _clientId);

            return await JsonSerializer.DeserializeAsync<TwitchResponse<TwitchUser>>(responseStream);
        }

        public async Task<TwitchPaginatedResponseWithTotal<TwitchFollow>> GetUsersFollows(int first = 20, string after = null, string toId = null, string fromId = null)
        {
            using var httpClient = GetHttpClient();

            var url = $"{_getUsersFollowsEndpoint}?first={first}";

            if(string.IsNullOrEmpty(after) == false)
            {
                url += $"&after={after}";
            }

            if (string.IsNullOrEmpty(toId) == false)
            {
                url += $"&to_id={toId}";
            }

            if (string.IsNullOrEmpty(fromId) == false)
            {
                url += $"&from_id={fromId}";
            }

            var responseStream = await httpClient.GetAsync(url, _clientId);

            return await JsonSerializer.DeserializeAsync<TwitchPaginatedResponseWithTotal<TwitchFollow>>(responseStream);
        }

    }
}
