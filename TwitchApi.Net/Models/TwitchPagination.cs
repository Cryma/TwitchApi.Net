using System.Text.Json.Serialization;

namespace TwitchApi.Net.Models
{
    public class TwitchPagination
    {

        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }

    }
}
