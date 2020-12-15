namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class ReviewResult : PagedResult<Review>
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
