namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class EpisodeTranslationData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }
    }
}
