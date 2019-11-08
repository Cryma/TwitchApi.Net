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

        public async Task<TwitchUser> GetUser(string id)
        {
            using var httpClient = new TwitchHttpClient();

            var url = $"{_getUsersEndpoint}?{GetQueryForParameters("id", new[] {id})}";
            var responseStream = await httpClient.GetAsync(url, _clientId);

            var deserializedObject =  await JsonSerializer.DeserializeAsync<TwitchResponse<TwitchUser>>(responseStream);

            return deserializedObject.Data.FirstOrDefault();
        }

        public async Task<TwitchUser[]> GetUsers(string[] ids)
        {
            using var httpClient = new TwitchHttpClient();

            var url = $"{_getUsersEndpoint}?{GetQueryForParameters("id", ids)}";
            var responseStream = await httpClient.GetAsync(url, _clientId);

            var deserializedObject = await JsonSerializer.DeserializeAsync<TwitchResponse<TwitchUser>>(responseStream);

            return deserializedObject.Data;
        }

    }
}
