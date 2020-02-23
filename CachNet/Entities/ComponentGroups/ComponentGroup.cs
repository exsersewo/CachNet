using Newtonsoft.Json;
using System;

namespace CachNet.Entities
{
    public class ComponentGroup
    {
        [JsonProperty("id")]
        public int Id;
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("created_at")]
        public DateTime CreatedAt;
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;
        [JsonProperty("order")]
        public int Order;
        [JsonProperty("collapsed")]
        public Collapsable Collapsed;
    }
}
