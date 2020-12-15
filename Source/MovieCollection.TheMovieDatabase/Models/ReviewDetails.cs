namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class ReviewDetails : Review
    {
        [JsonProperty("iso_639_1")]
        public string Iso6391 { get; set; }

        [JsonProperty("media_id")]
        public int MediaId { get; set; }

        [JsonProperty("media_title")]
        public string MediaTitle { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("author_details")]
        public ReviewAuthorDetails AuthorDetails { get; set; }
    }
}
