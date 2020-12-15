namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class GroupEpisode : Episode
    {
        [JsonProperty("order")]
        public int Order { get; set; }
    }
}
