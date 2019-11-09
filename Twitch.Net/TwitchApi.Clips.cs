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

        private const string _getClipsEndpoint = "https://api.twitch.tv/helix/clips";

        public async Task<HelixResponse<HelixClip>> GetClips(string[] clipIds)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>();
            parameters.AddRange(clipIds.Select(clipId => new KeyValuePair<string, string>("id", clipId)));

            var responseStream = await httpClient.GetAsync(_getClipsEndpoint, parameters, _clientId);

            return await JsonSerializer.DeserializeAsync<HelixResponse<HelixClip>>(responseStream);
        }

        public async Task<HelixPaginatedResponse<HelixClip>> GetClipsFromGames(string gameId, int first = 20, string after = null, string before = null)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("game_id", gameId),
                new KeyValuePair<string, string>("first", first.ToString())
            };

            if (string.IsNullOrEmpty(after) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("before", before));
            }

            var responseStream = await httpClient.GetAsync(_getClipsEndpoint, parameters, _clientId);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixClip>>(responseStream);
        }

        public async Task<HelixPaginatedResponse<HelixClip>> GetClipsFromBroadcaster(string broadcasterId, int first = 20, string after = null, string before = null)
        {
            using var httpClient = GetHttpClient();

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
                new KeyValuePair<string, string>("first", first.ToString())
            };

            if (string.IsNullOrEmpty(after) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("after", after));
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("before", before));
            }

            var responseStream = await httpClient.GetAsync(_getClipsEndpoint, parameters, _clientId);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixClip>>(responseStream);
        }

    }
}
