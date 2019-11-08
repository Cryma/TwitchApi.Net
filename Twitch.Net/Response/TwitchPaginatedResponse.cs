using System.Text.Json.Serialization;
using Twitch.Net.Models;

namespace Twitch.Net.Response
{
    public class TwitchPaginatedResponse<TResponseObject>
    {

        [JsonPropertyName("data")]
        public TResponseObject[] Data { get; set; }

        [JsonPropertyName("pagination")]
        public TwitchPagination Pagination { get; set; }

    }
}
