namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class SessionResult : BasicSessionResult
    {
        [JsonProperty("session_id")]
        public string SessionId { get; set; }
    }
}
