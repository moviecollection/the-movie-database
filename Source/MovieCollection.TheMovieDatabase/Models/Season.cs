namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class Season : BaseSeason
    {
        [JsonProperty("episode_count")]
        public int EpisodeCount { get; set; }

        [JsonProperty("show_id")]
        public int ShowId { get; set; }
    }
}
