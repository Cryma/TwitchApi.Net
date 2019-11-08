using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using Twitch.Net.Models;
using Twitch.Net.Response;

namespace Twitch.Net
{
    public partial class TwitchApi
    {

        private const string _getTopGamesEndpoint = "https://api.twitch.tv/helix/games/top";
        private const string _getGamesEndpoint = "https://api.twitch.tv/helix/games";

        public async Task<(string, TwitchGame[])> GetTopGames(int first = 20, string after = null, string before = null)
        {
            using var httpClient = new TwitchHttpClient();

            var url = $"{_getTopGamesEndpoint}?first={first}";

            if (string.IsNullOrEmpty(after) == false)
            {
                url += $"&after={after}";
            }

            if (string.IsNullOrEmpty(before) == false)
            {
                url += $"&before={before}";
            }

            var responseStream = await httpClient.GetAsync(url, _clientId);

            var deserializedObject = await JsonSerializer.DeserializeAsync<TwitchPaginatedResponse<TwitchGame>>(responseStream);

            return (deserializedObject.Pagination.Cursor, deserializedObject.Data);
        }

        public async Task<TwitchGame[]> GetGames(string[] ids)
        {
            using var httpClient = new TwitchHttpClient();

            var url = $"{_getGamesEndpoint}?{GetQueryForParameters("id", ids)}";
            var responseStream = await httpClient.GetAsync(url, _clientId);

            var deserializedObject = await JsonSerializer.DeserializeAsync<TwitchResponse<TwitchGame>>(responseStream);

            return deserializedObject.Data;
        }

        public async Task<TwitchGame> GetGame(string id)
        {
            return (await GetGames(new[] {id})).FirstOrDefault();
        }

    }
}
