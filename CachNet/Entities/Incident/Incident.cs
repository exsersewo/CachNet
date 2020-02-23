using Newtonsoft.Json;
using System;

namespace CachNet.Entities
{
    public class Incident
    {
        [JsonProperty("id")]
        public int Id;
        [JsonProperty("component_id")]
        public int ComponentId;
        [JsonProperty("name")]
        public string Name;
        [JsonProperty("status")]
        public IncidentStatus Status;
        [JsonProperty("visible")]
        public int Visible;
        [JsonProperty("message")]
        public string Message;
        [JsonProperty("scheduled_at")]
        public DateTime ScheduledAt;
        [JsonProperty("created_at")]
        public DateTime CreatedAt;
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;
        [JsonProperty("deleted_at")]
        public DateTime? DeletedAt;
        [JsonProperty("human_status")]
        public string HumanStatus;
    }
}
