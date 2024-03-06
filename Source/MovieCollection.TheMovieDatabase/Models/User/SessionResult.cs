namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class SessionResult : Response
    {
        [JsonProperty("session_id")]
        public string SessionId { get; set; }
    }
}
