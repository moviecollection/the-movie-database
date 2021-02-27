namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class PersonMovieCast : BaseMovie
    {
        [JsonProperty("genre_ids")]
        public List<int> GenreIds { get; set; }

        [JsonProperty("character")]
        public string Character { get; set; }

        [JsonProperty("credit_id")]
        public string CreditId { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }
    }
}
