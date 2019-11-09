using System.Text.Json.Serialization;

namespace Twitch.Net.Response
{
    public class HelixResponse<TResponseObject>
    {

        [JsonPropertyName("data")]
        public TResponseObject[] Data { get; set; }

    }
}
