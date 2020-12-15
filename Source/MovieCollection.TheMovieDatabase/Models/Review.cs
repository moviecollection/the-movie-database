namespace MovieCollection.TheMovieDatabase.Models
{
    using System;
    using Newtonsoft.Json;

    public class Review
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}
