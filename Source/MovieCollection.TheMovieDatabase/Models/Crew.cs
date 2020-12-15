namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class Crew : BaseCredit
    {
        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }
    }
}
