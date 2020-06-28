using System;
using System.Text.Json.Serialization;
using System.Xml;

namespace Twitch.Net.Models.Partials
{
    public class HelixBannedUserEventData
    {

        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        [JsonPropertyName("expires_at")]
        public string ExpiresAtRaw { get; set; }

        public DateTime? ExpiresAt
        {
            get
            {
                if (string.IsNullOrEmpty(ExpiresAtRaw))
                {
                    return null;
                }

                return XmlConvert.ToDateTime(ExpiresAtRaw, XmlDateTimeSerializationMode.Utc);
            }
        }

    }
}
