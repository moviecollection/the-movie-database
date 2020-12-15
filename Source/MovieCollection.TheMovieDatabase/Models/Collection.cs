namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class Collection
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }
    }
}
