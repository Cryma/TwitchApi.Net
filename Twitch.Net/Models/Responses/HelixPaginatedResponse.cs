using System.Text.Json.Serialization;

namespace Twitch.Net.Models.Responses
{
    /// <summary>
    /// Helix response with pagination
    /// </summary>
    /// <typeparam name="TResponseObject">Helix model that the response contains</typeparam>
    public class HelixPaginatedResponse<TResponseObject>
    {

        /// <summary>
        /// Array of <see cref="TResponseObject"/>
        /// </summary>
        [JsonPropertyName("data")]
        public TResponseObject[] Data { get; set; }

        /// <summary>
        /// Pagination model
        /// </summary>
        [JsonPropertyName("pagination")]
        public HelixPagination Pagination { get; set; }

    }
}
