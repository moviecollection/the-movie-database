namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class BaseCredit
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("credit_id")]
        public string CreditId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }
    }
}
