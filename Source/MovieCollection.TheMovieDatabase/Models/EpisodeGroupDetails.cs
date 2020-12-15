namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class EpisodeGroupDetails : EpisodeGroup
    {
        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }
    }
}
