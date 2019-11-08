using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    public class TwitchPagination
    {

        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }

    }
}
