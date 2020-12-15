namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class SearchCollection : Collection
    {
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }
    }
}
