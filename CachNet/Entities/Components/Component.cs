using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CachNet.Entities
{
    public class Component
    {
        [JsonProperty("id")]
        public int Id;
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("description")]
        public string Description;
        [JsonProperty("link")]
        public string Link;
        [JsonProperty("status")]
        public ComponentStatus Status;
        [JsonProperty("order")]
        public int Order;
        [JsonProperty("group_id")]
        public int GroupId;
        [JsonProperty("created_at")]
        public DateTime CreatedAt;
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt;
        [JsonProperty("status_name")]
        public string StatusName;
        [JsonProperty("tags")]
        public Dictionary<string, string> Tags;
    }
}