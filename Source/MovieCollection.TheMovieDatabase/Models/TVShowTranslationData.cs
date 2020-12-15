namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class TVShowTranslationData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }
    }
}
