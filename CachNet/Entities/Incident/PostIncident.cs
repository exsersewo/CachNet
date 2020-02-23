using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CachNet.Entities
{
    public class PostIncident
    {
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("message")]
        public string Message;
        [JsonProperty("status")]
        public IncidentStatus Status;
        [JsonProperty("visible")]
        public int Visible;
        [JsonProperty("component_id")]
        public int ComponentId;
        [JsonProperty("component_status")]
        public ComponentStatus ComponentStatus;
        [JsonProperty("notify")]
        public bool Notify;
        [JsonProperty("created_at")]
        public DateTime CreatedAt;
        [JsonProperty("template")]
        public string Template;
        [JsonProperty("vars")]
        public List<string> Vars;
    }
}
