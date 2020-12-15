namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class Episode : BaseEpisode
    {
        [JsonProperty("show_id")]
        public int ShowId { get; set; }
    }
}
