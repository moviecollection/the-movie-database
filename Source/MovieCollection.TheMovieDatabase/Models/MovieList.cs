namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class MovieList
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("favorite_count")]
        public int FavoriteCount { get; set; }

        [JsonProperty("item_count")]
        public int ItemCount { get; set; }

        [JsonProperty("iso_639_1")]
        public string Iso6391 { get; set; }

        [JsonProperty("list_type")]
        public string ListType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }
    }
}
