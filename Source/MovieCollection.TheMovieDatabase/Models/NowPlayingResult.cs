namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class NowPlayingResult : PagedResult<Movie>
    {
        [JsonProperty("dates")]
        public NowPlayingDates Dates { get; set; }
    }
}
