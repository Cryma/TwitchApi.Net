using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    /// <summary>
    /// Helix user model
    /// </summary>
    public class HelixUser
    {

        /// <summary>
        /// Unique user identifier
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// User login name
        /// </summary>
        [JsonPropertyName("login")]
        public string Login { get; set; }

        /// <summary>
        /// User display name
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        // TODO: Add enum
        /// <summary>
        /// User type
        ///
        /// <para>Either "staff", "admin", "global_mod" or empty string</para>
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        // TODO: Add enum
        /// <summary>
        /// Broadcaster type
        ///
        /// <para>Either "partner", "affiliate" or empty string</para>
        /// </summary>
        [JsonPropertyName("broadcaster_type")]
        public string BroadcasterType { get; set; }

        /// <summary>
        /// User channel description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// User profile image url
        /// </summary>
        [JsonPropertyName("profile_image_url")]
        public string ProfileImageUrl { get; set; }

        /// <summary>
        /// User stream offline image url
        /// </summary>
        [JsonPropertyName("offline_image_url")]
        public string OfflineImageUrl { get; set; }

        /// <summary>
        /// Total number of views
        /// </summary>
        [JsonPropertyName("view_count")]
        public int ViewCount { get; set; }

        /// <summary>
        /// User email
        ///
        /// <para>Note: Only returned if accessToken has <c>user:read:email</c> scope</para>
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

    }
}
