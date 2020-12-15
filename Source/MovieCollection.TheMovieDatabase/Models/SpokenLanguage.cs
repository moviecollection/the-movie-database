namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class SpokenLanguage
    {
        [JsonProperty("iso_639_1")]
        public string Iso6391 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
