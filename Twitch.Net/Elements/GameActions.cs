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
    public class GameActions : IGameActions
    {

        private readonly Func<TwitchHttpClient> _httpClientFactory;

        private const string _getTopGamesEndpoint = "https://api.twitch.tv/helix/games/top";
        private const string _getGamesEndpoint = "https://api.twitch.tv/helix/games";

        internal GameActions(Func<TwitchHttpClient> httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<HelixPaginatedResponse<HelixGame>> GetTopGames(int first = 20, string after = null, string before = null)
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

            if (string.IsNullOrEmpty(before) == false)
            {
                parameters.Add(new KeyValuePair<string, string>("before", before));
            }

            var responseStream = await httpClient.GetAsync(_getTopGamesEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixPaginatedResponse<HelixGame>>(responseStream);
        }

        public async Task<HelixResponse<HelixGame>> GetGames(string[] gameIds)
        {
            using var httpClient = _httpClientFactory();

            var parameters = new List<KeyValuePair<string, string>>();

            parameters.AddRange(gameIds.Select(gameId => new KeyValuePair<string, string>("id", gameId)));

            var responseStream = await httpClient.GetAsync(_getGamesEndpoint, parameters);

            return await JsonSerializer.DeserializeAsync<HelixResponse<HelixGame>>(responseStream);
        }

    }
}
