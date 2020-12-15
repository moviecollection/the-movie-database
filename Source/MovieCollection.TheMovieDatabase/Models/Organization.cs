namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class Organization
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("origin_country")]
        public string OriginCountry { get; set; }

        [JsonProperty("logo_path")]
        public string LogoPath { get; set; }
    }
}
