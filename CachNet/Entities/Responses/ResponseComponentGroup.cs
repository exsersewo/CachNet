using CachNet.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CachNet.Entities
{
    public class ResponseComponentGroup
    {
        [JsonProperty("meta")]
        public ResponseMeta Meta;

        [JsonProperty("data")]
        [JsonConverter(typeof(SingleOrArrayConverter<ComponentGroup>))]
        public List<ComponentGroup> Data;
    }
}