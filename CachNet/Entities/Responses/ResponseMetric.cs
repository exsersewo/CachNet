using CachNet.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CachNet.Entities
{
    public class ResponseMetric
    {
        [JsonProperty("meta")]
        public ResponseMeta Meta;

        [JsonProperty("data")]
        [JsonConverter(typeof(SingleOrArrayConverter<Metric>))]
        public List<Metric> Data;
    }
}