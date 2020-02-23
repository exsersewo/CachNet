using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class ResponseSingle<T>
    {
        [JsonProperty("meta")]
        public ResponseMeta Meta;

        [JsonProperty("data")]
        public T Data;
    }
}