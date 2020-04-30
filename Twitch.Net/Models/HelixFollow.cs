using System;
using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    /// <summary>
    /// Helix follow model
    /// </summary>
    public class HelixFollow
    {

        /// <summary>
        /// Id of the user that follows someone
        /// </summary>
        [JsonPropertyName("from_id")]
        public string FromId { get; set; }

        /// <summary>
        /// Display name of the user that follows someone
        ///
        /// <para>Note: That is not the user's login name</para>
        /// </summary>
        [JsonPropertyName("from_name")]
        public string FromName { get; set; }

        /// <summary>
        /// Id of the user that is being followed
        /// </summary>
        [JsonPropertyName("to_id")]
        public string ToId { get; set; }

        /// <summary>
        /// Display name of the user that is being followed
        ///
        /// <para>Note: That is not the user's login name</para>
        /// </summary>
        [JsonPropertyName("to_name")]
        public string ToName { get;set; }

        /// <summary>
        /// Date and time when the follow was created
        /// </summary>
        [JsonPropertyName("followed_at")]
        public DateTime FollowedAt { get; set; }

    }
}
