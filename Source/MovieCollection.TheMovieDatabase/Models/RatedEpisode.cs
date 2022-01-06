namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class RatedEpisode : Episode
    {
        [JsonProperty("rating")]
        public double Rating { get; set; }
    }
}
