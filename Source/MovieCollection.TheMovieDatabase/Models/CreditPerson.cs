namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class CreditPerson
    {
        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("known_for_department")]
        public string KnownForDepartment { get; set; }

        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        // TODO: KnownFor.
    }
}
