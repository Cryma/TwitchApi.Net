using System.Text.Json.Serialization;

namespace TwitchApi.Net.Response
{
    public class TwitchResponse<TResponseObject>
    {
        
        [JsonPropertyName("data")]
        public TResponseObject[] Data { get; set; }

    }
}
