namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class Response
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("status_code")]
        public int StatusCode { get; set; }

        [JsonProperty("status_message")]
        public string StatusMessage { get; set; }
    }
}
