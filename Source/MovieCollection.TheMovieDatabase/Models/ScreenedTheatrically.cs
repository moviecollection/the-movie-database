namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class ScreenedTheatrically
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("episode_number")]
        public int EpisodeNumber { get; set; }

        [JsonProperty("season_number")]
        public int SeasonNumber { get; set; }
    }
}
