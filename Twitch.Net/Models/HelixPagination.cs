using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    public class HelixPagination
    {

        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }

    }
}
