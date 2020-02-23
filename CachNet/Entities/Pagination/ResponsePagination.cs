using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class ResponsePagination
    {
        [JsonProperty("total")]
        public int Total;

        [JsonProperty("count")]
        public int Count;

        [JsonProperty("per_page")]
        public int PerPage;

        [JsonProperty("current_page")]
        public int CurrentPage;

        [JsonProperty("total_pages")]
        public int TotalPages;

        [JsonProperty("links")]
        public ResponsePaginationLinks Links;
    }
}