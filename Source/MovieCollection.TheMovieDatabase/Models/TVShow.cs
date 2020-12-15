namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class TVShow : BaseTVShow
    {
        [JsonProperty("genre_ids")]
        public List<int> GenreIds { get; set; }
    }
}
