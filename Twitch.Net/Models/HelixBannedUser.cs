using System;
using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    public class HelixBannedUser
    {

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        [JsonPropertyName("expires_at")]
        public DateTime ExpiresAt { get; set; }

    }
}