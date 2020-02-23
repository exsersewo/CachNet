using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class PostIncidentUpdate
    {
        [JsonProperty("status")]
        public IncidentStatus Status;
        [JsonProperty("message")]
        public string Message;
    }
}
