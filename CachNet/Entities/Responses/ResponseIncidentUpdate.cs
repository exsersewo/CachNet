using CachNet.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CachNet.Entities
{
    public class ResponseIncidentUpdate
    {
        [JsonProperty("meta")]
        public ResponseMeta Meta;

        [JsonProperty("data")]
        [JsonConverter(typeof(SingleOrArrayConverter<IncidentUpdate>))]
        public List<IncidentUpdate> Data;
    }
}