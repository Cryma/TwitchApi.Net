using System.Text.Json.Serialization;
using Twitch.Net.Models.Partials;

namespace Twitch.Net.Models.Responses
{
    public class HelixDateRangeResponseWithTotal<TResponseObject> : HelixResponse<TResponseObject>
    {

        [JsonPropertyName("date_range")]
        public HelixDateRange DateRange { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

    }
}
