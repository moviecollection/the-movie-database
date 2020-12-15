namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Group
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }

        [JsonProperty("episodes")]
        public List<GroupEpisode> Episodes { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }
    }
}
