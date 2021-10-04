namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class PersonCombinedCast : BaseCombinedCredit
    {
        [JsonProperty("character")]
        public string Character { get; set; }

        [JsonProperty("order")]
        public int? Order { get; set; }
    }
}
