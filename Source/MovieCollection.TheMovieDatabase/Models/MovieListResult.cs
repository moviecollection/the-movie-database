namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class MovieListResult : PagedResult<MovieList>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
