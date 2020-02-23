using Newtonsoft.Json;
using System;

namespace CachNet.Entities
{
    public class IncidentUpdate
    {
        [JsonProperty("id")]
        public int Id;
        [JsonProperty("incident_id")]
        public int IncidentId;
        [JsonProperty("status")]
        public IncidentStatus Status;
        [JsonProperty("message")]
        public string Message;
        [JsonProperty("user_id")]
        public int UserId;
        [JsonProperty("created_at")]
        public DateTime CreatedAt;
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;
        [JsonProperty("human_status")]
        public string HumanStatus;
        [JsonProperty("permalink")]
        public string Permalink;
    }
}
