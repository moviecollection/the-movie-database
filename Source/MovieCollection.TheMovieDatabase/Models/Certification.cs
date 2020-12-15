namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class Certification
    {
        [JsonProperty("certification")]
        public string Title { get; set; }

        [JsonProperty("meaning")]
        public string Meaning { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }
    }
}
