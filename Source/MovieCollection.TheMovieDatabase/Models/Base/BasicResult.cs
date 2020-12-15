namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class BasicResult<T>
        where T : class
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("results")]
        public List<T> Results { get; set; }
    }
}
