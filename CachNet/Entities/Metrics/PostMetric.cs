using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class PostMetric
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("suffix")]
        public string Suffx;
        [JsonProperty("description")]
        public string Description;
        [JsonProperty("default_value")]
        public double DefaultValue;
        [JsonProperty("display_chart")]
        public int DisplayChart;
    }
}
