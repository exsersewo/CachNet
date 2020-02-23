using Newtonsoft.Json;
using System;

namespace CachNet.Entities
{
    public class Subscriber
    {
        [JsonProperty("id")]
        public int Id;
        [JsonProperty("email")]
        public string Email;
        [JsonProperty("verify_code")]
        public string VerifyCode;
        [JsonProperty("verified_at")]
        public DateTime VerifiedAt;
        [JsonProperty("created_at")]
        public DateTime CreatedAt;
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;
    }
}
