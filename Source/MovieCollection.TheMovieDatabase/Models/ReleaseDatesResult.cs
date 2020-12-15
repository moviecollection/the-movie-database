namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ReleaseDatesResult
    {
        [JsonProperty("iso_3166_1")]
        public string Iso31661 { get; set; }

        [JsonProperty("release_dates")]
        public List<ReleaseDate> ReleaseDates { get; set; }
    }
}
