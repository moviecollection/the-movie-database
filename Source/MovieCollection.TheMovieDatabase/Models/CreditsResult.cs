namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class CreditsResult : Credits
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
