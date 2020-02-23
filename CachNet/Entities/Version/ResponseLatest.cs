using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class ResponseLatest
    {
        [JsonProperty("tag_name")]
        public string TagName { get; set; }

        [JsonProperty("prerelease")]
        public bool Prerelease { get; set; }

        [JsonProperty("draft")]
        public bool Draft { get; set; }
    }
}