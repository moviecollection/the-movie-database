namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class CompanyName
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
