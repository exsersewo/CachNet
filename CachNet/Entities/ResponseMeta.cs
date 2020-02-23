using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class ResponseMeta
    {
        [JsonProperty("pagination")]
        public ResponsePagination Pagination;
    }
}