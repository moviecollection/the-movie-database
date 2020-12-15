namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class ReleaseDate
    {
        [JsonProperty("certification")]
        public string Certification { get; set; }

        [JsonProperty("iso_639_1")]
        public string Iso6391 { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("release_date")]
        public string Date { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }
    }
}
