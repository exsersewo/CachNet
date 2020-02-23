using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class PostMetricPoint
    {
        [JsonProperty("value"), JsonRequired]
        public int Value;
        [JsonProperty("timestamp")]
        public ulong Timestamp;
    }
}
