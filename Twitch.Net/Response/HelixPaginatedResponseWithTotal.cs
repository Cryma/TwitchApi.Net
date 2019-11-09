using System.Text.Json.Serialization;

namespace Twitch.Net.Response
{
    public class HelixPaginatedResponseWithTotal<TResponseObject> : HelixPaginatedResponse<TResponseObject>
    {

        [JsonPropertyName("total")]
        public int Total { get; set; }

    }
}
