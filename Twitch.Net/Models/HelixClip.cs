using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    /// <summary>
    /// Helix clip model
    /// </summary>
    public class HelixClip
    {

        /// <summary>
        /// Unique clip identifier
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Clip url
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Clip embed url
        /// </summary>
        [JsonPropertyName("embed_url")]
        public string EmbedUrl { get; set; }

        /// <summary>
        /// Clip broadcaster id
        /// </summary>
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        /// <summary>
        /// Clip broadcaster display name
        ///
        /// <para>Note: That is not the user's login name</para>
        /// </summary>
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }

        /// <summary>
        /// Clip creator id
        /// </summary>
        [JsonPropertyName("creator_id")]
        public string CreatorId { get; set; }

        /// <summary>
        /// Clip creator display name
        ///
        /// <para>Note: That is not the user's login name</para>
        /// </summary>
        [JsonPropertyName("creator_name")]
        public string CreatorName { get; set; }

        /// <summary>
        /// Id of the related video
        /// </summary>
        [JsonPropertyName("video_id")]
        public string VideoId { get; set; }

        /// <summary>
        /// Id of the related game
        /// </summary>
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }

        /// <summary>
        /// Stream language
        /// </summary>
        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// Clip title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Clip view count
        /// </summary>
        [JsonPropertyName("view_count")]
        public int ViewCount { get; set; }

        // TODO: Parse as actual datetime
        /// <summary>
        /// Creation date and time
        /// </summary>
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// Clip thumbnail url
        /// </summary>
        [JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

    }
}
