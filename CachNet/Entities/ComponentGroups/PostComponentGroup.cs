using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class PostComponentGroup
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("order")]
        public int Order;
        [JsonProperty("collapsed")]
        public Collapsable Collapsed;
    }
}