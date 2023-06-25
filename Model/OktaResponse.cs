using Newtonsoft.Json;

namespace WebApplication6.Model
{
    public class OktaResponse
    {
        [JsonProperty(PropertyName ="access_token")]
        public string AccessToken { get;set; }

        [JsonProperty(PropertyName = "expire_in")]
        public int ExpiresIn { get; set; }
      
        public DateTime ExpiresAt { get; set; }
        public string Scope { get; set; }
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }
    }
}
