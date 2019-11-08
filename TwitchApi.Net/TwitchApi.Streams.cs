using System.Text.Json;
using System.Threading.Tasks;
using TwitchApi.Net.Models;
using TwitchApi.Net.Response;
using TwitchApi.Net.Utility;

namespace TwitchApi.Net
{
    public partial class TwitchApi
    {

        private const string _getStreamsEndpoint = "https://api.twitch.tv/helix/streams";

        public async Task<TwitchPaginatedResponse<TwitchStream>> GetStreams(string[] gameIds, int first = 20, string after = null, string before = null)
        {
            using var httpClient = new TwitchHttpClient();

            var url = $"{_getStreamsEndpoint}?first={first}&{GetQueryForParameters("game_id", gameIds)}";

            if (string.IsNullOrEmpty(after) == false)
            {
                url += $"&after={after}";
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                url += $"&before={before}";
            }

            var responseStream = await httpClient.GetAsync(url, _clientId);

            return await JsonSerializer.DeserializeAsync<TwitchPaginatedResponse<TwitchStream>>(responseStream);
        }

        public async Task<TwitchPaginatedResponse<TwitchStream>> GetStreams(string[] userIds, string after = null, string before = null, int first = 20)
        {
            using var httpClient = new TwitchHttpClient();

            var url = $"{_getStreamsEndpoint}?first={first}&{GetQueryForParameters("user_id", userIds)}";

            if (string.IsNullOrEmpty(after) == false)
            {
                url += $"&after={after}";
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                url += $"&before={before}";
            }

            var responseStream = await httpClient.GetAsync(url, _clientId);

            return await JsonSerializer.DeserializeAsync<TwitchPaginatedResponse<TwitchStream>>(responseStream);
        }

    }
}
