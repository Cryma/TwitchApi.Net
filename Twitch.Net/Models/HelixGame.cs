using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    /// <summary>
    /// Helix game model
    /// </summary>
    public class HelixGame
    {

        /// <summary>
        /// Unique game identifier
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Game name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Box art url
        /// </summary>
        [JsonPropertyName("box_art_url")]
        public string BoxArtUrl { get; set; }

    }
}
