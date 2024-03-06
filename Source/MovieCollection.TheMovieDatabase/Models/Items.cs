namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Items<T>
    {
        [JsonProperty("results")]
        public List<T> Results { get; set; }
    }
}
