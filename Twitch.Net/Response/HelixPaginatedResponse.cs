using System.Text.Json.Serialization;
using Twitch.Net.Models;

namespace Twitch.Net.Response
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
