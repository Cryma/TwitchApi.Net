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

        private const string _getStreamsEndpoint = "https://api.twitch.tv/helix/streams";

        public async Task<TwitchPaginatedResponse<TwitchStream>> GetStreams(string[] gameIds, int first = 20, string after = null, string before = null)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("first", first.ToString())
            };

            parameters.AddRange(gameIds.Select(gameId => new KeyValuePair<string, string>("game_id", gameId)));

            if (string.IsNullOrEmpty(after) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("before", before));
            }

            var responseStream = await httpClient.GetAsync(_getStreamsEndpoint, parameters, _clientId);

            return await JsonSerializer.DeserializeAsync<TwitchPaginatedResponse<TwitchStream>>(responseStream);
        }

        public async Task<TwitchPaginatedResponse<TwitchStream>> GetStreams(string[] userIds, string after = null, string before = null, int first = 20)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("first", first.ToString())
            };

            parameters.AddRange(userIds.Select(userId => new KeyValuePair<string, string>("user_id", userId)));

            if (string.IsNullOrEmpty(after) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("before", before));
            }

            var responseStream = await httpClient.GetAsync(_getStreamsEndpoint, parameters, _clientId);

            return await JsonSerializer.DeserializeAsync<TwitchPaginatedResponse<TwitchStream>>(responseStream);
        }

    }
}
