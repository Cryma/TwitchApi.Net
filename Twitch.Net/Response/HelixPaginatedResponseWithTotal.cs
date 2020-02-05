using System.Text.Json.Serialization;

namespace Twitch.Net.Response
{
    /// <summary>
    /// <inheritdoc cref="HelixPaginatedResponse{TResponseObject}"/>
    ///
    /// <para>Additionally contains total amount of data</para>
    /// </summary>
    /// <typeparam name="TResponseObject"></typeparam>
    public class HelixPaginatedResponseWithTotal<TResponseObject> : HelixPaginatedResponse<TResponseObject>
    {

        /// <summary>
        /// Total amount of data
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }

    }
}
