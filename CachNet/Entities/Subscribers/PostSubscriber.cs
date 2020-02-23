using Newtonsoft.Json;
using System.Collections.Generic;

namespace CachNet.Net
{
    public class PostSubscriber
    {
        [JsonProperty("email"), JsonRequired]
        public string EMail;
        [JsonProperty("verify")]
        public bool Verify;
        [JsonProperty("components")]
        public List<int> Components;
    }
}