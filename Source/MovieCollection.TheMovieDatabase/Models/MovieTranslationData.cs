namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class MovieTranslationData
    {
        [JsonProperty("homepage")]
        public string Homepage { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("runtime")]
        public int Runtime { get; set; }

        [JsonProperty("tagline")]
        public string Tagline { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
