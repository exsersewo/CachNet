using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class PostMetricPoint
    {
        [JsonProperty("value")]
        public int Value;
        [JsonProperty("timestamp")]
        public ulong Timestamp;
    }
}
