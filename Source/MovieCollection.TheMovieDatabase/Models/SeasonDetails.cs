namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class SeasonDetails : BaseSeason
    {
        [JsonProperty("episodes")]
        public List<SeasonEpisode> Episodes { get; set; }
    }
}
