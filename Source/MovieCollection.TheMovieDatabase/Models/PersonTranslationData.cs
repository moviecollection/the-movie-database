namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class PersonTranslationData
    {
        [JsonProperty("biography")]
        public string Biography { get; set; }
    }
}
