using Newtonsoft.Json;

namespace CachNet.Entities
{
    public class ResponsePaginationLinks
    {
        [JsonProperty("previous_page")]
        public string PreviousPage;

        [JsonProperty("next_page")]
        public string NextPage;
    }
}