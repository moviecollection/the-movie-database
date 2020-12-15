namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class AlternativeTitle
    {
        [JsonProperty("iso_3166_1")]
        public string Iso31661 { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
