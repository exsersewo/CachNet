using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class PostComponent
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("description")]
        public string Description;
        [JsonProperty("status")]
        public ComponentStatus Status = 0;
        [JsonProperty("link")]
        public string Link;
        [JsonProperty("order")]
        public int Order = 0;
        [JsonProperty("group_id")]
        public int GroupId = 0;
        [JsonProperty("enabled")]
        public bool Enabled = true;
    }
}