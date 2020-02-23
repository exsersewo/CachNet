using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class ResponseMetaVersion
    {
        [JsonProperty("on_latest")]
        public bool OnLatest;

        [JsonProperty("latest")]
        public ResponseLatest Latest;
    }
}