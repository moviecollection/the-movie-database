namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class CollectionTranslationData
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }
    }
}
