using System.Text.Json.Serialization;

namespace Twitch.Net.Response
{
    public class TwitchResponse<TResponseObject>
    {
        
        [JsonPropertyName("data")]
        public TResponseObject[] Data { get; set; }

    }
}
