using System.Text.Json.Serialization;
using Twitch.Net.Models.Enums;

namespace Twitch.Net.Models
{
    /// <summary>
    /// Helix video model
    /// </summary>
    public class HelixVideo
    {

        /// <summary>
        /// Unique video identifier
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Video owner id
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Video owner display name
        ///
        /// <para>Note: That is not the user's login name</para>
        /// </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        /// <summary>
        /// Video title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Video description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Date and time the video was created at
        /// </summary>
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Date and time the video was published at
        /// </summary>
        [JsonPropertyName("published_at")]
        public string PublishedAt { get; set; }

        /// <summary>
        /// Video url
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Video thumbnail url
        /// </summary>
        [JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// Video viewable status
        ///
        /// <para>Either "public" or "private"</para>
        /// </summary>
        [JsonPropertyName("viewable")]
        public HelixVideoViewableType Viewable { get; set; }

        /// <summary>
        /// Video view count
        /// </summary>
        [JsonPropertyName("view_count")]
        public int ViewCount { get; set; }

        /// <summary>
        /// Video language
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// Video type
        ///
        /// <para>Either "upload", "archive" or "highlight"</para>
        /// </summary>
        [JsonPropertyName("type")]
        public HelixVideoType Type { get; set; }

        /// <summary>
        /// Video duration
        ///
        /// <para>Example: "1h49m20s"</para>
        /// </summary>
        [JsonPropertyName("duration")]
        public string Duration { get; set; }

    }
}
