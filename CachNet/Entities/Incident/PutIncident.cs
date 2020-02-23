using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class PutIncident
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
    }
}
