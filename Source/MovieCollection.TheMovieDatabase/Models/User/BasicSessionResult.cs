namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class BasicSessionResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
