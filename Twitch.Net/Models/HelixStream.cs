using System;
using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    /// <summary>
    /// Helix stream model
    /// </summary>
    public class HelixStream
    {

        /// <summary>
        /// Unique stream identifier
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Broadcaster user id
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Broadcaster display name
        ///
        /// <para>Note: That is not the user's login name</para>
        /// </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        /// <summary>
        /// Game id
        /// </summary>
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }

        /// <summary>
        /// Stream type
        ///
        /// <para>Usually "live", empty string when an error occurs</para>
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Stream title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Stream viewer count
        /// </summary>
        [JsonPropertyName("viewer_count")]
        public int ViewerCount { get; set; }

        /// <summary>
        /// Date and time the stream was started at
        /// </summary>
        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; set; }

        /// <summary>
        /// Stream language
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        ///  Stream thumbnail url
        /// </summary>
        [JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

    }
}
