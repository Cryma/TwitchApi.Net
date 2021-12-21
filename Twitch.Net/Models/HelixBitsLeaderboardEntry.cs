using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    public class HelixBitsLeaderboardEntry
    {

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

    }
}
