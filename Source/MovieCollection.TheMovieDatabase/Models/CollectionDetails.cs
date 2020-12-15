namespace MovieCollection.TheMovieDatabase.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CollectionDetails : Collection
    {
        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("parts")]
        public List<Movie> Parts { get; set; }
    }
}
