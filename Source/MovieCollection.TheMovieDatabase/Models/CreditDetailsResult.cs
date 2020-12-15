namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class CreditDetailsResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("credit_type")]
        public string CreditType { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("person")]
        public CreditPerson Person { get; set; }

        // TODO: Media
    }
}
