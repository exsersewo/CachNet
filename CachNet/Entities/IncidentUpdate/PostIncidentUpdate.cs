using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class PostIncidentUpdate
    {
        [JsonProperty("status"), JsonRequired]
        public IncidentStatus Status;
        [JsonProperty("message"), JsonRequired]
        public string Message;
    }
}
