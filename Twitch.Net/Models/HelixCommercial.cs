using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    /// <summary>
    /// Helix commercial model
    /// </summary>
    public class HelixCommercial
    {

        /// <summary>
        /// Length of triggered commercial
        /// </summary>
        [JsonPropertyName("length")]
        public int Length { get; set; }

        /// <summary>
        /// Contextual information if the request failed
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// Seconds until next commercial can be served
        /// </summary>
        [JsonPropertyName("retryAfter")]
        public int RetryAfter { get; set; }

    }
}
