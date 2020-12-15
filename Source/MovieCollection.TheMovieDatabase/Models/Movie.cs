namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Movie : BaseMovie
    {
        [JsonProperty("genre_ids")]
        public List<int> GenreIds { get; set; }
    }
}
