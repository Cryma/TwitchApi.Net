using System.Text.Json.Serialization;
using TwitchApi.Net.Models;

namespace TwitchApi.Net.Response
{
    public class TwitchPaginatedResponse<TResponseObject>
    {

        [JsonPropertyName("data")]
        public TResponseObject[] Data { get; set; }

        [JsonPropertyName("pagination")]
        public TwitchPagination Pagination { get; set; }

    }
}
