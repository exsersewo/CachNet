using Newtonsoft.Json;
using System;

namespace CachNet.Entities
{
    public class MetricPoint
    {
        [JsonProperty("id")]
        public int Id;
        [JsonProperty("metric)id")]
        public int MetricId;
        [JsonProperty("value")]
        public int Value;
        [JsonProperty("created_at")]
        public DateTime CreatedAt;
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;
    }
}
