namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class BasePerson
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }
    }
}
