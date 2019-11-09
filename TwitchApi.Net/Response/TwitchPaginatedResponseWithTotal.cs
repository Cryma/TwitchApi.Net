using System.Text.Json.Serialization;

namespace TwitchApi.Net.Response
{
    public class TwitchPaginatedResponseWithTotal<TResponseObject> : TwitchPaginatedResponse<TResponseObject>
    {

        [JsonPropertyName("total")]
        public int Total { get; set; }

    }
}
