using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Twitch.Net.Interfaces;
using Twitch.Net.Models;
using Twitch.Net.Models.Responses;
using Twitch.Net.Utility;

namespace Twitch.Net.Elements
{
    public class ClipActions : IClipActions
    {
        private readonly Func<TwitchHttpClient> _httpClientFactory;

        private const string _getClipsEndpoint = "https://api.twitch.tv/helix/clips";

        internal ClipActions(Func<TwitchHttpClient> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HelixResponse<HelixClip>> GetClips(string[] clipIds)
        {
            using var httpClient = _httpClientFactory();

            var parameters = new List<KeyValuePair<string, string>>();
            parameters.AddRange(clipIds.Select(clipId => new KeyValuePair<string, string>("id", clipId)));

            var responseStream = await httpClient.GetAsync(_getClipsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixResponse<HelixClip>>(responseStream);
        }

        public async Task<HelixPaginatedResponse<HelixClip>> GetClipsFromGames(string gameId, int first = 20, string after = null, string before = null)
        {
            using var httpClient = _httpClientFactory();

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

            var responseStream = await httpClient.GetAsync(_getClipsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixClip>>(responseStream);
        }

        public async Task<HelixPaginatedResponse<HelixClip>> GetClipsFromBroadcaster(string broadcasterId, int first = 20, string after = null, string before = null, DateTime? startedAt = null, DateTime? endedAt = null)
        {
            using var httpClient = _httpClientFactory();

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

            if (startedAt.HasValue)
            {
                parameters.Add(new KeyValuePair<string, string>("started_at", HttpUtility.UrlEncode(startedAt.Value.ToRfc3339String())));
            }

            if (endedAt.HasValue)
            {
                parameters.Add(new KeyValuePair<string, string>("ended_at", HttpUtility.UrlEncode(endedAt.Value.ToRfc3339String())));
            }

            var responseStream = await httpClient.GetAsync(_getClipsEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixClip>>(responseStream);
        }

    }
}
