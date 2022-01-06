namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class RatedMovie : Movie
    {
        [JsonProperty("rating")]
        public double Rating { get; set; }
    }
}
