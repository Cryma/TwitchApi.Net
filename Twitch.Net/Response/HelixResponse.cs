using System.Text.Json.Serialization;

namespace Twitch.Net.Response
{
    /// <summary>
    /// Helix response
    /// </summary>
    /// <typeparam name="TResponseObject"></typeparam>
    public class HelixResponse<TResponseObject>
    {

        /// <summary>
        /// Array of <see cref="TResponseObject"/>
        /// </summary>
        [JsonPropertyName("data")]
        public TResponseObject[] Data { get; set; }

    }
}
