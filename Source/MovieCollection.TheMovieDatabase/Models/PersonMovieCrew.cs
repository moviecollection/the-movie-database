namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PersonMovieCrew : BaseMovie
    {
        [JsonProperty("genre_ids")]
        public List<int> GenreIds { get; set; }

        [JsonProperty("credit_id")]
        public string CreditId { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }
    }
}
