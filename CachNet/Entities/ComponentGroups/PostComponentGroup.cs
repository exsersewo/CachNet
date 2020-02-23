using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class PostComponentGroup
    {
        [JsonProperty("name"), JsonRequired]
        public string Name;
        [JsonProperty("order")]
        public int Order;
        [JsonProperty("collapsed")]
        public Collapsable Collapsed;
    }
}