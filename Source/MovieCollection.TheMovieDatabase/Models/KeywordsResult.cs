namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class KeywordsResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("keywords")]
        public List<Keyword> Keywords { get; set; }
    }
}
