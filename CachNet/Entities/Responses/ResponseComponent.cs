using CachNet.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CachNet.Entities
{
    public class ResponseComponent
    {
        [JsonProperty("meta")]
        public ResponseMeta Meta;

        [JsonProperty("data")]
        [JsonConverter(typeof(SingleOrArrayConverter<Component>))]
        public List<Component> Data;
    }
}