using Newtonsoft.Json;
using System;

namespace CachNet.Entities
{
    public class Metric
    {
        [JsonProperty("id")]
        public int Id;
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("suffix")]
        public string Suffx;
        [JsonProperty("description")]
        public string Description;
        [JsonProperty("default_value")]
        public double DefaultValue;
        [JsonProperty("calc_type")]
        public int CalcType;
        [JsonProperty("display_chart")]
        public int DisplayChart;
        [JsonProperty("created_at")]
        public DateTime CreatedAt;
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;
        [JsonProperty("default_view_name")]
        public string DefaultViewName;
    }
}
