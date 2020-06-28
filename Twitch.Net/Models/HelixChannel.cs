using System;
using System.Text.Json.Serialization;
using System.Xml;

namespace Twitch.Net.Models
{
    public class HelixChannel
    {

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("broadcaster_language")]
        public string BroadcasterLanguage { get; set; }

        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        [JsonPropertyName("game_id")]
        public string GameId { get; set; }

        [JsonPropertyName("is_live")]
        public bool IsLive { get; set; }

        [JsonPropertyName("tags_ids")]
        public string[] TagsIds { get; set; }

        [JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("started_at")]
        public string StartedAtRaw { get; set; }

        public DateTime? StartedAt
        {
            get
            {
                if (string.IsNullOrEmpty(StartedAtRaw))
                {
                    return null;
                }

                return XmlConvert.ToDateTime(StartedAtRaw, XmlDateTimeSerializationMode.Utc);
            }
        }

    }
}
