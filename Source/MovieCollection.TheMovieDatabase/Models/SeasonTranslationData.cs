namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class SeasonTranslationData
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }
    }
}
