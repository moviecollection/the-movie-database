namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class ReviewAuthorDetails
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("avatar_path")]
        public string AvatarPath { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }
    }
}
