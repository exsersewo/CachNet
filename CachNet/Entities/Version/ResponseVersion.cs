using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class ResponseVersion
    {
        [JsonProperty("meta")]
        public ResponseMetaVersion Meta;

        [JsonProperty("data")]
        public string Data;
    }
}