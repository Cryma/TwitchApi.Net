using System.Text.Json;
using System.Threading.Tasks;
using Twitch.Net.Models;

namespace Twitch.Net
{
    public partial class TwitchApi
    {

        private const string _getPanelsEndpoint = "https://api.twitch.tv/api/channels/{0}/panels";

        public async Task<UndocumentedPanel[]> GetPanels(string loginName)
        {
            using var httpClient = GetHttpClient();

            var responseStream = await httpClient.GetAsync(string.Format(_getPanelsEndpoint, loginName), null, _clientId);

            return await JsonSerializer.DeserializeAsync<UndocumentedPanel[]>(responseStream);
        }

    }
}
