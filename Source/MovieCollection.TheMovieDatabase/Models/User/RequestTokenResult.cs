namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class RequestTokenResult : BasicSessionResult
    {
        [JsonProperty("expires_at")]
        public string ExpiresAt { get; set; }

        [JsonProperty("request_token")]
        public string RequestToken { get; set; }
    }
}
