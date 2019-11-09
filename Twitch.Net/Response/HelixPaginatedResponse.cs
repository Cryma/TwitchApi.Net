using System.Text.Json.Serialization;
using Twitch.Net.Models;

namespace Twitch.Net.Response
{
    public class HelixPaginatedResponse<TResponseObject>
    {

        [JsonPropertyName("data")]
        public TResponseObject[] Data { get; set; }

        [JsonPropertyName("pagination")]
        public HelixPagination Pagination { get; set; }

    }
}
