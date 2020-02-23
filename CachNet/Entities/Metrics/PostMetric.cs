using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class PostMetric
    {
        [JsonProperty("name"), JsonRequired]
        public string Name;
        [JsonProperty("suffix"), JsonRequired]
        public string Suffx;
        [JsonProperty("description"), JsonRequired]
        public string Description;
        [JsonProperty("default_value"), JsonRequired]
        public double DefaultValue;
        [JsonProperty("display_chart"), JsonRequired]
        public int DisplayChart;
    }
}
