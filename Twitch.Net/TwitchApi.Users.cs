using System.Linq;
using System.Net;
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
            using var httpClient = GetPreparedHttpClient();

            var url = $"{_getUsersEndpoint}?{GetQueryForParameters("id", new[] {id})}";
            var response = await httpClient.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return null;
            }

            var deserializedObject =  await JsonSerializer.DeserializeAsync<TwitchResponse<TwitchUser>>(await response.Content.ReadAsStreamAsync());

            return deserializedObject.Data.FirstOrDefault();
        }

        public async Task<TwitchUser[]> GetUsers(string[] ids)
        {
            using var httpClient = GetPreparedHttpClient();

            var url = $"{_getUsersEndpoint}?{GetQueryForParameters("id", ids)}";
            var response = await httpClient.GetAsync(url);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return null;
            }

            var deserializedObject = await JsonSerializer.DeserializeAsync<TwitchResponse<TwitchUser>>(await response.Content.ReadAsStreamAsync());

            return deserializedObject.Data;
        }

    }
}
