using System.Text.Json.Serialization;

namespace Twitch.Net.Models
{
    /// <summary>
    /// Helix pagination model
    /// </summary>
    public class HelixPagination
    {

        /// <summary>
        /// Pagination cursor
        /// </summary>
        [JsonPropertyName("cursor")]
        public string Cursor { get; set; }

    }
}
