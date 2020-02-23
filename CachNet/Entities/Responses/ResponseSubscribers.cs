using CachNet.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CachNet.Entities
{
    public class ResponseSubscriber
    {
        [JsonProperty("meta")]
        public ResponseMeta Meta;

        [JsonProperty("data")]
        [JsonConverter(typeof(SingleOrArrayConverter<Subscriber>))]
        public List<Subscriber> Data;
    }
}