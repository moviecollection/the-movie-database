namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class PersonCombinedCrew : BaseCombinedCredit
    {
        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }
    }
}
