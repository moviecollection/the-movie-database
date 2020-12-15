namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class ContentRatings
    {
        [JsonProperty("iso_3166_1")]
        public string Iso31661 { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }
    }
}
