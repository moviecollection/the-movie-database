namespace MovieCollection.TheMovieDatabase.Models
{
    using System;
    using Newtonsoft.Json;

    public class NowPlayingDates
    {
        [JsonProperty("maximum")]
        public DateTimeOffset Maximum { get; set; }

        [JsonProperty("minimum")]
        public DateTimeOffset Minimum { get; set; }
    }
}
