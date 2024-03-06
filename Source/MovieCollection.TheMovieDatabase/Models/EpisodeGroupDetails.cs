namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class EpisodeGroupDetails : Response
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("episode_count")]
        public int EpisodeCount { get; set; }

        [JsonProperty("group_count")]
        public int GroupCount { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("network")]
        public Organization Network { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }
    }
}
