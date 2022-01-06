namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class Response
    {
        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }
    }
}
