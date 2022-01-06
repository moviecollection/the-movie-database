namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class RatedTVShow : TVShow
    {
        [JsonProperty("rating")]
        public double Rating { get; set; }
    }
}
