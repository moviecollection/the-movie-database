namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Find
    {
        [JsonProperty("movie_results")]
        public List<Movie> MovieResults { get; set; }

        [JsonProperty("tv_results")]
        public List<TVShow> TVResults { get; set; }

        [JsonProperty("person_results")]
        public List<Person> PersonResults { get; set; }

        [JsonProperty("tv_season_results")]
        public List<Season> SeasonResults { get; set; }

        [JsonProperty("tv_episode_results")]
        public List<Episode> EpisodeResults { get; set; }
    }
}
