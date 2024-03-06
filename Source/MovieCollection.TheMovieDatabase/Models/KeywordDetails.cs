namespace MovieCollection.TheMovieDatabase.Models
{
    using Newtonsoft.Json;

    public class KeywordDetails : Response
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
