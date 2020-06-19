using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Responses
{
    public class HelixNotFoundResponse
    {

        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

    }
}
