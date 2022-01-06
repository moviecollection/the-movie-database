namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class AccountDetails
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("iso_639_1")]
        public string Iso639_1 { get; set; }

        [JsonProperty("iso_3166_1")]
        public string Iso3166_1 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("include_adult")]
        public bool IncludeAdult { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
